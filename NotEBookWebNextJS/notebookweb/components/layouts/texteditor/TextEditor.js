import React, { useState } from "react";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Collapse from "@mui/material/Collapse";
import IconButton from "@mui/material/IconButton";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import DeleteIcon from "@mui/icons-material/Delete";
import { TransitionGroup } from "react-transition-group";
import { getDatabase, ref, get, update, child } from "firebase/database";
import { useAppSelector, useAppDispatch } from "../../../redux/Hooks";
import { setUser } from "../../../redux/slices/UserSlice";
import { Divider, Stack } from "@mui/material";
import ImageListItem from "@mui/material/ImageListItem";
import ImageListItemBar from "@mui/material/ImageListItemBar";
import { styled } from "@mui/material/styles";
import {
  getStorage,
  uploadBytesResumable,
  getDownloadURL,
  deleteObject,
  ref as sRef,
} from "firebase/storage";

function TextEditor({}) {
  const [input, setInput] = useState("");
  const dispatch = useAppDispatch();
  const [image, setImage] = useState("");

  const token = useAppSelector((state) => state.tokenSlice.token);
  const user = useAppSelector((state) => state.userSlice.user);

  const Input = styled("input")({
    display: "none",
  });

  async function handleAddNote() {
    if (token) {
      const storage = getStorage();
      const storageRef = sRef(storage, `images/${image.name}`);
      const uploadTask = uploadBytesResumable(storageRef, image);

      uploadTask.on(
        "state_changed",
        (snapshot) => {},
        (error) => {
          console.log(error);
        },
        () => {
          getDownloadURL(uploadTask.snapshot.ref).then((url) => {
            const newNote = {
              note: input,
              image: { name: image.name, url: url },
            };
            const newNotes = [...(user.notes ?? []), newNote];
            try {
              update(ref(getDatabase(), "users/" + token.localId), {
                notes: newNotes,
              });

              dispatch(setUser({ ...user, notes: newNotes }));

              setInput("");
            } catch (error) {
              console.log(error);
            }
          });
        }
      );
    }
  }

  function handleRemoveNote(index) {
    if (token) {
      const storage = getStorage();
      const desertRef = sRef(storage, `images/${user.notes[index].image.name}`);
      const newNotes = user.notes.filter((a, i) => i !== index);
      try {
        update(ref(getDatabase(), "users/" + token.localId), {
          notes: newNotes,
        });
        deleteObject(desertRef);

        dispatch(setUser({ ...user, notes: newNotes }));
      } catch (error) {
        console.log(error);
      }
    }
  }

  const handleChangeInput = (event) => {
    setInput(event.target.value);
  };

  return (
    <div
      style={{
        display: "flex",
        flexDirection: "column",
        background: "white",
        padding: "50px",
        borderRadius: "10px",
        width: "800px",
        height: "800px",
        overflow: "hidden",
      }}
    >
      <Stack spacing={2}>
        <TextField
          id="standard-multiline-static"
          sx={{ background: "white" }}
          label="Note"
          multiline
          rows={4}
          size="large"
          value={input}
          onChange={handleChangeInput}
        />
        <label htmlFor="contained-button-file">
          <Input
            accept="image/*"
            id="contained-button-file"
            multiple
            type="file"
            onChange={(e) => {
              setImage(e.target.files[0]);
            }}
          />
          <Button
            style={{ width: "100%" }}
            variant="contained"
            component="span"
          >
            Upload file
          </Button>
        </label>
        <Button variant="contained" onClick={handleAddNote}>
          Add note
        </Button>
      </Stack>

      <List sx={{ overflowY: "scroll" }}>
        <TransitionGroup>
          {user.notes &&
            user.notes.map((item, i) => (
              <Collapse key={i}>
                <ListItem
                  secondaryAction={
                    <IconButton
                      edge="end"
                      aria-label="delete"
                      title="Delete"
                      onClick={() => handleRemoveNote(i)}
                    >
                      <DeleteIcon />
                    </IconButton>
                  }
                >
                  {i + 1 + "."}
                  {
                    <ImageListItem>
                      <img
                        src={`${item.image.url}?w=248&fit=crop&auto=format`}
                        srcSet={`${item.image.url}?w=248&fit=crop&auto=format&dpr=2 2x`}
                        alt={item.note}
                        loading="lazy"
                      />
                      <ImageListItemBar title={item.note} />
                    </ImageListItem>
                  }
                </ListItem>
                <Divider />
              </Collapse>
            ))}
        </TransitionGroup>
      </List>
    </div>
  );
}

export default TextEditor;

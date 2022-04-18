import React, { useState } from "react";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Collapse from "@mui/material/Collapse";
import IconButton from "@mui/material/IconButton";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";
import DeleteIcon from "@mui/icons-material/Delete";
import { TransitionGroup } from "react-transition-group";
import { getDatabase, ref, get, update, child } from "firebase/database";
import { useAppSelector, useAppDispatch } from "../../../redux/Hooks";
import { setUser } from "../../../redux/slices/UserSlice";
import { Divider, ListItemIcon, Stack } from "@mui/material";

function TextEditor({}) {
  const [input, setInput] = useState("");
  const dispatch = useAppDispatch();
  
  const token = useAppSelector((state) => state.tokenSlice.token);
  const user = useAppSelector((state) => state.userSlice.user);

  async function handleAddNote() {
    if (token) {
      const newNotes = [...(user.notes ?? []), input];
      try {
        update(ref(getDatabase(), "users/" + token.localId), {
          notes: newNotes,
        });

        dispatch(setUser({ ...user, notes: newNotes }));

        setInput("");
      } catch (error) {
        console.log(error);
      }
    }
  }

  function handleRemoveNote(index) {
    if (token) {
      const newNotes = user.notes.filter((a, i) => i !== index);
      try {
        update(ref(getDatabase(), "users/" + token.localId), {
          notes: newNotes,
        });

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
        <Button variant="contained" onClick={handleAddNote}>
          Add note
        </Button>
      </Stack>

      <List>
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
                  <li>
                    {i + 1 + "."} {item}
                  </li>
                </ListItem>
              </Collapse>
            ))}
        </TransitionGroup>
      </List>
    </div>
  );
}

export default TextEditor;

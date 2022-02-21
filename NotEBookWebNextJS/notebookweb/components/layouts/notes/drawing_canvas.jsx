import { SettingsBackupRestoreOutlined } from "@material-ui/icons";
import React, { useRef, useState, useEffect, nativeEvent } from "react";
import {
  Form,
  FormControl,
  Button,
  Row,
  Col,
  InputGroup,
  Container,
  FormGroup,
  Dropdown,
  ButtonGroup,
} from "react-bootstrap";

export default function DrawingComponent() {
  const canvasRef = useRef(null);
  const contextRef = useRef(null);
  const [isDrawing, setIsDrawing] = useState(false);
  const [cursor, setCursor] = useState("");

  //const [canvasFile, setCanvasUploadFile] = useState([]);
  const [imgName, setImgName] = useState("");
  const [fileType, setFileType] = useState("");

  const fileTypes = ["jpg", "png", "pdf"];

  useEffect(() => {
    const canvas = canvasRef.current;
    canvas.width = window.innerWidth * 1.5;
    canvas.height = window.innerHeight * 1.5;
    canvas.style.width = `${window.innerWidth * 0.75}px`;
    canvas.style.height = `${window.innerHeight * 0.75}px`;

    const context = canvas.getContext("2d");
    context.scale(2, 2);
    context.lineCap = "round";
    context.strokeStyle = "#2a2a29";
    context.lineWidth = 5;
    contextRef.current = context;
  }, []);

  const startDrawing = ({ nativeEvent }) => {
    const { offsetX, offsetY } = nativeEvent;
    contextRef.current.beginPath();
    contextRef.current.moveTo(offsetX, offsetY);
    setIsDrawing(true);
  };

  const finishDrawing = () => {
    contextRef.current.closePath();
    setIsDrawing(false);
  };

  const draw = ({ nativeEvent }) => {
    if (!isDrawing) {
      return;
    }

    const { offsetX, offsetY } = nativeEvent;
    contextRef.current.lineTo(offsetX, offsetY);
    contextRef.current.stroke();
  };

  const clearCanvas = () => {
    const canvas = canvasRef.current;
    const context = canvas.getContext("2d");
    context.fillStyle = "#f9f9f9";
    context.lineWidth = 5;
    context.globalAlpha = 1;
    context.fillRect(0, 0, canvas.width, canvas.height);
    setCursor("nb__pen");
  };

  const useInk = () => {
    const canvas = canvasRef.current;
    const context = canvas.getContext("2d");
    context.strokeStyle = "#2a2a29";
    context.lineWidth = 5;
    context.globalAlpha = 1;
    setCursor("nb__pen");
  };

  /*Need to fix highlighter--not transparent */
  const useHighlighter = () => {
    const canvas = canvasRef.current;
    const context = canvas.getContext("2d");
    context.strokeStyle = "rgb(255,255,0,0.7)";
    context.fillStyle = "rgb(255,255,0,0.7)";
    context.lineWidth = 20;
    context.globalAlpha = 0.05;
    setCursor("nb__highlighter");
  };

  const useEraser = () => {
    const canvas = canvasRef.current;
    const context = canvas.getContext("2d");
    context.strokeStyle = "#f9f9f9";
    context.lineWidth = 10;
    context.globalAlpha = 1;
    setCursor("nb__eraser");
  };

  //In Development
  const saveCanvas = () => {};

  const downloadCanvas = () => {
    if (imgName != "") {
      const canvas = canvasRef.current;
      const context = canvas.getContext("2d");
      const image = canvas.toDataURL();
      const link = document.createElement("a");
      link.href = image;
      link.download = `${imgName}.${fileType}`;
      link.fileType;
      link.click();
    }
  };

  const handleFileName = (event) => {
    event.preventDefault();
    setImgName(event.target.value);
  };

  const uploadCanvas = (event) => {
    event.preventDefault();
    const canvas = canvasRef.current;
    const context = canvas.getContext("2d");

    const reader = new FileReader();
    const img = new Image();

    reader.onload = () => {
      img.onload = () => {
        context.drawImage(img, 0, 0);
      };
      img.src = reader.result;
      console.log(reader.result);
    };

    reader.readAsDataURL(event.target.files[0]);
  };

  function handleFileType(fType){
    setFileType(fType);

  }

  function getFileTypeStyle(fType){
    if(fType === fileType) return "selected__type";
    return "";
  }

  return (
    <div className={cursor}>
      <div className="drawing__functions">
        <button id="ink" className="draw__btn" onClick={useInk}>
          Draw
        </button>
        <button id="highlight" className="draw__btn" onClick={useHighlighter}>
          Highlight
        </button>
        <button id="erase" className="draw__btn" onClick={useEraser}>
          Erase
        </button>

        <button id="clear" className="draw__btn" onClick={clearCanvas}>
          Clear
        </button>
      </div>
      <canvas
        onMouseDown={startDrawing}
        onMouseUp={finishDrawing}
        onMouseMove={draw}
        ref={canvasRef}
        style={{ border: "2px solid white" }}
      ></canvas>

      <Container>
        <Row md={10}>
          {/* <Col md={1}>
                        <Button variant="primary" onClick={saveCanvas}>Save</Button>
                    </Col> */}

          <Col md={6}>
            <InputGroup>
              <InputGroup.Text>File Name</InputGroup.Text>
              <FormControl
                md={3}
                aria-label="Small"
                aria-describedby="inputGroup-sizing-sm"
                onChange={handleFileName}
              />

              <Dropdown as={ButtonGroup}>
                <Button md={1} variant="info" onClick={downloadCanvas}>
                  Download
                </Button>

                <Dropdown.Toggle
                  split
                  variant="info"
                  id="dropdown-split-basic"
                />

                <Dropdown.Menu>
                    {fileTypes.map(type => <Dropdown.Item className={getFileTypeStyle(type)} onClick={() => handleFileType(type)}>{type}</Dropdown.Item>)}
                </Dropdown.Menu>
              </Dropdown>
            </InputGroup>
          </Col>

          <Col md={6}>
            <InputGroup>
              <Form.Control
                type="file"
                accept="image/*"
                onChange={uploadCanvas}
              />
            </InputGroup>
          </Col>
        </Row>
      </Container>
    </div>
  );
}

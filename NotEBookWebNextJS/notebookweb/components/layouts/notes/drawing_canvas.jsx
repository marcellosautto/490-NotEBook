import { SettingsBackupRestoreOutlined } from "@material-ui/icons";
import React, { useRef, useState, useEffect, nativeEvent } from "react";
import { Form, FormControl, Button, Row, Col, InputGroup, Container, FormGroup } from "react-bootstrap";



export default function DrawingComponent() {

    const canvasRef = useRef(null);
    const contextRef = useRef(null);
    const [isDrawing, setIsDrawing] = useState(false);
    const [cursor, setCursor] = useState('');


    //const [canvasFile, setCanvasUploadFile] = useState([]);
    const [imgName, setImgName] = useState('');

    useEffect(() => {
        const canvas = canvasRef.current;
        canvas.width = window.innerWidth * 1.5;
        canvas.height = window.innerHeight * 1.5;
        canvas.style.width = `${window.innerWidth * 0.75}px`;
        canvas.style.height = `${window.innerHeight * 0.75}px`;

        const context = canvas.getContext("2d");
        context.scale(2, 2);
        context.lineCap = "round";
        context.strokeStyle = "white"
        context.lineWidth = 5;
        contextRef.current = context;
    }, [])

    const startDrawing = ({ nativeEvent }) => {
        const { offsetX, offsetY } = nativeEvent;
        contextRef.current.beginPath();
        contextRef.current.moveTo(offsetX, offsetY);
        setIsDrawing(true);
    }

    const finishDrawing = () => {
        contextRef.current.closePath();
        setIsDrawing(false);
    }

    const draw = ({ nativeEvent }) => {
        if (!isDrawing) { return }

        const { offsetX, offsetY } = nativeEvent;
        contextRef.current.lineTo(offsetX, offsetY);
        contextRef.current.stroke();
    }

    const clearCanvas = () => {
        const canvas = canvasRef.current;
        const context = canvas.getContext("2d")
        context.fillStyle = "#282c34"
        context.fillRect(0, 0, canvas.width, canvas.height)
    }

    const useInk = () => {
        const canvas = canvasRef.current;
        const context = canvas.getContext("2d");
        context.strokeStyle = "white";
        context.lineWidth = 5;
        setCursor("nb__pen");
    }

    /*Need to fix highlighter--not transparent */
    const useHighlighter = () => {
        const canvas = canvasRef.current;
        const context = canvas.getContext("2d");
        context.strokeStyle = 'rgb(255,255,0,0.7)';
        context.filStyle = 'rgb(255,255,0,0.7)';
        context.lineWidth = 10;
        setCursor("nb__highlighter");
    }

    const useEraser = () => {
        const canvas = canvasRef.current;
        const context = canvas.getContext("2d");
        context.strokeStyle = "#282c34";
        context.lineWidth = 10;
        setCursor("nb__eraser");
    }

    //In Development
   const saveCanvas = () => {

   }

    const downloadCanvas = () => {
        const canvas = canvasRef.current;
        const context = canvas.getContext("2d");
        const image = canvas.toDataURL();
        const link = document.createElement("a");
        link.href = image;
        link.download = `${imgName}.jpg`;
        link.click();
    }

    const handleFileName = (event) => {
        event.preventDefault();
        setImgName(event.target.value);
    }

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

    return (
        <div className={cursor}>
            <div className="drawing__functions">
                <button id="ink" className="draw__btn" onClick={useInk}>Draw</button>
                <button id="highlight" className="draw__btn" onClick={useHighlighter}>Highlight</button>
                <button id="erase" className="draw__btn" onClick={useEraser}>Erase</button>
            </div>
            <canvas
                onMouseDown={startDrawing}
                onMouseUp={finishDrawing}
                onMouseMove={draw}
                ref={canvasRef}
                style={{ border: "2px solid white" }}
            ></canvas>

            <Container>
                <Row md={12}>

                {/* <Col md={1}>
                        <Button variant="primary" onClick={saveCanvas}>Save</Button>
                    </Col> */}

                    <Col md={5}>
                        <InputGroup>
                            <InputGroup.Text>File Name</InputGroup.Text>
                            <FormControl md={3} aria-label="Small" aria-describedby="inputGroup-sizing-sm" onChange={handleFileName} />
                            <Button md={1} variant="info" onClick={downloadCanvas}>Save</Button>
                        </InputGroup>
                    </Col>

                    <Col md={4}>
                        <InputGroup>
                            <Form.Control type="file" accept="image/*" onChange={uploadCanvas} />
                        </InputGroup>
                    </Col>

                    <Col md={2}>
                        <Button variant="outline-info" onClick={clearCanvas}>Clear Canvas</Button>
                    </Col>
                </Row>

            </Container>
        </div>
    );
}
import React, {useRef, useState, useEffect, nativeEvent} from "react";
//import context from "react-bootstrap/esm/AccordionContext";
import styles from "../../../styles/Home.module.css"

export default function DrawingComponent() {

    const canvasRef = useRef(null);
    const contextRef = useRef(null);
    const [isDrawing, setIsDrawing] = useState(false);

    useEffect(() => {
        const canvas = canvasRef.current;
        canvas.width = window.innerWidth*1.5;
        canvas.height = window.innerHeight*1.5;
        canvas.style.width = `${window.innerWidth*0.75}px`;
        canvas.style.height = `${window.innerHeight*0.75}px`;

        const context = canvas.getContext("2d");
        context.scale(2, 2);
        context.lineCap = "round";
        context.strokeStyle = "white"
        context.lineWidth = 5;
        contextRef.current = context;
    }, [])

    const startDrawing = ({nativeEvent}) => {
        const { offsetX, offsetY } = nativeEvent;
        contextRef.current.beginPath();
        contextRef.current.moveTo(offsetX, offsetY);
        setIsDrawing(true);
    }

    const finishDrawing = () => {
        contextRef.current.closePath();
        setIsDrawing(false);
    }

    const draw = ({nativeEvent}) => {
        if (!isDrawing) { return }

        const { offsetX, offsetY } = nativeEvent;
        contextRef.current.lineTo(offsetX, offsetY);
        contextRef.current.stroke();
    }

    return (
        <canvas
            onMouseDown={startDrawing}
            onMouseUp={finishDrawing}
            onMouseMove={draw}
            ref={canvasRef}
            style={{border: "2px solid white"}}
        ></canvas>
    );
}
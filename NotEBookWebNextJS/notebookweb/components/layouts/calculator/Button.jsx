import React from "react";
import { Col } from "react-bootstrap";
import BodyStyle from "./styles/CalculatorStyle.module.css";

export default function Button({ className, onClick, number }) {
    return (
        <button className={className} onClick={onClick}>
            {number}
        </button>
    );

}
import React from "react";
import { Container } from "react-bootstrap";
import BodyStyle from "./styles/CalculatorStyle.module.css";

export default function Body({value}){
    return(
        <Container className={BodyStyle.calc_screen} fluid>
            {value}
        </Container>
    );
}

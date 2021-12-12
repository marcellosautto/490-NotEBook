import React, { useState } from "react";
import { Container, Row, Col, Badge } from "react-bootstrap";
import styles from "../../../styles/Home.module.css";
import CalculatorStyle from "./styles/CalculatorStyle.module.css"
import Screen from "./Screen";
import Button from "./Button";
import ButtonBox from "./ButtonBox";
import CalcHandler from "./Handler";

export default function CalculatorComponent() {

    const buttonValues = [
        [7, 8, 9, String.fromCharCode(247), "C", "del", "f(x)", "sin(x)"],
        [4, 5, 6, "*", "^", "π", String.fromCharCode(8730), "cos(x)"],
        [1, 2, 3, "-", "(", ")", "ln", "tan(x)"],
        [0, ".", "=", "+", "%", "!", "mod", "ans"]
    ];

    const [calc, setCalc] = useState({
        currNum: 0,
        op: "",
        prevNum: 0,
        result: 0
    });

    const handleButtonClick = (b) => {
        setCalc(CalcHandler(b, calc.currNum, calc.op, calc.prevNum, calc.result));
    }

    return (
        <Container className={CalculatorStyle.calc_body} fluid="xs">
            <Screen value={calc.result} />
            <ButtonBox>
                {
                    buttonValues.map((btnRow) => {

                        return (<Row>
                            {
                                btnRow.map((btn, n) => {
                                    return (
                                        <Col xs={3} md={3} lg="auto" fluid>{
                                            <Button
                                                key={n}
                                                className={CalculatorStyle.calc_button}
                                                number={btn}
                                                onClick={() => handleButtonClick(btn)}
                                            />
                                        }</Col>
                                    );
                                })
                            }</Row>)
                    })
                }
            </ButtonBox>
        </Container>
    );
}

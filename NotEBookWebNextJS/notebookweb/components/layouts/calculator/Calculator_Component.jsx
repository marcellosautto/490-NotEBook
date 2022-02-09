import React from "react";
import { Container, Row, Col, Button, Badge} from "react-bootstrap";
import styles from "../../../styles/Home.module.css";
export default function Calculator_Component() {
 
    
    return (
        <div className="App-header">

            <Container className={styles.calculator_body}>

                <input type="text" className={styles.answer_box} placeholder="2 + 2 = 4"></input>
                <Row className={styles.calculator_row}>
                    <Col><Button variant="info" className={styles.calculator_row}>9</Button></Col>
                    <Col><Button variant="info" className={styles.calculator_row}>8</Button></Col>
                    <Col><Button variant="info" className={styles.calculator_row}>7</Button></Col>
                    <Col><Button variant="info" className={styles.calculator_row}>+</Button></Col>
                </Row>

                <Row className={styles.calculator_row}>
                    <Col><Button variant="info" className={styles.calculator_row}>6</Button></Col>
                    <Col><Button variant="info" className={styles.calculator_row}>5</Button></Col>
                    <Col><Button variant="info" className={styles.calculator_row}>4</Button></Col>
                    <Col><Button variant="info" className={styles.calculator_row}>-</Button></Col>
                </Row>

                <Row className={styles.calculator_row}> 
                    <Col><Button variant="info" className={styles.calculator_row}>3</Button></Col>
                    <Col><Button variant="info" className={styles.calculator_row}>2</Button></Col>
                    <Col> <Button variant="info" className={styles.calculator_row}>1</Button></Col>
                    <Col><Button variant="info" className={styles.calculator_row}>x</Button></Col>
                </Row>

                <Row className={styles.calculator_row}> 
                    <Col><Button variant="info" className={styles.calculator_row}>.</Button></Col>
                    <Col><Button variant="info" className={styles.calculator_row}>x<sup>y</sup></Button></Col>
                    <Col> <Button variant="info" className={styles.calculator_row}>0</Button></Col>
                    <Col><Button variant="info" className={styles.calculator_row}>{String.fromCharCode(247)}</Button></Col>
                </Row>

                <Row className={styles.calculator_row}> 
                    <Col></Col>
                    <Col></Col>
                    <Col> <Button variant="outline-primary">Clear</Button></Col>
                    <Col><Button variant="primary">=</Button></Col>
                </Row>
            </Container>
        </div>
    );
}

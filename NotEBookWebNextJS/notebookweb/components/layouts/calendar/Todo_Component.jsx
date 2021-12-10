import React from "react";
import { Container, ListGroup, Row, Col, Button, FormControl, InputGroup, DatePicker } from "react-bootstrap";
import styles from '../../../styles/Home.module.css'
import { useState, useEffect } from "react";
import moment from "moment";
//helper functions
import dayStyles from "./styles";

export default function Todo_Component({ value, onChangeValue }) {

    const [todo, setTodoList] = useState([]);
    const [date, setDate] = useState(moment());
    const [input, setInput] = useState('');

    const handleChangeEvent = (e) => {
        e.preventDefault();

        setInput(e.target.value);
    }

    const handleChangeDate = (e) => {
        e.preventDefault();
        setDate(e.target.value);
    }

    const handleChangeTime = (e) => {
        e.preventDefault();
        setTime(e.target.value);
    }

    const handleSubmit = (e) => {
        e.preventDefault();

        if(date && input)
            setTodoList([[date, input, ...todo]]);

        //dayStyles(date, value);

    }

    return (
        <Container>
            <Row className={styles.todo_title}>
                <Col md={7} lg={7} >Agenda</Col>
                <Col md={2} lg={2}><Button variant="primary" onClick={handleSubmit}>Add</Button></Col>
                <Col md={2} lg={2}><Button variant="secondary" disabled>Remove</Button></Col>
            </Row>


            <InputGroup>
                <InputGroup.Text>Date/Time</InputGroup.Text>
                <FormControl type="datetime-local" name='Event_Date' placeholder={value.format("MM/DD/YYYY")} onChange={handleChangeDate} />
            </InputGroup>

            <br />
        
            <InputGroup>
                <FormControl placeholder="Enter an event..." onChange={handleChangeEvent} />
            </InputGroup>

            <br />

            <h1 className={styles.todo_title}>Upcoming...</h1>
            <ListGroup>
                {
                    todo.map(item => <ListGroup.Item>{item}</ListGroup.Item>)
                }
            </ListGroup>
        </Container>
    );
}
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
    const [selected_todo, setSelectedTodo] = useState('')

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

        if(date && input){
            let formattedDate = moment(date).calendar();  
            let event = input + "--->" + formattedDate;
            setTodoList([[event,...todo]]);
        }
            

        //dayStyles(date, value);

    }

    const handleRemove = (e) => {
        e.preventDefault();

        for(var i = 0; i < todo.length; i++){
            if(todo[i] == selected_todo){
                todo.splice(i, 1);
            }
        }

    }

    return (
        <Container>
            <Row className={styles.todo_title}>
                <Col sm={7}>Agenda</Col>
                <Col sm={2}><Button variant="primary" onClick={handleSubmit}>Add</Button></Col>
                <Col sm={2}><Button variant="secondary" onClick={handleRemove}>Remove</Button></Col>
            </Row>


            <InputGroup>
                <InputGroup.Text>Date/Time</InputGroup.Text>
                <FormControl type="datetime-local" name='Event_Date' placeholder={value.format('MMMM Do YYYY, h:mm:ss a')} onChange={handleChangeDate} />
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
import React, { useState, useEffect } from "react";
import moment from "moment";
import styles from '../styles/Home.module.css'
import { Button, Container, Row, Col } from 'react-bootstrap';

import Calendar_Component from "../components/layouts/calendar/Calendar_Component.jsx";
import TodoComponent from "../components/layouts/calendar/Todo_Component.jsx";

export default function Calendar() {
    const [value, setValue] = useState(moment());

    return (
        <Container>
            <Row>
                <Col lg={7}>
                    <Calendar_Component value={value} onChange={setValue} />
                </Col>

                <Col lg={5}>
                    <TodoComponent value={value} onChangeValue={setValue}/>
                </Col>
            </Row>

        </Container>
    );
}


import React, {useState, useEffect} from "react";
import { Container, Row, Col, FloatingLabel, Form } from "react-bootstrap";
import MainLayout from "../components/layouts/MainLayout";

export default function NBDrive() {


   const handleChange = (e) => {
        e.preventDefault();

        setInput(e.target.value);
    }

    return (
        <Container>
            <h1>NBDrive</h1>
            <Row className="g-2">
                <Col>
                    <Form.Control
                        type="file"
                        required
                        name="file"
                        onChange={handleChange}
                        // isInvalid={!!errors.file}
                    />
                </Col>

                <Col md>
                    <FloatingLabel controlId="floatingSelectGrid" label="Works with selects">
                        <Form.Select aria-label="Floating label select example">
                            <option>Select From Recently Opened...</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                        </Form.Select>
                    </FloatingLabel>
                </Col>
            </Row>

        </Container>
    );
}


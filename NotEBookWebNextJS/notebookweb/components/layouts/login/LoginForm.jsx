import React from "react";
import Head from 'next/head'
import logo from '../../../assets/images/notebook.png';
import styles from '../../../styles/Home.module.css'
import Image from 'next/image'
import Link from 'next/link'
import { loginUser } from "../../../lib/auth";
import { Button, Form, Container, Row, Col, Nav, Navbar, NavDropdown } from 'react-bootstrap'

class LoginForm extends React.Component {
    state = {
        email: '',
        password: ''
    };

    handleChange = event => {
        this.setState({ [event.target.name]: event.target.value });
    }

    handleSubmit = event => {
        const {email, password} = this.state;
        event.preventDefault();
       
        loginUser(email,password);
    }

    render() {
        return (
                <Row style={{textAlign: "center"}}>
                    <Col xl="auto">
                        <Image src={logo} className={styles.logo} alt="logo" />
                        <p className={styles.title}>
                            NotEBook
                        </p>
                    </Col>

                    <Col xl="auto" className={styles.body}>
                        <form onSubmit={this.handleSubmit}>
                            <div>
                                <label className={styles.label}>Email Address</label><br/>
                                <input className={styles.input} type="email" placeholder="example@email.com" onChange={this.handleChange} />
                            </div>

                            <div>
                                <label className={styles.label}>Password</label><br/>
                                <input className={styles.input} type="password" placeholder="Password" onChange={this.handleChange}/>
                            </div>

                            <div className={styles.loginbuttons}>
                                <button type="submit" style={{ margin: "0% 5% 0% 0%" }}>Login</button>
                                <button type="#">Register</button>
                            </div>
                        </form>
                    </Col>
                </Row>

        );
    }
}

export default LoginForm;
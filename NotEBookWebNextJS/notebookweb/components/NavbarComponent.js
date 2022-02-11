import logo from "../assets/images/notebook.png";
import React, { useState } from "react";
import {
  Button,
  Form,
  Container,
  Row,
  Col,
  Nav,
  Navbar,
  NavDropdown,
} from "react-bootstrap";
import Image from "next/image";
import Login from "../pages/Authentication/Login";
import styles from '../styles/Home.module.css'


export default function NavBarComponent() {
  const [opened, setOpened] = useState(false);

  return (
    <Navbar bg="light" expand="lg" className="justify-content-center">
      <Container>
        <Navbar.Brand href="/">
          <Image
            alt=""
            src={logo}
            width="30"
            height="30"
            className="d-inline-block align-top"
          />{" "}
          NotEBook
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link href="/">Home</Nav.Link>
            <Nav.Link href="/NBDrive">NBDrive</Nav.Link>
            <NavDropdown title="Tools" id="basic-nav-dropdown">
              <NavDropdown.Item href="/calendar">Calendar</NavDropdown.Item>
              <NavDropdown.Item href="/calculator">Calculator</NavDropdown.Item>
              <NavDropdown.Item href="/notes">Draw</NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href="#action/3.4">
                Separated link
              </NavDropdown.Item>
            </NavDropdown>
          </Nav>
          <button class={styles.login__button} onClick={() => setOpened(true)}>Sign In</button>
          {/* <Navbar.Text className="justify-content-end">
            Signed in as: <a href="/login">Willy Nobody</a>
          </Navbar.Text> */}
        </Navbar.Collapse>
      </Container>
      <Login opened={opened} setOpened={setOpened} />
    </Navbar>
  );
}

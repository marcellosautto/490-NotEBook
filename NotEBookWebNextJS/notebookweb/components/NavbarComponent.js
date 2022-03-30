import logo from "../assets/images/notebook.png";
import React, { useState, useEffect } from "react";
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
import { getDatabase, ref, child, get } from "firebase/database";

export default function NavBarComponent() {
  const [opened, setOpened] = useState(false);
  const [token, setToken] = useState(null);
  const [user, setUser] = useState(null);

  function handleLogout() {
    localStorage.removeItem("authToken");
    setToken(null);
    setUser(null);
  }

  async function getUser() {
    try {
      let authToken = JSON.parse(localStorage.getItem("authToken"));

      if (authToken) {
        const dbRef = ref(getDatabase());
        try {
          const user = await get(child(dbRef, `users/${authToken.localId}`));
          setUser(user.val());
          setToken(authToken.refreshToken);
        } catch (error) {
          console.log(error);
        }
      }
    } catch (err) {
      console.log("Error: ", err.message);
    }
  }

  useEffect(() => {
    getUser();
  }, [opened]);

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
          />
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

          {token ? (
            <div
              style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
              }}
            >
              <div style={{ marginRight: "15px" }}>
                {user.fname} {user.lname}
              </div>
              <button onClick={handleLogout}>Logout</button>
            </div>
          ) : (
            <button onClick={() => setOpened(true)}>Sign In</button>
          )}
          {/* <Navbar.Text className="justify-content-end">
            Signed in as: <a href="/login">Willy Nobody</a>
          </Navbar.Text> */}
        </Navbar.Collapse>
      </Container>
      <Login opened={opened} setOpened={setOpened} />
    </Navbar>
  );
}

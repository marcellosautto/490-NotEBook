import logo from '../assets/images/notebook.png';
import { Button, Form, Container, Row, Col, Nav, Navbar, NavDropdown } from 'react-bootstrap'
import Image from 'next/image'


export default function NavBarComponent() {
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
          />{' '}
          NotEBook</Navbar.Brand>
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
              <NavDropdown.Item href="#action/3.4">Separated link</NavDropdown.Item>
            </NavDropdown>
          </Nav>
          <Navbar.Text className="justify-content-end">
            Signed in as: <a href="/login">Willy Nobody</a>
          </Navbar.Text>
        </Navbar.Collapse>
      </Container>
    </Navbar>

  );
}


import React, { useState, useEffect } from "react";
import moment from "moment";
import styles from "../../../styles/Home.module.css";
import { Button, Container, Row, Col } from "react-bootstrap";

//helper functions
import buildCalendarComponent from "./build";
import dayStyles from "./styles";
import CalendarHeader from "./header";

export default function Calendar_Component({ value, onChange }) {
  const [calendar, setCalendar] = useState([]);

  const days_of_week = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

  useEffect(() => {
    setCalendar(buildCalendarComponent(value));
  }, [value]);

  return (
    <div className="App-header">
      <Container className={styles.calendar}>
        <CalendarHeader value={value} setValue={onChange} />

        <Row className={styles.week}>
          {days_of_week.map((day_name, i) => (
            <Col className={styles.week_days} key={i}>
              {day_name}
            </Col>
          ))}
        </Row>
        {calendar.map((week, i) => (
          <Row key={i}>
            {week.map((day, i2) => (
              <Col
                className={styles.day}
                onClick={() => onChange(day)}
                key={i2}
              >
                <div className={dayStyles(day, value)}>{day.format("D")}</div>
              </Col>
            ))}
          </Row>
        ))}
      </Container>
    </div>
  );
}

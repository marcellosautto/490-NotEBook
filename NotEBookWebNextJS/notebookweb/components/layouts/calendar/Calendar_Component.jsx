import React, { useState, useEffect } from "react";
import moment from "moment";
import styles from '../../../styles/Home.module.css'
import { Button, Container, Row, Col } from 'react-bootstrap';

//helper functions
import buildCalendarComponent from "./build";
import dayStyles from "./styles";
import CalendarHeader from "./header";

export default function Calendar_Component({ value, onChange }) {
    const [calendar, setCalendar] = useState([]);

    const days_of_week = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

    useEffect(() => {
        setCalendar(buildCalendarComponent(value));
    }, [value])


    return (
        <div className="App-header">

            <div className={styles.calendar}>
                <CalendarHeader value={value} setValue={onChange} />

                <div className={styles.week}>
                    {
                        days_of_week.map(day_name =>
                            <div className={styles.week_days}>{day_name}</div>)
                    }
                </div>
                {
                    calendar.map(week => <div className={styles.week}>
                        {
                            week.map(day =>
                                <div className={styles.day} onClick={() => onChange(day)}>
                                    <div className={dayStyles(day, value)}>
                                        {day.format("D")}
                                    </div>
                                </div>
                            )
                        }
                    </div>)
                }
            </div>
        </div>

    );
}


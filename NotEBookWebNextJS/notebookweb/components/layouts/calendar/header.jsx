import { Row, Col } from 'react-bootstrap';
import moment from "moment";
import styles from '../../../styles/Home.module.css'

export default function CalendarHeader({value, setValue}) {

    function currMonthName() {
        return value.format("MMMM");
    }

    function currYear() {
        return value.format("YYYY");
    }

    function prevMonth(){
        return value.clone().subtract(1, "month");
    }

    function nextMonth(){
        return value.clone().add(1, "month");
    }

    return (
        <div className={styles.calendar_header}>
            <div md={2} className={styles.previous_month} onClick={() => setValue(prevMonth())}>{String.fromCharCode(8249)}</div>
            <div md={7} lassName={styles.current_month}>{currMonthName()} {currYear()}</div>
            <div md={2} className={styles.next_month} onClick={() => setValue(nextMonth())}>{String.fromCharCode(8250)}</div>
        </div>

    );
}
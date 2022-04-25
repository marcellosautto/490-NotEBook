import styles from '../../../styles/Home.module.css'

function isSelected(day, value){
    return value.isSame(day, "day")
}

function beforeToday(day){
    return day.isBefore(new Date(), "day")
}

function isToday(day){
    return day.isSame(new Date(), "day")
}

function hasEvent(day, value){
    return value.isSame(day, "day")
}

export default function dayStyles(day, value){
    if(beforeToday(day)) return styles.before;
    if(isSelected(day, value)) return styles.selected_day;
    if(isToday(day)) return styles.today;
    if(hasEvent(day, value)) return styles.calendar_event;
    return "";
}
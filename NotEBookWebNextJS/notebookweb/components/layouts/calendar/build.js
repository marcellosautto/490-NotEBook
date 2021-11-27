import { calendarFormat } from "moment";

export default function buildCalendarComponent(value){

    const startDay = value.clone().startOf("month").startOf("week");
    const endDay = value.clone().endOf("month").startOf("week");
    const currentDay = startDay.clone().subtract(1, "day");
    const calendar = [];

    while (currentDay.isBefore(endDay, "day")) {
        calendar.push(
            Array(7).fill(0).map(() => currentDay.add(1, "day").clone())
        );
    }

    return calendar;
}
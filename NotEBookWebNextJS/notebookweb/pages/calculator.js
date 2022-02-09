import React from "react";
import MainLayout from "../components/layouts/MainLayout";
import styles from "../styles/Home.module.css"
import CalculatorComponent from "../components/layouts/calculator/CalculatorComponent";

export default function Calculator() {
    return (
        <div>
            <h1 className={styles.calculator_title}>Calculator</h1>
            <CalculatorComponent />
        </div>

    );
}

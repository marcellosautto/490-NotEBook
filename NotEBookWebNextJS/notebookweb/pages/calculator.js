import React from "react";
import MainLayout from "../components/layouts/MainLayout";
import styles from "../styles/Home.module.css"
import Calculator_Component from "../components/layouts/calculator/Calculator_Component";

export default function Calculator() {
    return (
        <div>
            <h1 className={styles.calculator_title}>Calculator</h1>
            <Calculator_Component />
        </div>

    );
}

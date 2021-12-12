import React from "react";
import CalculatorStyle from "./styles/CalculatorStyle.module.css";

export default function ButtonBox({children}){
    return(
        <div className={CalculatorStyle.calc_button_box}>
            {children}
        </div>
    );

}
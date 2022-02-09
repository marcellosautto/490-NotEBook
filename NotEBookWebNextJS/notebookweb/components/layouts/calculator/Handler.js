
export default function calcHandler(btn, nC, operation, nP, res) {

    const calc = {
        currNum: nC,
        op: operation,
        prevNum: nP,
        result: res
    }

    function handleComputation() {
        if (calc.currNum && calc.prevNum) {
            switch (operation) {
                case "+":
                    calc.result = parseInt(calc.prevNum) + parseInt(calc.currNum);
                    break;
                case "-":
                    calc.result = parseInt(calc.prevNum) - parseInt(calc.currNum);
                    break;
                case "*":
                    calc.result = parseInt(calc.prevNum) * parseInt(calc.currNum);
                    break;
                case String.fromCharCode(247):
                    calc.result = parseInt(calc.prevNum) / parseInt(calc.currNum);
                    break;
                case "^":
                    calc.result = Math.pow(parseInt(calc.prevNum), parseInt(calc.currNum));
                    break;
                case "%":
                    calc.result = (parseInt(calc.prevNum) / 100) * parseInt(calc.currNum);
                    break;
                case "mod":
                    calc.result = parseInt(calc.prevNum) % parseInt(calc.currNum);
                    break;
            }
        }

        return calc;
    }

    function handleResetScreen() {
        calc.currNum = 0;
        calc.op = "";
        calc.prevNum = 0;
        calc.result = 0;

        return calc;
    }

    function handleNum() {

        calc.currNum = nC == "" ? btn : nC.toString() + btn.toString();
        calc.result = calc.currNum;

        console.log(`${calc.prevNum} is previous.`);
        console.log(`${calc.op} is the operation.`);
        console.log(`${calc.currNum} is current.`);
        console.log(`${calc.result} is the result.`);

        return calc;
    }

    function handleOp() {
        if (calc.currNum === "") return calc;
        if (calc.prevNum !== "") handleComputation;

        calc.op = btn;
        calc.prevNum = calc.result;
        calc.currNum = "";
        console.log(`${calc.operation} is the operation.`);
        return calc;
    }

    if (btn == "C")
        return handleResetScreen;

    else if (btn == "=")
        return handleComputation;

    else if (btn == "+" || btn == "-" || btn == "*" || btn == String.fromCharCode(247) || btn == "^" || btn == String.fromCharCode(8730) || btn == "mod" || btn == "%")
        return handleOp;

        /*
    else if (btn == "ln")
        return handleLnOp;

    else if (btn == "π")
        return handlePi;

    else if (btn == "(")
        return handlePBeginOp;

    else if (btn == ")")
        return handlePEndOp;

    else if (btn == "!")
        return handleFactOp;

    else if (btn == "sin(x)")
        return handleSinOp;

    else if (btn == "cos(x)")
        return handleCosOp;

    else if (btn == "tan(x)")
        return handleTanOp;

    else if (btn == "ans")
        return handleAnsOp;

        */
    else {
        if (btn >= 0 && btn <= 9)
            return handleNum;
    }


}
// import "./SignIn.css";
import React, { useState } from "react";
import logo from "../../assets/images/notebook.png";
import Image from "next/image";

function SignIn(props) {
  const [email, setEmail] = useState("");
  const [emailValid, setEmailValid] = useState(true);
  const [password, setPassword] = useState("");
  const [passValid, setPassValid] = useState(true);
  const [checkMark, setCheckMark] = useState(false);
  const [focus, setFocus] = useState("");

  function handleSignIn(e) {
    handleValid(e, "all");
    console.log("Sign In!");
  }

  function handleValid(e, input) {
    if ((input !== focus && e.currentTarget === e.target) || input === "all") {
      if (focus === "email" || input === "all") {
        if (email.includes("@") && email.includes("mail.") && email !== "") {
          setEmailValid(true);
        } else {
          setEmailValid(false);
        }
      }
      if (focus === "password" || input === "all") {
        if (password === "") {
          setPassValid(false);
        } else {
          setPassValid(true);
        }
      }
      if (input !== null) {
        setFocus(input);
      }
    }
  }

  function handleCheckMark() {
    if (checkMark) {
      setCheckMark(false);
    } else {
      setCheckMark(true);
    }
  }

  return (
    <div className="signIn" onClick={(e) => handleValid(e, null)}>
      <div className="signIn__logo">
        <Image src={logo} alt="" />
      </div>
      <p className="signIn__title">
        YOUR ACCOUNT FOR
        <br />
        EVERYTHING NOTEBOOK
      </p>
      <input
        className={
          emailValid ? "signIn__input" : "signIn__input signIn__input--red"
        }
        type="text"
        placeholder="Email address"
        onChange={(e) => setEmail(e.target.value)}
        onClick={(e) => handleValid(e, "email")}
      />
      {!emailValid && (
        <p className="signIn__text-valid">
          Please enter a valid email address.
        </p>
      )}
      <input
        className={
          passValid ? "signIn__input" : "signIn__input signIn__input--red"
        }
        type="text"
        placeholder="Password"
        onChange={(e) => setPassword(e.target.value)}
        onClick={(e) => handleValid(e, "password")}
      />
      {!passValid && (
        <p className="signIn__text-valid">Please enter a password.</p>
      )}
      <div className="signIn__checkmark-container">
        <div className="signIn__box" onClick={handleCheckMark}>
          <div className="signIn__box-arrow">
            {checkMark && <div className="signIn__arrow"></div>}
          </div>
          <div className="signIn__text">Keep me signed in</div>
        </div>
        <div
          className="signIn__text signIn__text--light"
          onClick={() => props.setPageOpened("")}
        >
          Forgot password?
        </div>
      </div>
      <p className="signIn__text">
        By logging in, you agree to NotEBook's&nbsp;
        <a href="">Privacy Policy</a>
        &nbsp;and
        <br />
        <a href="">Terms of Use</a>.
      </p>
      <div className="signIn__button" onClick={handleSignIn}>
        SIGN IN
      </div>
      <p className="signIn__text signIn__text--margin">
        Not a member?&nbsp;
        <span onClick={() => props.setPageOpened("SignUp")}>Join Us.</span>
      </p>
    </div>
  );
}

export default SignIn;

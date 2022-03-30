import React, { useState } from "react";
import "react-datepicker/dist/react-datepicker.css";
import moment from "moment";
import DatePicker from "react-datepicker";
import { CountryDropdown } from "react-country-region-selector";
import logo from "../../assets/images/notebook.png";
import Image from "next/image";

import { createUserWithEmailAndPassword } from "firebase/auth";
import { auth } from "../../firebase/firebase-config";
import { getDatabase, ref, set } from "firebase/database";

function SignUp({ setOpened, setPageOpened }) {
  const [email, setEmail] = useState("");
  const [emailValid, setEmailValid] = useState(true);
  const [password, setPassword] = useState("");
  const [passValid, setPassValid] = useState(true);
  const [fName, setFName] = useState("");
  const [fNameValid, setFNameValid] = useState(true);
  const [lName, setLName] = useState("");
  const [lNameValid, setLNameValid] = useState(true);
  const [date, setDate] = useState(null);
  const [dateValid, setDateValid] = useState(true);
  const [country, setCountry] = useState("United States");
  const [gender, setGender] = useState("male");
  const [checkMark, setCheckMark] = useState(false);
  const [focus, setFocus] = useState("");

  async function handleSignUp(e) {
    if (handleValid(e, "all")) {
      try {
        const user = await createUserWithEmailAndPassword(
          auth,
          email,
          password
        );

        set(ref(getDatabase(), "users/" + user.user.uid), {
          fname: fName,
          lname: lName,
          date: date,
          country: country,
          gender: gender,
          notification: checkMark,
        });

        setOpened(false);
      } catch (error) {
        console.log(error);
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

  function handleCheckGender(gender) {
    setGender(gender);
  }

  function handleValid(e, input) {
    var valid = true;
    if ((input !== focus && e.currentTarget === e.target) || input === "all") {
      if (focus === "email" || input === "all") {
        if (email.includes("@") && email.includes("mail.") && email !== "") {
          setEmailValid(true);
        } else {
          setEmailValid(false);
          valid = false;
        }
      }
      if (focus === "password" || input === "all") {
        if (password === "" || password.length < 6) {
          setPassValid(false);
          valid = false;
        } else {
          setPassValid(true);
        }
      }
      if (focus === "fName" || input === "all") {
        if (fName === "") {
          setFNameValid(false);
          valid = false;
        } else {
          setFNameValid(true);
        }
      }
      if (focus === "lName" || input === "all") {
        if (lName === "") {
          setLNameValid(false);
          valid = false;
        } else {
          setLNameValid(true);
        }
      }
      if (focus === "date" || input === "all") {
        if (isValidDate(date)) {
          setDateValid(true);
        } else {
          setDateValid(false);
          valid = false;
        }
      }
      if (gender === "" && input === "all") {
        setGender(null);
      }

      if (input !== null) {
        setFocus(input);
      }
    }

    return valid;
  }

  function isValidDate(d) {
    return d instanceof Date && !isNaN(d);
  }

  return (
    <div className="signUp" onClick={(e) => handleValid(e, null)}>
      <div className="signUp__logo">
        <Image src={logo} alt="" />
      </div>
      <p className="signUp__title">
        BECOME A NOTEBOOK <br /> MEMBER
      </p>
      <p className="signUp__text signUp__text--sub-title">
        Create your NotEBook Member profile
      </p>
      <input
        className={
          emailValid ? "signUp__input" : "signUp__input signUp__input--red"
        }
        type="text"
        placeholder="Email address"
        onChange={(e) => setEmail(e.target.value)}
        onClick={(e) => handleValid(e, "email")}
      />
      {!emailValid && (
        <p className="signUp__text-valid">
          Please enter a valid email address.
        </p>
      )}

      <input
        className={
          passValid ? "signUp__input" : "signUp__input signUp__input--red"
        }
        type="text"
        placeholder="Password"
        onChange={(e) => setPassword(e.target.value)}
        onClick={(e) => handleValid(e, "password")}
      />
      {!passValid && (
        <p className="signUp__text-valid">Please enter a password.</p>
      )}

      <input
        className={
          fNameValid ? "signUp__input" : "signUp__input signUp__input--red"
        }
        type="text"
        placeholder="First Name"
        onChange={(e) => setFName(e.target.value)}
        onClick={(e) => handleValid(e, "fName")}
      />
      {!fNameValid && (
        <p className="signUp__text-valid">Please enter a valid first name.</p>
      )}

      <input
        className={
          lNameValid ? "signUp__input" : "signUp__input signUp__input--red"
        }
        type="text"
        placeholder="Last Name"
        onChange={(e) => setLName(e.target.value)}
        onClick={(e) => handleValid(e, "lName")}
      />
      {!lNameValid && (
        <p className="signUp__text-valid">Please enter a valid last name.</p>
      )}
      <div>
        <DatePicker
          className={
            dateValid ? "signUp__input" : "signUp__input signUp__input--red"
          }
          selected={date}
          placeholderText="Date of Birth"
          maxDate={moment().subtract(1, "day").toDate()}
          onChange={(date) => setDate(date)}
          onFocus={() => setFocus("date")}
          onClick={(e) => handleValid(e, "date")}
        />
      </div>
      {!dateValid && (
        <p className="signUp__text-valid">
          Please enter a valid date of birth.
        </p>
      )}
      <div className="signUp__text">
        Get a NotEBook Member Reward every year on your Birthday.
      </div>
      <CountryDropdown
        className="signUp__countryPicker"
        value={country}
        onChange={(value) => setCountry(value)}
        showDefaultOption={false}
      />

      <div className="signUp__gender-container">
        <div
          className={
            gender !== null
              ? gender === "male"
                ? "signUp__gender signUp__gender--selected"
                : "signUp__gender"
              : "signUp__gender signUp__input--red"
          }
          onClick={() => {
            handleCheckGender("male");
          }}
        >
          {gender === "male" && (
            <span className="signUp__arrow signUp__arrow--gender"></span>
          )}
          Male
        </div>
        <div
          className={
            gender !== null
              ? gender === "female"
                ? "signUp__gender signUp__gender--selected"
                : "signUp__gender"
              : "signUp__gender signUp__input--red"
          }
          onClick={() => {
            handleCheckGender("female");
          }}
        >
          {gender === "female" && (
            <span className="signUp__arrow signUp__arrow--gender"></span>
          )}
          Female
        </div>
      </div>

      {gender === null && (
        <p className="signUp__text-valid">Please select a preference.</p>
      )}

      <div className="signUp__box" onClick={handleCheckMark}>
        <div className="signUp__box-arrow">
          {checkMark && <div className="signUp__arrow"></div>}
        </div>
        <div className="signUp__text">
          Sign up for emails to get updates from NotEBook on
          <br />
          products, offers, and your Member benefits
        </div>
      </div>

      <p className="signUp__text signUp__text--center">
        By creating an account, you agree to
        <br />
        {/* NotEBook's <a href="">Privacy Policy</a> and <a href="">Terms of Use</a> */}
        .
      </p>

      <div className="signUp__button" onClick={handleSignUp}>
        JOIN US
      </div>

      <div className="signUp__text signUp__text--margin signUp__text--center">
        {/* Already a member?&nbsp; */}
        <span onClick={() => setPageOpened("SignIn")}>Sign In.</span>
      </div>
    </div>
  );
}

export default SignUp;

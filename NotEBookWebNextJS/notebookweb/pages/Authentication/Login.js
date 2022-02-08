// import "./Login.css";
// import "../../styles/Login.css";
import React, { useState } from "react";
import ClearIcon from "@material-ui/icons/Clear";
import SignIn from "./SignIn.js";
import SignUp from "./SignUp.js";
import ResetPass from "./ResetPass.js";

function Login({ opened, setOpened }) {
  const [pageOpened, setPageOpened] = useState("SignIn");
  function pages() {
    switch (pageOpened) {
      case "SignIn":
        return <SignIn setPageOpened={setPageOpened} />;
      case "SignUp":
        return <SignUp setPageOpened={setPageOpened} />;
      default:
        return <ResetPass setPageOpened={setPageOpened} />;
    }
  }
  return (
    <div className={opened ? "login" : "login login--hidden"}>
      <div
        className={
          opened
            ? "login__container"
            : "login__container login__container--hidden"
        }
      >
        <ClearIcon
          className="login__icon-close"
          onClick={() => setOpened(false)}
        />
        {pages()}
      </div>
    </div>
  );
}

export default Login;

import "../styles/globals.css";
import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import MainLayout from "../components/layouts/MainLayout";
import "../styles/Authentication/Login.css";
import "../styles/Authentication/SignIn.css";
import "../styles/Authentication/SignUp.css";
import "../styles/Authentication/ResetPass.css";
import "../styles/canvas.css"

function MyApp({ Component, pageProps }) {
  return (
    <MainLayout>
      <Component {...pageProps} />
    </MainLayout>
  );
}

export default MyApp;

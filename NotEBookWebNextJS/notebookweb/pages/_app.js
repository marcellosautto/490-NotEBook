import "../styles/globals.css";
import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import MainLayout from "../components/layouts/MainLayout";
import "../styles/Authentication/Login.css";
import "../styles/Authentication/SignIn.css";
import "../styles/Authentication/SignUp.css";
import "../styles/Authentication/ResetPass.css";
import "../styles/canvas.css";
import "../styles/texteditor.css";

import { Provider } from "react-redux";
import { store } from "../redux/Store";

function MyApp({ Component, pageProps }) {
  return (
    <Provider store={store}>
      <MainLayout>
        <Component {...pageProps} />
      </MainLayout>
    </Provider>
  );
}

export default MyApp;

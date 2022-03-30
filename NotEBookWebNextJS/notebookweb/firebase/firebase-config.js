// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getDatabase } from "firebase/database";
import { getAuth } from "firebase/auth";

const firebaseConfig = {
  apiKey: "AIzaSyBBBNirHxkXMc3xENG3lm7DSNMs_R5FmwQ",
  authDomain: "notebook-c7e67.firebaseapp.com",
  projectId: "notebook-c7e67",
  storageBucket: "notebook-c7e67.appspot.com",
  messagingSenderId: "446944292443",
  appId: "1:446944292443:web:b2711cd40b9f976a63197e",
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
const auth = getAuth(app);

export { auth };

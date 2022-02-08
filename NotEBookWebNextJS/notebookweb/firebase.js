// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getAnalytics } from "firebase/analytics";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

import firebase from "firebase";

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: "AIzaSyD0-xREoDHUuJxzKZPjxRP-iOZkt6-onB8",
  authDomain: "notebook-566fd.firebaseapp.com",
  projectId: "notebook-566fd",
  storageBucket: "notebook-566fd.appspot.com",
  messagingSenderId: "724738201233",
  appId: "1:724738201233:web:a73b0829766b601e521130",
  measurementId: "G-GWKCT5RPS5",
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
const analytics = getAnalytics(app);

export default firebase;

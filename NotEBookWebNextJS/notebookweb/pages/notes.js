import React from "react";
import Head from 'next/head'
import MainLayout from "../components/layouts/MainLayout";
import DrawingComponent from "../components/layouts/notes/drawing_canvas";
import styles from "../styles/Home.module.css"

export default function notes() {
    return (
        <div>
            <h1 className="canvas_title">Canvas</h1>
            <DrawingComponent />
        </div>);
}
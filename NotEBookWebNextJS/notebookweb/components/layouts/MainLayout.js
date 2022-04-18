import React from "react";
import NavBarComponent from "../NavbarComponent";
import styles from "../../styles/Home.module.css";

const MainLayout = ({ children }) => {
  return (
      <div>
        <NavBarComponent />

        <div className={styles.main}>{children}</div>
      </div>
    
  );
};
export default MainLayout;

import React from "react";
import { Link } from "react-router-dom";
import { NavBarData } from "./NavBarData";
import "./NavBar.css";

function NavBar() {
  return (
    <div className="menuBar">
      {NavBarData.map((item, index) => {
        return (
          <li key={index} className={item.cName}>
            <Link to={item.path}>
              {item.icon}
              <span>{item.title}</span>
            </Link>
          </li>
        );
      })}
    </div>
  );
}
export default NavBar;

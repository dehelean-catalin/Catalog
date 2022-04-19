import React from "react";
import { Link } from "react-router-dom";
import {NavBarDataTeacher} from './NavBarDataTeacher';
import "./NavBarTeacher.css"

function NavBarTeacher() {
  return (
    <div className="menuBarTeacher">
        {NavBarDataTeacher.map((item,index) =>{
           return (
              <li key={index} className={item.cName}>
                 <Link to={item.path}>
                  {item.icon}
                  <span>{item.title}</span>
                 </Link>
              </li>
           )
        })}
    </div>
  );
}
export default NavBarTeacher;

import React from "react";
import * as AiIcons from "react-icons/ai";
import * as IoIcons from "react-icons/io";
import * as BiIcons from "react-icons/bi";
import * as CgIcons from "react-icons/cg";
import * as RiIcons from "react-icons/ri";

export const NavBarData = [
	{
		title: "Profile",
		path: "/student/profile",
		icon: <CgIcons.CgProfile style={{ fontSize: "32px" }} />,
		cName: "nav-text",
	},
	{
		title: "Grades",
		path: "/student/grades",
		icon: <IoIcons.IoIosCreate style={{ fontSize: "32px" }} />,
		cName: "nav-text",
	},
	{
		title: "Settings",
		path: "/student/settings",
		icon: <AiIcons.AiFillSetting style={{ fontSize: "32px" }} />,
		cName: "nav-text",
	},

	{
		title: "Log out",
		path: "/",
		icon: <RiIcons.RiLogoutBoxRLine style={{ fontSize: "32px" }} />,
		cName: "nav-text",
	},
];

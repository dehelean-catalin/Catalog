import React, { useState } from "react";
import Teacher from "./Teacher";
import Student from "./Student";
import * as FiIcons from "react-icons/fi";
import "./welcome.css";

function Welcome() {
	const [studentIsOpen, setStudentIsOpen] = useState();
	const [teacherIsOpen, setTeacherIsOpen] = useState();

	return (
		<div className="welcome">
			<div className="welcome-text">
				<div className="catalog-text">Welcome to</div>
				<div className="online-text">Digital </div>
				<div className="online-text">Classroom</div>
			</div>

			<button
				className="navbar-button-student"
				onClick={() => {
					setStudentIsOpen(true);
					setTeacherIsOpen(false);
				}}
				style={{
					backgroundColor: studentIsOpen ? "white" : "rgba(0, 0, 0, 0.8)",
					color: studentIsOpen ? "rgb(24,29,82)" : "white",
					border: "0px",
				}}
			>
				Student
			</button>

			{studentIsOpen && <Student />}

			<button
				className="navbar-button-teacher"
				onClick={() => {
					setTeacherIsOpen(true);
					setStudentIsOpen(false);
				}}
				style={{
					backgroundColor: teacherIsOpen ? "white" : "rgba(0, 0, 0, 0.8)",
					color: teacherIsOpen ? "rgb(24,29,82)" : "white",
					border: "0px",
				}}
			>
				Teacher
			</button>
			{teacherIsOpen && <Teacher />}

			<FiIcons.FiHelpCircle className="help-icon" />
		</div>
	);
}

export default Welcome;

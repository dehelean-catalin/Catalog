import React from "react";
import NavBar from "./NavBar/NavBar";

import CardList from "./CardList";
import "./student.css";
function Grades() {
	const subjectGrades = JSON.parse(localStorage.getItem("grades"));
	const subjectList = JSON.parse(localStorage.getItem("subjectList"));
	return (
		<div className="grades">
			<NavBar />
			<div className="grades-container">
				{Object.keys(subjectList).length !== 0 && Object.keys(subjectGrades).length !== 0 && (
					<CardList subjectList={subjectList} subjectGrades={subjectGrades} />
				)}
			</div>
		</div>
	);
}

export default Grades;

import React, { useEffect, useState } from "react";
import NavBar from "./NavBar/NavBar";
import Axios from "axios";
import CardList from "./CardList";
import "./student.css";
function Grades() {
	const [subjectList, setSubjectList] = useState({});
	const [subjectGrades, setSubjectGrades] = useState({});

	useEffect(() => {
		const classId = JSON.parse(localStorage.getItem("studentClass"))["ClassId"];
		Axios.get(`https://localhost:44328/api/Classes/${classId}/Subjects`).then((response) => {
			setSubjectList(response.data);
		});
		const studentId = JSON.parse(localStorage.getItem("studentClass"))["Id"];
		Axios.get(`https://localhost:44328/student/${studentId}`).then((response) => {
			setSubjectGrades(response.data);
		});
	}, []);

	return (
		<div className="grades">
			<NavBar />
			<div className="grades-container">
				{Object.keys(subjectList).length != 0 && Object.keys(subjectGrades).length != 0 && (
					<CardList subjectList={subjectList} subjectGrades={subjectGrades} />
				)}
			</div>
		</div>
	);
}

export default Grades;

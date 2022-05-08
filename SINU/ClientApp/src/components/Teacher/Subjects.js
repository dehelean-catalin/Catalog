import React, { useEffect, useState } from "react";
import NavBarTeacher from "./NavBarTeacher/NavBarTeacher";
import List from "./List";
import Axios from "axios";
function Subjects() {
	const [subjectName, setSubjectName] = useState({});

	useEffect(() => {
		const id = JSON.parse(localStorage.getItem("userDetails"))["Id"];
		Axios.get(`https://localhost:44328/api/Teachers/${id}/Subjects`).then((response) => {
			localStorage.setItem("teacherSubjects", JSON.stringify(response.data));
			setSubjectName(response.data);
		});
	}, []);

	return (
		<div className="subjects">
			<NavBarTeacher />
			<div className="subjects-container">
				{Object.keys(subjectName).length !== 0 && <List subjectName={subjectName} />}
			</div>
		</div>
	);
}

export default Subjects;

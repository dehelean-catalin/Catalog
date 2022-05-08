import React, { useEffect, useState } from "react";
import Card1 from "./Card1";
import * as AiIcons from "react-icons/ai";
import Axios from "axios";

function StudentsList(props) {
	const [studentsList, setStudentsList] = useState({});
	const [gradesList, setGradesList] = useState({});
	useEffect(() => {
		Axios.get(`https://localhost:44328/api/Classes/${props.classId}/Students`).then((response) => {
			localStorage.setItem("students", JSON.stringify(response.data));
			setStudentsList(response.data);
		});
	}, []);

	useEffect(() => {
		Axios.get(`https://localhost:44328/api/Grades`).then((response) => {
			localStorage.setItem("grades", JSON.stringify(response.data));
			setGradesList(response.data);
		});
	}, []);

	const initialValue = "";
	const [inputValue, setInputValue] = useState(initialValue);

	const initialValue1 = "";
	const [inputValue1, setInputValue1] = useState(initialValue1);

	const [studentId, setStudentId] = useState();

	const initialValue2 = "";
	const [inputGrade, setInputGrade] = useState(initialValue2);

	const handleChange = (e) => {
		const { value } = e.target;
		setInputGrade(value);
		console.log(inputGrade);
		console.log(typeof inputGrade);
	};

	var grade = parseInt(inputGrade);
	const handleSubmit = () => {
		// console.log("student id:");
		// console.log(studentId);
		// console.log("grade:");
		// console.log(inputGrade);
		// console.log("prof id:");
		// console.log(props.subjectProfesorId);
		// console.log("subject id:");
		// console.log(props.subjectId);
		console.log(inputGrade);

		if (inputGrade && !isNaN(inputGrade) && grade > 1 && grade <= 10) {
			console.log("haha");
			Axios.post("https://localhost:44328/api/Grades", {
				studentId: studentId,
				grade: inputGrade,
				subjectId: props.subjectId,
				subjectProfesorId: props.subjectProfesorId,
			}).then((response) => {
				console.log(response.data);

				setInputGrade("");
				Axios.get(`https://localhost:44328/api/Grades`).then((response) => {
					localStorage.setItem("grades", JSON.stringify(response.data));
					setGradesList(response.data);
				});
			});
		}
	};
	var literaRomana;
	if (props.classId === 10) {
		literaRomana = "IX A";
	}
	if (props.classId === 11) {
		literaRomana = "IX B";
	}

	return (
		<div className="subjects-modal-students">
			<table className="subjects-modal-students-table">
				<caption>
					Clasa {literaRomana} ({props.subjectName})
				</caption>
				<thead>
					<tr>
						<th>Nume</th>
						<th>Prenume</th>
						<th>Grades</th>
					</tr>
				</thead>
				<tbody>
					{Object.keys(studentsList).length !== 0 &&
						studentsList.map((name, index) => (
							<tr
								key={index}
								onClick={() => {
									setInputValue(name.FirstName);
									setInputValue1(name.LastName);
									setStudentId(name.Id);
									console.log(inputValue);
									console.log(inputValue1);
								}}
							>
								<td>{name.FirstName}</td>
								<td>{name.LastName}</td>
								<td className="table-row">
									{Object.keys(gradesList).length !== 0 &&
										gradesList
											.filter((id) => id.SubjectId === props.subjectId && name.Id === id.StudentId)
											.map((id, index) => (
												<Card1
													key={index}
													id={id.Id}
													grade={id.Grade}
													profesorId={id.SubjectProfesorId}
													date={id.Date}
												/>
											))}
								</td>
							</tr>
						))}
				</tbody>
			</table>
			<div className="add-filds">
				<input type="text" className="add-input" value={inputValue} readOnly />
				<input type="text" className="add-input" value={inputValue1} readOnly />
				<input
					type="text"
					className="add-input"
					id="grade"
					name="grade"
					value={inputGrade}
					onChange={handleChange}
				></input>
				<AiIcons.AiFillPlusCircle
					className="add-button"
					title="Add Grade"
					onClick={handleSubmit}
					disabled={!inputValue || !inputValue1 || !inputGrade || isNaN(inputGrade) || grade > 10 || grade < 1}
				/>
			</div>
		</div>
	);
}

export default StudentsList;

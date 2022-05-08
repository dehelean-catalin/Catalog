import React, { useState } from "react";
import * as AiIcons from "react-icons/bs";
import * as FaIcons from "react-icons/fa";
import Axios from "axios";
function Card1(props) {
	console.log(props.date);
	const initialValues = {
		input: props.grade,
	};
	const [formValues, setFormValues] = useState(initialValues);

	const handleChange = (e) => {
		const { name, value } = e.target;
		setFormValues({ ...formValues, [name]: value });
		console.log(formValues);
	};

	const handleSubmit = (e) => {
		e.preventDefault();

		const userId = JSON.parse(localStorage.getItem("userDetails"))["Id"];
		Axios.put(`https://localhost:44328/api/Grades/${props.id}`, {
			grade: formValues.input,
			profesorUserId: userId,
		}).then((response) => {
			console.log(response.data);
			alert("Success");
		});
	};

	const deleteGrade = () => {
		const userId = JSON.parse(localStorage.getItem("userDetails"))["Id"];
		console.log(props.id);
		console.log(userId);
		Axios.delete("https://localhost:44328/api/Grades", {
			data: {
				gradeId: props.id,
				profesorUserId: userId,
			},
		}).then((response) => {
			console.log(response.data);
			window.location.reload();
		});
	};

	return (
		<div className="teacher-subjects-grade-container">
			<input
				type="text"
				className="teacher-subjects-grade"
				name="input"
				value={formValues.input}
				onChange={handleChange}
				title={props.date}
			/>

			<AiIcons.BsCheck type="submit" title="Submit Changes" className="edit" onClick={handleSubmit} />

			<FaIcons.FaTrashAlt type="submit" title="Delete Grade" className="delete" onClick={deleteGrade} />
		</div>
	);
}
export default Card1;

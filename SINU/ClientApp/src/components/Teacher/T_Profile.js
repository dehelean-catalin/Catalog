import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import NavBarTeacher from "./NavBarTeacher/NavBarTeacher";

import * as IoIosIcons from "react-icons/io";

import "../Teacher/teacher.css";
import Axios from "axios";

function T_Profile() {
	const [subjectNames, setSubjectNames] = useState({});

	const firstName = JSON.parse(localStorage.getItem("userDetails"))["FirstName"];
	const lastName = JSON.parse(localStorage.getItem("userDetails"))["LastName"];
	const mail = JSON.parse(localStorage.getItem("userDetails"))["Email"];
	const phone = JSON.parse(localStorage.getItem("userDetails"))["Phone"];
	const username = JSON.parse(localStorage.getItem("userDetails"))["Username"];
	useEffect(() => {
		const id = JSON.parse(localStorage.getItem("userDetails"))["Id"];
		Axios.get(`https://localhost:44328/api/Teachers/${id}/Subjects`).then((response) => {
			setSubjectNames(response.data);
		});
	}, []);

	if (Object.keys(subjectNames).length !== 0) {
		const yearsOfActivityCounter = subjectNames
			.map((dataItem) => dataItem.StudyYearName)
			.filter((subj, index, array) => array.indexOf(subj) === index); // filter out duplicates
		var yearsOfActivity = Object.keys(yearsOfActivityCounter).length;

		console.log(yearsOfActivityCounter);
	}
	if (Object.keys(subjectNames).length !== 0) {
		var subjname = subjectNames
			.map((dataItem) => dataItem.SubjectName)
			.filter((subj, index, array) => array.indexOf(subj) === index);
	}

	const [toogle, setToogle] = useState(true);
	const [toogle1, setToogle1] = useState(true);
	const [toogle2, setToogle2] = useState(true);
	console.log(subjname);
	return (
		<div className="teacher-profile">
			<NavBarTeacher />
			<div className="teacher-profile-container">
				<div className="teacher-profile-container-name">
					<div className="teacher-profile-details">
						<h1>
							{firstName} {lastName}
						</h1>
						<div className="edit-logout-buttons">
							<button className="teacher-edit-button">
								<Link className="Link" to={"/teacher/settings"}>
									Edit
								</Link>
							</button>
							<button className="teacher-edit-button">
								<Link className="Link" to={"/"}>
									Log out
								</Link>
							</button>
						</div>
					</div>
				</div>

				<details>
					<summary onClick={() => setToogle((toogle) => !toogle)}>
						User details
						{toogle ? <IoIosIcons.IoIosArrowDown className="arrow" /> : <IoIosIcons.IoIosArrowUp className="arrow" />}
					</summary>
					<div className="details-paragraph">
						<p style={{ margin: "0px" }}>Username:</p>
						<p className="details-paragraph-data">{username}</p>
					</div>
					<div className="details-paragraph">
						<p style={{ margin: "0px" }}>Email:</p>
						<p className="details-paragraph-data">{mail}</p>
					</div>
					<div className="details-paragraph">
						<p style={{ margin: "0px" }}>Phone:</p>
						<p className="details-paragraph-data">{phone}</p>
					</div>
				</details>

				<details>
					<summary onClick={() => setToogle1((toogle1) => !toogle1)}>
						Teacher Details{" "}
						{toogle1 ? <IoIosIcons.IoIosArrowDown className="arrow" /> : <IoIosIcons.IoIosArrowUp className="arrow" />}
					</summary>

					<div className="details-paragraph">
						<p style={{ margin: "0px" }}>Years of activity:</p>
						<p className="details-paragraph-data">{yearsOfActivity}</p>
					</div>
					<div className="details-paragraph">
						<p style={{ margin: "0px" }}>Teaching:</p>
						<div className="details-paragraph-data-list">
							{typeof subjname !== "undefined" &&
								subjname.map((item, index) => (
									<h5 style={{ margin: "2px" }} key={index}>
										{item}
									</h5>
								))}
						</div>
					</div>
				</details>
			</div>
		</div>
	);
}

export default T_Profile;

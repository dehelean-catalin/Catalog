import React, { useEffect, useState } from "react";
import NavBar from "./NavBar/NavBar";
import { Link } from "react-router-dom";
import * as IoIosIcons from "react-icons/io";
import "./student.css";
import Axios from "axios";

function Profile() {
	const className = JSON.parse(localStorage.getItem("studentClass"))["ClassName"];
	const studyYear = JSON.parse(localStorage.getItem("studentClass"))["StudyYearName"];
	const firstName = JSON.parse(localStorage.getItem("userDetails"))["FirstName"];
	const lastName = JSON.parse(localStorage.getItem("userDetails"))["LastName"];
	const mail = JSON.parse(localStorage.getItem("userDetails"))["Email"];
	const username = JSON.parse(localStorage.getItem("userDetails"))["Username"];
	const phone = JSON.parse(localStorage.getItem("userDetails"))["Phone"];
	const subjectGrades = JSON.parse(localStorage.getItem("grades"));

	const [toogle, setToogle] = useState(true);
	const [toogle1, setToogle1] = useState(true);
	const [toogle2, setToogle2] = useState(true);

	const gradesArray = [];

	useEffect(() => {
		const id = JSON.parse(localStorage.getItem("userDetails"))["Id"];
		Axios.get(`https://localhost:44328/api/Students/${id}`).then((response) => {
			localStorage.setItem("studentClass", JSON.stringify(response.data));

			const studentId = JSON.parse(localStorage.getItem("studentClass"))["Id"];
			Axios.get(`https://localhost:44328/student/${studentId}`).then((response) => {
				localStorage.setItem("grades", JSON.stringify(response.data));
			});
		});
	}, []);

	useEffect(() => {
		setTimeout(() => {
			const classId = JSON.parse(localStorage.getItem("studentClass"))["ClassId"];
			Axios.get(`https://localhost:44328/api/Classes/${classId}/Subjects`).then((response) => {
				localStorage.setItem("subjectList", JSON.stringify(response.data));
			});
		}, 1000);
	}, []);

	if (Object.keys(subjectGrades).length !== 0) {
		for (let i = 0; i < Object.keys(subjectGrades).length; i++) {
			gradesArray.push(subjectGrades[i].Grade);
		}
	}

	let average = (gradesArray.reduce((a, v) => (a = a + v), 0) / Object.keys(subjectGrades).length).toFixed(3);

	return (
		<div className="student-profile">
			<NavBar />
			<div className="student-profile-container">
				<div className="student-profile-container-name">
					<div className="circle">
						{" "}
						<input type="file" />
					</div>

					<div className="student-profile-details">
						<h1 style={{ margin: "0" }}>
							{firstName} {lastName}
						</h1>
						<div className="edit-logout-buttons">
							<button className="edit-button">
								<Link className="Link" to={"/student/settings"}>
									Edit
								</Link>
							</button>
							<button className="edit-button">
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
						<p className="details-paragraph-data" id="student">
							{username}
						</p>
					</div>
					<div className="details-paragraph">
						<p style={{ margin: "0px" }}>Email:</p>
						<p className="details-paragraph-data" id="student">
							{mail}
						</p>
					</div>
					<div className="details-paragraph">
						<p style={{ margin: "0px" }}>Phone:</p>
						<p className="details-paragraph-data  " id="student">
							+{phone}
						</p>
					</div>
				</details>

				<details>
					<summary onClick={() => setToogle1((toogle1) => !toogle1)}>
						Student Details{" "}
						{toogle1 ? <IoIosIcons.IoIosArrowDown className="arrow" /> : <IoIosIcons.IoIosArrowUp className="arrow" />}
					</summary>

					<div className="details-paragraph">
						<p style={{ margin: "0px" }}>Class:</p>
						<p className="details-paragraph-data" id="student">
							{className}
						</p>
					</div>
					<div className="details-paragraph">
						<p style={{ margin: "0px" }}>Study year:</p>
						<p className="details-paragraph-data" id="student">
							{studyYear}
						</p>
					</div>
				</details>

				<details>
					<summary onClick={() => setToogle2((toogle2) => !toogle2)}>
						Statistics
						{toogle2 ? <IoIosIcons.IoIosArrowDown className="arrow" /> : <IoIosIcons.IoIosArrowUp className="arrow" />}
					</summary>

					<div className="details-paragraph">
						<p style={{ margin: "0px" }}>Final average:</p>
						<p className="details-paragraph-data" id="student">
							{average}
						</p>
					</div>
				</details>
			</div>
		</div>
	);
}
export default Profile;

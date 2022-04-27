import React, { useEffect, useState } from "react";
import NavBarTeacher from "./NavBarTeacher/NavBarTeacher";
import * as BiIcons from "react-icons/bi";
import * as IoIosIcons from "react-icons/io";
import * as BsIcons from "react-icons/bs";
import * as MdIcons from "react-icons/md";
import "../Teacher/teacher.css";
import Axios from "axios";

function T_Profile() {
	const [subjectNames, setSubjectNames] = useState({});

	const id = JSON.parse(localStorage.getItem("userDetails"))["Id"];
	const firstName = JSON.parse(localStorage.getItem("userDetails"))["FirstName"];
	const lastName = JSON.parse(localStorage.getItem("userDetails"))["LastName"];
	const mail = JSON.parse(localStorage.getItem("userDetails"))["Email"];
	useEffect(() => {
		Axios.get(`https://localhost:44328/api/Teachers/${id}/Subjects`).then((response) => {
			setSubjectNames(response.data);
		});
	}, []);

	if (Object.keys(subjectNames).length !== 0) {
		const yearsOfActivityCounter = subjectNames
			.map((dataItem) => dataItem.StudyYearName)
			.filter((mediaType, index, array) => array.indexOf(mediaType) === index); // filter out duplicates
		var yearsOfActivity = Object.keys(yearsOfActivityCounter).length;

		const uniqueSubjects = subjectNames
			.map((dataItem) => dataItem.SubjectName)
			.filter((mediaType, index, array) => array.indexOf(mediaType) === index);
		var uSubject = uniqueSubjects;
	}

	return (
		<div className="profileContainer">
			<NavBarTeacher />
			<div className="cardContainer">
				<div className="cardTop">
					<div className="ProfilePic"></div>
				</div>

				<div className="cardButtom">
					<div className="cardDetails">
						<div className="grid-item">
							Mark
							<div className="line">
								<BiIcons.BiMedal style={{ fontSize: 30, color: "rgb(247,185,0)" }} />
							</div>
						</div>

						<div className="grid-item2">
							Subjects
							<div className="line">
								<IoIosIcons.IoIosSchool style={{ fontSize: 30, color: "red" }} />
								{typeof uSubject !== "undefined" &&
									uSubject.map((name) => <div style={{ display: "flex", flexDirection: "column" }}>{name}</div>)}
							</div>
						</div>

						<div className="grid-item">
							Years of Activity
							<div className="line">
								<BsIcons.BsCalendarDate style={{ fontSize: 28, color: "blue" }} />
								{yearsOfActivity}
							</div>
						</div>
					</div>
					<div className="studentName">
						{firstName} {lastName}
						<div className="studentEmail">
							{mail}
							<MdIcons.MdOutlineEmail style={{ fontSize: 28, color: "gray" }} />
						</div>
					</div>
				</div>
			</div>
		</div>
	);
}

export default T_Profile;

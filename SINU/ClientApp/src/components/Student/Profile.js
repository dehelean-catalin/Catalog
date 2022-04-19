import React, { useEffect, useState } from "react";
import NavBar from "./NavBar/NavBar";
import * as BiIcons from "react-icons/bi";
import * as IoIosIcons from "react-icons/io";
import * as BsIcons from "react-icons/bs";
import * as MdIcons from "react-icons/md";
import "./student.css";
import Axios from "axios";

function Profile() {
	const [className, setClassName] = useState("");
	const [studyYear, setStudyYear] = useState("");
	const id = JSON.parse(localStorage.getItem("userDetails"))["Id"];
	const firstName = JSON.parse(localStorage.getItem("userDetails"))["FirstName"];
	const lastName = JSON.parse(localStorage.getItem("userDetails"))["LastName"];
	const mail = JSON.parse(localStorage.getItem("userDetails"))["Email"];

	useEffect(() => {
		Axios.get(`https://localhost:44328/api/Students/${id}`).then((response) => {
			localStorage.setItem("studentClass", JSON.stringify(response.data));

			console.log("haha");
			setClassName(JSON.parse(localStorage.getItem("studentClass"))["ClassName"]);
			setStudyYear(JSON.parse(localStorage.getItem("studentClass"))["StudyYearName"]);
		});
	}, []);

	return (
		<div className="profileContainer">
			<NavBar />
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
							Class
							<div className="line">
								<IoIosIcons.IoIosSchool style={{ fontSize: 30, color: "red" }} />
								{className}
							</div>
						</div>

						<div className="grid-item">
							Study year
							<div className="line">
								<BsIcons.BsCalendarDate style={{ fontSize: 28, color: "blue" }} />
								{studyYear}
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
export default Profile;

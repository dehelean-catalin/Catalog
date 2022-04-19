import React from "react";
function Card(props) {
	return (
		<div className="grades-card">
			<img src={require(`./img/${props.subjectName}.png`)} alt="" width="60px" />
			<div className="grades-container-subject-name">{props.subjectName}</div>
			<div className="grades-container-teacher-name">
				{props.teacherFirstName} {props.teacherLastName}
				<div className="grades-container-marks">
					{props.grades.map((name) => (
						<div style={{ margin: "5px" }}>{name}</div>
					))}
				</div>
			</div>
		</div>
	);
}
export default Card;

import React from "react";
function Card(props) {
	return (
		<div className="grades-card">
			<img className="grades-png" src={require(`./img/${props.subjectName}.png`)} alt="" />
			<div className="grades-container-bakground-image" />
			<div className="grades-container-subject-name"> {props.subjectName}</div>
			<div className="grades-container-teacher-name">
				Teacher: {props.teacherFirstName} {props.teacherLastName}
			</div>
			<div className="grades-container-marks">
				Marks:
				{props.grades.map((name) => (
					<div
						style={{
							marginLeft: "5px",
							backgroundColor: "white",
							color: "black",
							fontSize: "14px",
							textAlign: "center",
							padding: "6px",
							fontWeight: "700",
							width: "16px",
						}}
					>
						{name}
					</div>
				))}
			</div>
		</div>
	);
}
export default Card;

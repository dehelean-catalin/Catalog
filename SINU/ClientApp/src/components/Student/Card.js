import React from "react";

function Card(props) {
	let average;
	props.grades.length >= 2
		? (average = (props.grades.reduce((a, v) => (a = a + v), 0) / props.grades.length).toFixed(2))
		: (average = 0);

	return (
		<div className="grades-card" style={props.grades.length === 0 ? { display: "none" } : {}}>
			<img className="grades-png" src={require(`./img/${props.subjectName}.png`)} alt="" />
			<div className="grades-container-bakground-image" />
			<div className="grades-container-subject-name"> {props.subjectName}</div>
			<div className="grades-container-teacher-name">
				Teacher: {props.teacherFirstName} {props.teacherLastName}
			</div>
			<div className="grades-container-marks">
				Marks:
				{props.grades.map((name, index) => (
					<div
						key={index}
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

			<div className="grades-container-finalAverege" style={average <= 0 ? { display: "none" } : {}}>
				Average:{" "}
				<p
					className="average"
					style={
						average >= 8.5
							? { color: "green" }
							: average <= 8.5 && average > 4.5
							? { color: "orange" }
							: { color: "red" }
					}
				>
					{average}
				</p>
			</div>
		</div>
	);
}
export default Card;

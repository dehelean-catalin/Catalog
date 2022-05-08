import React from "react";
import Card from "./Card";
const CardList = ({ subjectList, subjectGrades }) => {
	const cardsArray = subjectList.map((subject, index) => (
		<Card
			key={index}
			grades={subjectGrades
				.filter(function (grade) {
					return grade.SubjectId === subject.SubjectId;
				})
				.map(function (grade) {
					return grade.Grade;
				})}
			subjectName={subject.Name}
			teacherFirstName={subject.TeacherFirstName}
			teacherLastName={subject.TeacherLastName}
			subjectId_subjectList={subject.SubjectId}
		/>
	));

	return <div className="grid">{cardsArray}</div>;
};

export default CardList;

import React from "react";
import Item from "./Item";

const List = (subjectName) => {
	const cardsArray = subjectName.subjectName.map((subject, index) => (
		<Item
			key={index}
			subjectName={subject.SubjectName}
			classId={subject.ClassIds}
			subjectId={subject.SubjectId}
			subjectProfesorId={subject.SubjectProfesorId}
			className={subject.Number}
		/>
	));

	return <div className="settings-list">{cardsArray}</div>;
};

export default List;

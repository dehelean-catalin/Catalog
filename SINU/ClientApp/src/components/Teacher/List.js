import React from "react";
import Item from "./Item";

const List = (subjectName) => {
	const cardsArray = subjectName.subjectName.map((subject) => (
		<Item subjectName={subject.SubjectName} classId={subject.ClassIds} />
	));

	return <div className="settings-list">{cardsArray}</div>;
};

export default List;

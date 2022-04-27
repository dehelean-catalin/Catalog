import Axios from "axios";
import React, { useEffect, useState } from "react";
import StudentsList from "./StudentsList";
import Backdrop from "../First Page/Backdrop";
function Item(props) {
	const [letter, setLetter] = useState();
	const [number, setNumber] = useState();
	const [openModal, setOpenModal] = useState();

	return (
		<div className="settings-item">
			{props.subjectName}
			{props.classId.map((id) => (
				<button type="submit" onClick={() => (setNumber(id), setOpenModal(true))}>
					{id} {openModal && id === number && <StudentsList classId={number} />}
				</button>
			))}

			{openModal && <Backdrop onClick={() => setOpenModal(false)} />}
		</div>
	);
}
export default Item;

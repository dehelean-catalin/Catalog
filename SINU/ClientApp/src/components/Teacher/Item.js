import React, { useState } from "react";
import StudentsList from "./StudentsList";
import Backdrop from "../First Page/Backdrop";
function Item(props) {
	const [unicId, setUnicId] = useState();
	const [openModal, setOpenModal] = useState();
	const [subjId, setSubjId] = useState();

	return (
		<div className="settings-item">
			{props.subjectName}
			<p style={{ margin: "0" }}>
				{props.classId.map((id, index) => (
					<button
						className="settings-item-button"
						type="submit"
						key={index}
						onClick={() => (setSubjId(props.subjectId), setUnicId(id), setOpenModal(true))}
					>
						{id === 10
							? "IX A"
							: id === 11
							? "IX B"
							: id === 12
							? "IX C"
							: id === 13
							? "X A"
							: id === 14
							? "X B"
							: id === 16
							? "X C"
							: id === 17
							? "XI A"
							: id === 18
							? "XI B"
							: id === 19
							? "XI C"
							: id === 20
							? "XII A"
							: id === 21
							? "XII B"
							: id === 22
							? "XII C"
							: "error"}
						{openModal && id === unicId && (
							<StudentsList
								classId={unicId}
								subjectId={subjId}
								subjectProfesorId={props.subjectProfesorId}
								subjectName={props.subjectName}
							/>
						)}
					</button>
				))}
			</p>
			{openModal && <Backdrop onClick={() => setOpenModal(false)} />}
		</div>
	);
}
export default Item;

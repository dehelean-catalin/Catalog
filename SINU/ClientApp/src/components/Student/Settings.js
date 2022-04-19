import React, { useState } from "react";
import * as AiIcons from "react-icons/ai";
import NavBar from "./NavBar/NavBar";
import Modal from "./Modal";
import Backdrop from "../First Page/Backdrop";
function Settings() {
	const [editArea, setEditArea] = useState(false);

	const firstName = JSON.parse(localStorage.getItem("userDetails"))["FirstName"];
	const lastName = JSON.parse(localStorage.getItem("userDetails"))["LastName"];
	const idcnp = JSON.parse(localStorage.getItem("userDetails"))["IDNP"];
	const email = JSON.parse(localStorage.getItem("userDetails"))["Email"];
	const phoneNumber = JSON.parse(localStorage.getItem("userDetails"))["Phone"];
	const address = JSON.parse(localStorage.getItem("userDetails"))["Address"];
	const nationality = JSON.parse(localStorage.getItem("userDetails"))["Nationality"];

	return (
		<div className="settings">
			<NavBar />
			<div className="settings-container">
				<div className="settings-container-row">
					{firstName} {lastName}
				</div>

				<div className="settings-container-row">{idcnp}</div>

				<div className="settings-container-row">{email}</div>

				<div className="settings-container-row">{phoneNumber}</div>

				<div className="settings-container-row">{address}</div>

				<div className="settings-container-row">{nationality}</div>

				<button onClick={() => setEditArea(true)}>
					<AiIcons.AiFillEdit
						style={{
							cursor: "pointer",
						}}
					/>
				</button>
				{editArea && <Backdrop onClick={() => setEditArea(false)} />}
				{editArea && <Modal email={email} phone={phoneNumber} address={address} submit={setEditArea} />}
			</div>
		</div>
	);
}

export default Settings;

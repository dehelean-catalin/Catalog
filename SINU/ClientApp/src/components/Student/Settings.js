import React, { useState } from "react";
import * as MdIcons from "react-icons/md";
import NavBar from "./NavBar/NavBar";
import Modal from "./Modal";
import Backdrop from "../First Page/Backdrop";
function Settings() {
	const [editArea, setEditArea] = useState(false);
	if (localStorage.getItem("userDetails") === null) {
		console.log("aaaaa");
		window.location.href = "/";
	}
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
					<img className="settings-img" alt="" />
					<div className="settings-text1">Name</div>

					<div className="settings-text2">
						{firstName} {lastName}
					</div>
				</div>

				<div className="settings-container-row">
					<img className="settings-img" alt="" />
					<div className="settings-text1">Email</div>

					<div className="settings-text2">{email}</div>
				</div>

				<div className="settings-container-row">
					<img className="settings-img" alt="" />
					<div className="settings-text1">Id</div>

					<div className="settings-text2">{idcnp}</div>
				</div>

				<div className="settings-container-row">
					<img className="settings-img" alt="" />
					<div className="settings-text1">Phone</div>

					<div className="settings-text2">{phoneNumber}</div>
				</div>

				<div className="settings-container-row">
					<img className="settings-img" alt="" />
					<div className="settings-text1">Address</div>

					<div className="settings-text2">{address}</div>
				</div>
				<div className="settings-container-row">
					<img className="settings-img" alt="" />
					<div className="settings-text1">Nationality</div>
					<div className="settings-text2">{nationality}</div>
				</div>
				<button className="settings-button" onClick={() => setEditArea(true)}>
					<MdIcons.MdModeEditOutline
						style={{
							cursor: "pointer",
						}}
					/>
					Edit
				</button>

				{editArea && <Backdrop onClick={() => setEditArea(false)} />}
				{editArea && <Modal email={email} phone={phoneNumber} address={address} editArea={setEditArea} />}
			</div>
		</div>
	);
}

export default Settings;

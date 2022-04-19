import React, { useState } from "react";
import ModalRegister from "./ModalRegister";
import Backdrop from "./Backdrop";
import Modal from "./Modal";

function Student() {
	const [loginIsOpen, setLoginIsOpen] = useState();
	const [registerIsOpen, setRegisterIsOpen] = useState();
	return (
		<div className="student-card">
			<div className="student-card-text">
				Hi, <br />
				Let's check <br />
				What is new! <br />
			</div>

			<div className="student-card-buttons">
				<button className="student-card-button-login" onClick={() => setLoginIsOpen(true)}>
					Log in
				</button>
				{loginIsOpen && <Backdrop onClick={() => setLoginIsOpen(false)} />}
				{loginIsOpen && <Modal closeLogin={setLoginIsOpen} openSignUp={setRegisterIsOpen} />}

				<button className="student-card-button-signup" onClick={() => setRegisterIsOpen(true)}>
					Sign up
				</button>
				{registerIsOpen && <Backdrop onClick={() => setRegisterIsOpen(false)} />}
				{registerIsOpen && <ModalRegister closeSignUp={setRegisterIsOpen} openLogin={setLoginIsOpen} />}
			</div>
		</div>
	);
}

export default Student;

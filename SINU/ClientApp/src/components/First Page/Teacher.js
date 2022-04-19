import Backdrop from "./Backdrop";
import React, { useState } from "react";
import Modal from "./Modal";
import ModalRegister from "./ModalRegister";

function Teacher() {
  const [loginIsOpen, setLoginIsOpen] = useState();
  const [registerIsOpen, setRegisterIsOpen] = useState();

  return (
    <div className="teacher-card">
      <div className="student-card-text">
        Hi, <br />
        Let's check <br />
        What is new! <br />
      </div>

      <div className="student-card-buttons">
        <button className="teacher-card-button-login" onClick={() => setLoginIsOpen(true)}>
          Log in
        </button>
        {loginIsOpen && <Backdrop onClick={() => setLoginIsOpen(false)} />}
        {loginIsOpen && <Modal closeLogin={setLoginIsOpen} openSignUp={setRegisterIsOpen} />}

        <button className="teacher-card-button-signup" onClick={() => setRegisterIsOpen(true)}>
          Sign up
        </button>
        {registerIsOpen && <Backdrop onClick={() => setRegisterIsOpen(false)} />}
        {registerIsOpen && <ModalRegister closeSignUp={setRegisterIsOpen} openLogin={setLoginIsOpen} />}
      </div>
    </div>
  );
}
export default Teacher;

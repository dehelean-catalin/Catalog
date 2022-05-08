import React, { useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEye } from "@fortawesome/free-solid-svg-icons";
import { faEyeSlash } from "@fortawesome/free-solid-svg-icons";
import Axios from "axios";
import { useHistory } from "react-router-dom";

function Modal(props) {
	const initialValues = {
		email: "",
		password: "",
	};

	const [formValues, setFormValues] = useState(initialValues);
	const [formErrors, setFormErrors] = useState({});
	// const [isSubmit, setIsSubmit] = useState(false);
	const history = useHistory();

	const handleChange = (e) => {
		const { name, value } = e.target;
		setFormValues({ ...formValues, [name]: value });
		console.log(formValues);
	};

	const handleSubmit = (e) => {
		e.preventDefault();
		setFormErrors(validate(formValues));

		if (Object.keys(validate(formValues)).length === 0) {
			Axios.post("https://localhost:44328/api/login", {
				email: formValues.email,
				password: formValues.password,
			})
				.then((response) => {
					console.log(response.data);
					localStorage.setItem("userDetails", JSON.stringify(response.data));

					if (response.data.Role === "Student") {
						history.push("/student/profile");
					} else if (response.data.Role === "Teacher") {
						history.push("/teacher/profile");
					}
				})
				.catch((err) => {
					formErrors.password = "";
					formErrors.email = "";
					if (err.response.status === 400) {
						formErrors.password = err.response.data;
						console.log(err.response.data);
					} else if (err.response.status === 404) {
						formErrors.email = err.response.data;
						console.log(err.response.data);
					} else {
						console.log("haha");
					}

					setFormErrors(formErrors);
				});
		}
	};

	const validate = (values) => {
		const errors = {};
		const regex = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/i;
		if (!regex.test(values.email)) {
			errors.email = "Invalid format!";
		}
		return errors;
	};

	// useEffect(() => {
	// 	if (isSubmit) {
	// 		handleSubmit();
	// 	}
	// }, [isSubmit]);

	const usePasswordToggle = () => {
		const [visible, setVisiblity] = useState(false);

		const Icon = (
			<FontAwesomeIcon
				icon={visible ? faEye : faEyeSlash}
				onClick={() => setVisiblity((visiblity) => !visiblity)}
				style={{ fontSize: "22px", color: "gray" }}
			/>
		);
		const InputType = visible ? "text" : "password";
		return [InputType, Icon];
	};
	const [PasswordInputType, ToogleIcon] = usePasswordToggle();

	return (
		<div className="modal">
			<form>
				<div className="modal-title">Login</div>

				<div className="inputField">
					<h2 className="firstPage-modal-error">{formErrors.email}</h2>
					<input
						type="text"
						className="inputModal"
						placeholder="Email"
						name="email"
						value={formValues.email}
						onChange={handleChange}
						style={{ borderColor: formErrors.email ? "red" : "" }}
					/>
					<h1 className="firstPage-modal-text">Email</h1>
				</div>
				<div className="inputField">
					<h2 className="firstPage-modal-error">{formErrors.password}</h2>
					<input
						type={PasswordInputType}
						className="inputModal"
						placeholder="Password"
						name="password"
						value={formValues.password}
						onChange={handleChange}
						style={{ borderColor: formErrors.password ? "red" : "" }}
					/>
					<h1 className="firstPage-modal-text">Password</h1>

					<div className="password-toggle-icon">{ToogleIcon}</div>
				</div>

				<button
					type="submit"
					className="modal-button-submit"
					onClick={handleSubmit}
					disabled={!formValues.email || !formValues.password}
				>
					Log in
				</button>
				<h4>
					Not a member?
					<button
						className="sign-up-from-login-modal"
						onClick={() => {
							props.closeLogin(false);
							props.openSignUp(true);
						}}
					>
						Sign In
					</button>
				</h4>
			</form>
		</div>
	);
}

export default Modal;

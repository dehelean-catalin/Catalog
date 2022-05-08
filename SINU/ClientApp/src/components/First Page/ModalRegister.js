import React, { useState } from "react";
import Axios from "axios";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEye } from "@fortawesome/free-solid-svg-icons";
import { faEyeSlash } from "@fortawesome/free-solid-svg-icons";

function ModalRegister(props) {
	const url = "https://localhost:44328/api/register";

	const initialValues = {
		email: "",
		password: "",
		confirmPassword: "",
		IDNP: "",
	};
	const [formValues, setFormValues] = useState(initialValues);
	const [formErrors, setFormErrors] = useState({});
	// const [isSubmit, setIsSubmit] = useState(false);

	const handleChange = (e) => {
		const { name, value } = e.target;
		setFormValues({ ...formValues, [name]: value });
		console.log(formValues);
	};
	const handleSubmit = (e) => {
		e.preventDefault();
		// setIsSubmit(true);

		if (Object.keys(validate(formValues)).length === 0) {
			Axios.post(url, {
				Email: formValues.email,
				Password: formValues.password,
				IDNP: formValues.IDNP,
			})
				.then((response) => {
					console.log(response.data);
				})
				.catch((err) => {
					formErrors.IDNP = "";
					formErrors.password = "";
					formErrors.email = "";
					if (err.response.status === 400) {
						formErrors.email = err.response.data;
						console.log(err.response.data);
					}
					if (err.response.status === 404) {
						formErrors.IDNP = err.response.data;
						console.log(err.response.data);
					}
					setFormErrors(formErrors);
				});
		}
		setFormErrors(validate(formValues));
	};

	// useEffect(() => {
	// 	console.log(formErrors);
	// 	if (Object.keys(formErrors).length === 0 && isSubmit) {
	// 		console.log(formValues);
	// 	}
	// }, [formErrors]);

	const validate = (values) => {
		const errors = {};
		const regex = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/i;
		if (!regex.test(values.email)) {
			errors.email = "This is not a valid email format!";
		}
		if (values.password.length < 4) {
			errors.password = "Password must be more than 4 characters";
		}
		if (values.password !== values.confirmPassword) {
			errors.confirmPassword = "Password isnt the same";
		}

		if (values.IDNP.length !== 11) {
			errors.IDNP = "you are missing some characters";
		}

		return errors;
	};

	const usePasswordToggle = () => {
		const [visible, setVisiblity] = useState(false);

		const Icon = (
			<FontAwesomeIcon
				icon={visible ? faEye : faEyeSlash}
				onClick={() => setVisiblity((visiblity) => !visiblity)}
				style={{ fontSize: "24px", color: "gray" }}
			/>
		);
		const InputType = visible ? "text" : "password";
		return [InputType, Icon];
	};
	const [PasswordInputType, ToogleIcon] = usePasswordToggle();
	const [PasswordInputType1, ToogleIcon1] = usePasswordToggle();

	return (
		<div className="modal">
			<form>
				<div className="modal-title">Register</div>

				<div className="inputField">
					<h2 className="firstPage-modal-error">{formErrors.IDNP}</h2>
					<input
						name="IDNP"
						type="text"
						className="inputModal"
						placeholder="Enter ID"
						value={formValues.IDNP}
						onChange={handleChange}
						style={{ borderColor: formErrors.IDNP ? "red" : "" }}
					/>
					<h1 className="firstPage-modal-text">Identification code</h1>
				</div>
				<div className="inputField">
					<h2 className="firstPage-modal-error">{formErrors.email}</h2>
					<input
						name="email"
						placeholder="Enter email"
						type="text"
						className="inputModal"
						value={formValues.email}
						onChange={handleChange}
						style={{ borderColor: formErrors.email ? "red" : "" }}
					/>
					<h1 className="firstPage-modal-text">Email</h1>
				</div>
				<div className="inputField">
					<h2 className="firstPage-modal-error">{formErrors.password}</h2>
					<input
						name="password"
						type={PasswordInputType}
						className="inputModal"
						placeholder="Enter password"
						value={formValues.password}
						onChange={handleChange}
						style={{ borderColor: formErrors.password ? "red" : "" }}
					/>
					<h1 className="firstPage-modal-text">Password</h1>
					<div className="password-toggle-icon" id="register">
						{ToogleIcon}
					</div>
				</div>

				<div className="inputField">
					<h2 className="firstPage-modal-error">{formErrors.confirmPassword}</h2>
					<input
						name="confirmPassword"
						type={PasswordInputType1}
						className="inputModal"
						placeholder="Confirm password"
						value={formValues.confirmPassword}
						onChange={handleChange}
						style={{ borderColor: formErrors.confirmPassword ? "red" : "" }}
					/>
					<h1 className="firstPage-modal-text">Confirm Password</h1>
					<div className="password-toggle-icon" id="register">
						{ToogleIcon1}
					</div>
				</div>

				<button
					type="submit"
					className="modal-button-submit"
					onClick={handleSubmit}
					disabled={!formValues.email || !formValues.password || !formValues.IDNP || !formValues.confirmPassword}
				>
					Sign up
				</button>
				<h4>
					Already a member?
					<button
						className="sign-up-from-login-modal"
						onClick={() => {
							props.closeSignUp(false);
							props.openLogin(true);
						}}
					>
						Log In
					</button>
				</h4>
			</form>
		</div>
	);
}

export default ModalRegister;

import React, { useState } from "react";
import Axios from "axios";
function Modal(props) {
	const initialValues = {
		inputMail: props.email,
		inputPhone: props.phone,
		inputAddress: props.address,
	};
	const [formValues, setFormValues] = useState(initialValues);
	const [formErrors, setFormErrors] = useState({});

	const handleChange = (e) => {
		const { name, value } = e.target;
		setFormValues({ ...formValues, [name]: value });
		console.log(formValues);
	};

	const handleSubmit = (e) => {
		e.preventDefault();
		setFormErrors(validate(formValues));
		const userId = JSON.parse(localStorage.getItem("userDetails"))["Id"];
		if (Object.keys(validate(formValues)).length === 0) {
			Axios.put(`https://localhost:44328/api/Users/${userId}/UpdateProfile`, {
				Email: formValues.inputMail,
				Phone: formValues.inputPhone,
				Address: formValues.inputAddress,
			})
				.then((response) => {
					console.log(response.data);
					localStorage.setItem("userDetails", JSON.stringify(response.data));
				})
				.catch((error) => {
					console.log(error.response.data);
				});
		}
	};

	const validate = (values) => {
		const errors = {};
		const regex = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/i;
		const isNumber = /^[(]?[0-9]{3}[)]?[-\s]?[0-9]{3}[-\s]?[0-9]{4,6}$/im;
		if (!values.inputMail) {
			errors.inputMail = "Data is required!";
		} else if (!regex.test(values.inputMail)) {
			errors.inputMail = "This is not a valid email format!";
		}
		if (!values.inputPhone) {
			errors.inputPhone = "Data is required!";
		} else if (!isNumber.test(values.inputPhone)) {
			errors.inputPhone = "This is not a valid phone number";
		}
		if (!values.inputAddress) {
			errors.inputAddress = "Data is required!";
		}
		return errors;
	};

	return (
		<div className="modal-edit-data" style={{ backgroundColor: "rgb(37, 37, 37)" }}>
			<div className="modal-edit-data-title">Edit</div>

			<input
				type="text"
				className="modal-edit-data-input"
				name="inputMail"
				value={formValues.inputMail}
				onChange={handleChange}
			/>
			<div className="modal-error">{formErrors.inputMail}</div>
			<input
				type="text"
				className="modal-edit-data-input"
				name="inputPhone"
				value={formValues.inputPhone}
				onChange={handleChange}
			/>
			<div className="modal-error">{formErrors.inputPhone}</div>

			<input
				type="text"
				className="modal-edit-data-input"
				name="inputAddress"
				value={formValues.inputAddress}
				onChange={handleChange}
			/>
			<div className="modal-error">{formErrors.inputAddress}</div>

			<button type="submit" className="modal-edit-data-button" onClick={handleSubmit}>
				Submit
			</button>
		</div>
	);
}

export default Modal;

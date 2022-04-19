import React, { useState } from "react";
import NavBar from "./NavBar/NavBar";

function Help() {
	const initialValues = {
		inputText: "",
	};
	const [formValues, setFormValues] = useState(initialValues);
	const handleChange = (e) => {
		const { name, value } = e.target;
		setFormValues({ ...formValues, [name]: value });
		console.log(formValues);
	};
	return (
		<div className="help">
			<NavBar />
			<div className="help-container">
				<form className="help-container-form">
					<p>lala</p>
					<textarea
						className="text-area"
						cols="40"
						rows="5"
						resize="none"
						placeholder="Describe your problem"
						name="inputText"
						value={formValues.inputText}
						onChange={handleChange}
					/>
					<button type="submit">Send</button>
				</form>
			</div>
		</div>
	);
}

export default Help;

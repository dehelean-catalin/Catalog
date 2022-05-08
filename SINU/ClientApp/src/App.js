import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Welcome from "./components/First Page/Welcome";
import Profile from "./components/Student/Profile";
import Grades from "./components/Student/Grades";
import Settings from "./components/Student/Settings";

import T_Profile from "./components/Teacher/T_Profile";
import Subjects from "./components/Teacher/Subjects";
import T_Settings from "./components/Teacher/T_Settings";

function App() {
	return (
		<div className="container">
			<Router>
				<Switch>
					<Route path="/" exact render={() => <Welcome onClick={localStorage.clear()} />} />

					<Route path="/student/profile/" component={Profile} />
					<Route path="/student/grades" component={Grades} />
					<Route path="/student/settings" component={Settings} />

					<Route path="/teacher/profile" component={T_Profile} />
					<Route path="/teacher/subjects" component={Subjects} />
					<Route path="/teacher/settings" component={T_Settings} />
				</Switch>
			</Router>
		</div>
	);
}

export default App;

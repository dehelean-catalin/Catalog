import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Welcome from "./components/First Page/Welcome";
import Profile from "./components/Student/Profile";
import Grades from "./components/Student/Grades";
import Settings from "./components/Student/Settings";
import Help from "./components/Student/Help";

import T_Profile from "./components/Teacher/T_Profile";
import Subjects from "./components/Teacher/Subjects";
import T_Settings from "./components/Teacher/T_Settings";
import T_Help from "./components/Teacher/T_Help";

function App() {
	return (
		<div className="container">
			<Router>
				<Switch>
					<Route path="/" exact render={() => <Welcome onClick={localStorage.clear()} />} />

					<Route path="/student/profile/" component={Profile} />
					<Route path="/student/grades" component={Grades} />
					<Route path="/student/settings" component={Settings} />
					<Route path="/student/help" component={Help} />

					<Route path="/teacher/profile" component={T_Profile} />
					<Route path="/teacher/subjects" component={Subjects} />
					<Route path="/teacher/settings" component={T_Settings} />
					<Route path="/teacher/help" component={T_Help} />
				</Switch>
			</Router>
		</div>
	);
}

export default App;

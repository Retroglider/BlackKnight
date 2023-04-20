import { React, useState } from "react";
import "./LoginAttemptList.css";

const LoginAttempt = (props) => {
  // #region Initialize
  const message = `Login: ${props.attempt.login} Password: ${props.attempt.password}`;
  // #endregion
  return <li {...props}>{message}</li>;
};

const LoginAttemptList = (props) => {
  // #region Initialize
  const [filter, setFilter] = useState("");
  const attemptsFiltered =
    filter === ""
      ? props.attempts
      : props.attempts.filter((attempt) => {
          if (attempt.login.includes(filter)) return true;
          if (attempt.password.includes(filter)) return true;
          return false;
        });
  const list = attemptsFiltered.map((attempt) => (
    <LoginAttempt attempt={attempt} key={attempt.id}></LoginAttempt>
  ));
  // #endregion
  // #region Event Handlers
  const handleFilterChange = (event) => {
    setFilter(event.target.value);
  };
  // #endregion
  return (
    <div className="Attempt-List-Main">
      <p>Recent activity</p>
      <input
        type="input"
        placeholder="Filter..."
        onChange={handleFilterChange}
      />
      <ul className="Attempt-List">{list}</ul>
    </div>
  );
};

export default LoginAttemptList;

import React, { useState } from "react";
import "./App.css";
import LoginForm from "./LoginForm";
import LoginAttemptList from "./LoginAttemptList";

const App = () => {
  // #region Initialize
  const [loginAttempts, setLoginAttempts] = useState([]);

  // #endregion
  // #region Event Handlers
  const handleLoginAttempt = ({ login, password }) => {
    setLoginAttempts([
      ...loginAttempts,
      { id: loginAttempts.length + 1, login, password },
    ]);
    console.log({ login, password });
  };
  // #endregion
  return (
    <div className="App">
      <LoginForm
        onSubmit={({ login, password }) => {
          handleLoginAttempt({ login, password });
        }}
      />
      <LoginAttemptList attempts={loginAttempts} />
    </div>
  );
};

export default App;

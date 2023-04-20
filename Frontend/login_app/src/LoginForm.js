import React, { useState } from "react";
import "./LoginForm.css";

const LoginForm = (props) => {
  // #region Initialize
  const [name, setName] = useState("");
  const [password, setPassword] = useState("");
  // #endregion
  // #region Event Handlers
  const handleNameChange = (event) => {
    setName(event.target.value);
  };
  const handlePasswordChange = (event) => {
    setPassword(event.target.value);
  };
  const handleSubmit = (event) => {
    event.preventDefault();

    props.onSubmit({
      login: name,
      password: password,
    });
  };
  // #endregion
  return (
    <form className="form">
      <h1>Login</h1>
      <label htmlFor="name">Name</label>
      <input type="text" id="name" onChange={handleNameChange} />
      <label htmlFor="password">Password</label>
      <input type="password" id="password" onChange={handlePasswordChange} />
      <button type="submit" onClick={handleSubmit}>
        Continue
      </button>
    </form>
  );
};

export default LoginForm;

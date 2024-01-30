import React from "react";
import { Button, Form } from "react-bootstrap";
import { onUserLogin } from "../services/accountService";

const LoginScreen = () => {
  const handleSubmit = async () => {
    let data = { email: "eaare", pass: "asdasd" };

    onUserLogin(data)
      .then((res) => {})
      .catch((err) => {});
  };
  return (
    <div>
      <Form onSubmit={handleSubmit}>
        <Form.Control type="email"></Form.Control>
        <Form.Control type="password"></Form.Control>
        <Button>Login</Button>
      </Form>
    </div>
  );
};

export default LoginScreen;

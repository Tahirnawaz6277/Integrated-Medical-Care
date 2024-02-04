import React, { useState } from "react";
import {
  Button,
  Form,
  FormGroup,
  FormControl,
  FormLabel,
} from "react-bootstrap";
import { loginUser } from "../services/accountService";
import { useFormik } from "formik";
import * as Yup from "yup";
import DashboardScreen from "./dashboard/DashboardScreen";

const LoginScreen = () => {
  const [isLoggedIn, setLoggedIn] = useState(false);

  const formik = useFormik({
    initialValues: {
      email: "",
      password: "",
    },
    validationSchema: Yup.object().shape({
      email: Yup.string().email().required("Email is required"),
      password: Yup.string().required("Password is required"),
    }),
    onSubmit: async (values) => {
      try {
        const res = await loginUser(values);
        if (res.success) {
          formik.resetForm();
          formik.setFieldValue("general", res.message);
          setLoggedIn(true);
        } else {
          formik.setFieldError("general", res.message);
        }
      } catch (error) {
        console.error("Error during login:", error);
      }
    },
  });

  // render the DashboardScreen
  if (isLoggedIn) {
    return <DashboardScreen />;
  }

  return (
    <>
      <Form onSubmit={formik.handleSubmit}>
        <FormGroup>
          <FormLabel>Email address</FormLabel>
          <FormControl
            required
            type="email"
            name="email"
            value={formik.values.email}
            placeholder="name@gmail.com"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.email && (
            <Form.Text className="text-danger">{formik.errors.email}</Form.Text>
          )}
        </FormGroup>

        <FormGroup>
          <FormLabel>Password</FormLabel>
          <FormControl
            required
            type="password"
            name="password"
            placeholder="Enter the password"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.password}
          />
          {formik.touched.password && (
            <Form.Text className="text-danger">
              {formik.errors.password}
            </Form.Text>
          )}
        </FormGroup>
        <Form.Text className="text-success">{formik.values.general}</Form.Text>

        <Button
          disabled={!formik.isValid}
          type="submit"
          variant="primary w-100"
        >
          Login
        </Button>
      </Form>
    </>
  );
};

export default LoginScreen;

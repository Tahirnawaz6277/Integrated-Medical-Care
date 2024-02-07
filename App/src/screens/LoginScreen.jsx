import React from "react";
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
import { useNavigate } from "react-router";

const LoginScreen = () => {
  const navigate = useNavigate();
  const formik = useFormik({
    initialValues: {
      email: "",
      password: "",
    },
    validationSchema: Yup.object().shape({
      email: Yup.string().email().required("Email is required"),
      password: Yup.string().required("Password is required"),
    }),
    onSubmit: async (values, { setFieldError }) => {
      try {
        const res = await loginUser(values);
        if (res.success) {
          formik.resetForm();
          localStorage.setItem("token", res.data.jwtToken);
          navigate("/dashboard");
        }
      } catch (error) {
        setFieldError("password", error.response?.data);
      }
    },
  });

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

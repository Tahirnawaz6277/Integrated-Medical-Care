import React from "react";
import {
  Button,
  Form,
  FormGroup,
  FormControl,
  FormLabel,
} from "react-bootstrap";
import { loginUser } from "../../services/accountService";
import { useFormik } from "formik";
import * as Yup from "yup";
import { useNavigate } from "react-router";
import { useDispatch, useSelector } from "react-redux";
import { loggedIn_User } from "../../Redux/Action";
const LoginScreen = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch();

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

          // Create an object to store in local storage
          const userData = {
            token: res.data.jwtToken,
            LoggedIn_User_Id: res.data.current_LoggedIn_Id,
            Email: res.data.email,
            role: res.data.role,
          };

          dispatch(loggedIn_User(userData));

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
        <a href="./Signup">Create Account</a>
      </Form>
    </>
  );
};

export default LoginScreen;

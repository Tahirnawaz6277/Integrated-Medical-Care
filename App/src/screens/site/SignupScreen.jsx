import { useState } from "react";
import { Button, Form } from "react-bootstrap";
import { registerUser } from "../../services/accountService";
import { useFormik } from "formik";
import * as Yup from "yup";

const SignupScreen = () => {
  const formik = useFormik({
    initialValues: {
      firstName: "",
      lastName: "",
      gender: "",
      email: "",
      qualification: "",
      experience: "",
      password: "",
      role: "",
      phoneNumber: "",
    },
    validationSchema: Yup.object().shape({
      firstName: Yup.string().required(),
      lastName: Yup.string().required(),
      email: Yup.string().email().required(),
    }),
    onSubmit: async (values) => {
      registerUser(values).then((res) => {
        if (res.success) {
          formik.resetForm();
          formik.setFieldValue("general", res.message);
        }
      });
    },
  });

  return (
    <>
      <Form onSubmit={formik.handleSubmit}>
        <Form.Group className="mb-3">
          <Form.Label>FirstName</Form.Label>
          <Form.Control
            required
            type="text"
            name="firstName"
            value={formik.values.firstName}
            placeholder="Enter The FirstName"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.firstName && (
            <Form.Text className="text-danger">
              {formik.errors.firstName}
            </Form.Text>
          )}
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>LastName</Form.Label>
          <Form.Control
            required
            type="text"
            name="lastName"
            value={formik.values.lastName}
            placeholder="Enter The LastName"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Email address</Form.Label>
          <Form.Control
            required
            type="email"
            name="email"
            value={formik.values.email}
            placeholder="name@example.com"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Gender</Form.Label>
          <Form.Select
            required
            name="gender"
            aria-label="Select Gender"
            value={formik.values.gender}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          >
            <option value="male">Male</option>
            <option value="female">Female</option>
          </Form.Select>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Role</Form.Label>
          <Form.Select
            required
            name="role"
            aria-label="Select Role"
            value={formik.values.role}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          >
            <option value="Customer">Customer</option>
            <option value="ServiceProvider">ServiceProvider</option>
            <option value="Admin">Admin</option>
          </Form.Select>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Qualification</Form.Label>
          <Form.Control
            required
            type="text"
            name="qualification"
            placeholder="Enter the Qualification"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.qualification}
          />
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Experience</Form.Label>
          <Form.Control
            required
            type="number"
            name="experience"
            placeholder="Enter the Experience"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.experience}
          />
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Password</Form.Label>
          <Form.Control
            required
            type="password"
            name="password"
            placeholder="Enter the Password"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.password}
          />
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Phone Number</Form.Label>
          <Form.Control
            required
            type="text"
            name="phoneNumber"
            placeholder="Enter the Phone Number"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.phoneNumber}
          />
        </Form.Group>
        <Form.Text className="text-success">{formik.values.general}</Form.Text>

        <Button
          disabled={!formik.isValid}
          type="submit"
          variant="primary w-100"
        >
          Signup
        </Button>
      </Form>
    </>
  );
};

export default SignupScreen;

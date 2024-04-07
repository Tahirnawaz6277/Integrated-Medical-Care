import { Button, Form, Row, Col, Image } from "react-bootstrap";
import {
  Add_User_Qualification,
  registerUser,
} from "../../services/accountService";
import { useFormik } from "formik";
import * as Yup from "yup";
import "../site/signup.scss";
import { AddServiceProviders } from "../../services/serviceProvidersService";
import { useState } from "react";

const SignupScreen = () => {
  const [providerType, setProviderType] = useState("");
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
      providerType: "",
      phoneNumber: "",
    },
    validationSchema: Yup.object().shape({
      firstName: Yup.string().required(),
      lastName: Yup.string().required(),
      email: Yup.string().email().required(),
      gender: Yup.string().required(),

      providerType: Yup.string().notRequired(),
      qualification: Yup.string().notRequired(),
      experience: Yup.string().notRequired(),
      password: Yup.string().required(),
      role: Yup.string().required(),
      phoneNumber: Yup.string().required(),
    }),
    onSubmit: async (values) => {
      try {
        if (values.role !== "Customer") {
          const provider = { providerName: values.providerType.toLowerCase() };
          const res = await AddServiceProviders(provider);
          const providerId = res?.providerRequestData?.data?.id;
          if (providerId) {
            let qualificationId = null;
            if (provider.providerName === "doctor") {
              const qualificationRes = await Add_User_Qualification({
                qualification: values.qualification,
                experience: values.experience,
              });
              qualificationId = qualificationRes?.data?.id;

              const registerRes = await registerUser(
                values,
                providerId,
                qualificationId
              );
              if (registerRes.success) {
                formik.resetForm();
                formik.setFieldValue("general", registerRes.message);
              }
            } else {
              const registerRes = await registerUser(values, providerId);
              if (registerRes.success) {
                formik.resetForm();
                formik.setFieldValue("general", registerRes.message);
              }
            }
          }
        } else {
          const registerRes = await registerUser(values);
          if (registerRes.success) {
            formik.resetForm();
            formik.setFieldValue("general", registerRes.message);
          }
        }
      } catch (err) {
        formik.setFieldValue(
          "general",
          err.response?.data?.message || err.message
        );
      }

      // if (provider.providerName.toLowerCase() === "doctor") {
      //   AddServiceProviders(provider)
      //     .then((res) => {
      //       if (
      //         res &&
      //         res.providerRequestData &&
      //         res.providerRequestData.data
      //       ) {
      //         const providerId = res.providerRequestData.data.id;
      //         const User_Qualification = {
      //           qualification: values.qualification,
      //           experience: values.experience,
      //         };
      //         Add_User_Qualification(User_Qualification).then((res) => {
      //           const Qualification_Id = res.data.id;
      //           if (res.success) {
      //             registerUser(values, providerId, Qualification_Id)
      //               .then((res) => {
      //                 if (res.success) {
      //                   formik.resetForm();
      //                   formik.setFieldValue("general", res.message);
      //                 }
      //               })
      //               .catch((err) => {
      //                 formik.setFieldValue("general", err);
      //               });
      //           }
      //         });
      //       }
      //     })
      //     .catch((err) => {
      //       formik.setFieldValue("general", err.response.data.message);
      //     });
      // } else {
      //   AddServiceProviders(provider)
      //     .then((res) => {
      //       if (
      //         res &&
      //         res.providerRequestData &&
      //         res.providerRequestData.data
      //       ) {
      //         const providerId = res.providerRequestData.data.id;
      //         registerUser(values, providerId)
      //           .then((res) => {
      //             if (res.success) {
      //               formik.resetForm();
      //               formik.setFieldValue("general", res.message);
      //             }
      //           })
      //           .catch((err) => {
      //             formik.setFieldValue("general", err);
      //           });
      //       }
      //     })
      //     .catch((err) => {
      //       formik.setFieldValue("general", err.response.data.message);
      //     });
      // }
    },
  });
  return (
    <>
      <Form onSubmit={formik.handleSubmit} className="signup-form">
        <center>
          <Image src="../../../images/logo.png" />{" "}
        </center>
        <Row className="mb-3">
          <Col md={6}>
            <Form.Group className="mb-3">
              <Form.Label>FirstName</Form.Label>
              <Form.Control
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
          </Col>
          <Col md={6}>
            <Form.Group className="mb-3">
              <Form.Label>LastName</Form.Label>
              <Form.Control
                type="text"
                name="lastName"
                value={formik.values.lastName}
                placeholder="Enter The LastName"
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
              />
              {formik.touched.lastName && (
                <Form.Text className="text-danger">
                  {formik.errors.lastName}
                </Form.Text>
              )}
            </Form.Group>
          </Col>
        </Row>
        <Row className="mb-3">
          <Col md={6}>
            <Form.Group className="mb-3">
              <Form.Label>Email address</Form.Label>
              <Form.Control
                type="email"
                name="email"
                value={formik.values.email}
                placeholder="name@example.com"
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
              />
              {formik.touched.email && (
                <Form.Text className="text-danger">
                  {formik.errors.email}
                </Form.Text>
              )}
            </Form.Group>
          </Col>
          <Col md={6}>
            <Form.Group className="mb-3">
              <Form.Label>Gender</Form.Label>
              <Form.Select
                name="gender"
                aria-label="Select Gender"
                value={formik.values.gender}
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                className="form-select"
              >
                <option value="" label="Select Gender" />
                <option value="male">Male</option>
                <option value="female">Female</option>
              </Form.Select>
              {formik.touched.gender && (
                <Form.Text className="text-danger">
                  {formik.errors.gender}
                </Form.Text>
              )}
            </Form.Group>
          </Col>
        </Row>
        <Row className="mb-3">
          <Col md={6}>
            <Form.Group className="mb-3">
              <Form.Label>Role</Form.Label>
              <Form.Select
                name="role"
                aria-label="Select Role"
                value={formik.values.role}
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                className="form-select"
              >
                <option value="" label="Select Role" />
                <option value="Customer">Customer</option>
                <option value="ServiceProvider">ServiceProvider</option>
                <option value="Admin">Admin</option>
              </Form.Select>
              {formik.touched.role && (
                <Form.Text className="text-danger">
                  {formik.errors.role}
                </Form.Text>
              )}
            </Form.Group>
          </Col>
          <Col md={6}>
            {formik.values.role === "ServiceProvider" && (
              <Form.Group className="mb-3">
                <Form.Label>Service Provider Type</Form.Label>
                <Form.Select
                  name="providerType"
                  aria-label="Select Provider Type"
                  value={formik.values.providerType}
                  onChange={formik.handleChange}
                  onBlur={formik.handleBlur}
                  className="form-select"
                >
                  <option value="" label="Select Provider Type" />
                  <option value="doctor">Doctor</option>
                  <option value="ambulance">Ambulance</option>
                  <option value="pharmacy">Pharmacy</option>
                  <option value="other">Other</option>
                </Form.Select>
                {formik.touched.providerType && (
                  <Form.Text className="text-danger">
                    {formik.errors.providerType}
                  </Form.Text>
                )}
              </Form.Group>
            )}
          </Col>
        </Row>
        {formik.values.role === "ServiceProvider" &&
          formik.values.providerType === "doctor" && (
            <>
              <Row className="mb-3">
                <Col md={6}>
                  <Form.Group className="mb-3">
                    <Form.Label>Qualification</Form.Label>
                    <Form.Control
                      type="text"
                      name="qualification"
                      placeholder="Enter the Qualification"
                      onChange={formik.handleChange}
                      onBlur={formik.handleBlur}
                      value={formik.values.qualification}
                    />
                    {formik.touched.qualification && (
                      <Form.Text className="text-danger">
                        {formik.errors.qualification}
                      </Form.Text>
                    )}
                  </Form.Group>
                </Col>
                <Col md={6}>
                  <Form.Group className="mb-3">
                    <Form.Label>Experience</Form.Label>
                    <Form.Control
                      type="text"
                      name="experience"
                      value={formik.values.experience}
                      placeholder="0"
                      onChange={formik.handleChange}
                      onBlur={formik.handleBlur}
                    />
                    {formik.touched.experience && (
                      <Form.Text className="text-danger">
                        {formik.errors.experience}
                      </Form.Text>
                    )}
                  </Form.Group>
                </Col>
              </Row>
            </>
          )}
        <Row className="mb-3">
          <Col md={6}>
            <Form.Group className="mb-3">
              <Form.Label>Password</Form.Label>
              <Form.Control
                type="password"
                name="password"
                placeholder="Enter the Password"
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                value={formik.values.password}
              />
              {formik.touched.password && (
                <Form.Text className="text-danger">
                  {formik.errors.password}
                </Form.Text>
              )}
            </Form.Group>
          </Col>
          <Col md={6}>
            <Form.Group className="mb-3">
              <Form.Label>Phone Number</Form.Label>
              <Form.Control
                type="text"
                name="phoneNumber"
                placeholder="Enter the Phone Number"
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                value={formik.values.phoneNumber}
              />
              {formik.touched.phoneNumber && (
                <Form.Text className="text-danger">
                  {formik.errors.phoneNumber}
                </Form.Text>
              )}
            </Form.Group>
          </Col>
        </Row>
        <br />
        <Form.Text className="text-success">{formik.values.general}</Form.Text>
        <Button
          disabled={!formik.isValid}
          type="submit"
          variant="primary w-100"
        >
          Signup
        </Button>
        <a href="/">Click here to Login</a>
      </Form>
    </>
  );
};

export default SignupScreen;

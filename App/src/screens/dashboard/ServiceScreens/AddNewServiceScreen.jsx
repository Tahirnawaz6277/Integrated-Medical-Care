import React, { Component } from "react";
import { useState } from "react";
import { Button, Form } from "react-bootstrap";
import { AddService } from "../../../services/ManageService";
import { useFormik } from "formik";
import * as Yup from "yup";
import { useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";

const AddNewServiceScreen = () => {
  const [message, setMessage] = useState("");
  const navigate = useNavigate();
  const loggedIn_User = useSelector((state) => state.actionsReducer);

  const formik = useFormik({
    initialValues: {
      serviceName: "",
      charges: "",
      image: "",
      availableQuantity: "",
      totalQuantity: "",
    },
    validationSchema: Yup.object().shape({
      serviceName: Yup.string().required(),
      charges: Yup.string().required(),
    }),

    onSubmit: async (data) => {
      try {
        const res = await AddService(data, loggedIn_User);

        if (res.success) {
          formik.resetForm();
          setMessage(res.message);
          setTimeout(() => navigate("/dashboard/services"), 1000);
        }
      } catch (error) {
        if (error.response && error.response.status === 401) {
          // Redirect to login page or handle unauthorized access
          history.push("/login");
          setMessage(error.response.data.message);
        }
      } finally {
        setLoading(false);
      }
    },
  });

  return (
    <>
      <Form onSubmit={formik.handleSubmit}>
        <Form.Group className="mb-3 ">
          <Form.Label>Service</Form.Label>
          <Form.Control
            type="text"
            name="serviceName"
            value={formik.values.serviceName}
            placeholder="Enter The Service"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.serviceName && (
            <Form.Text className="text-danger">
              {formik.errors.serviceName}
            </Form.Text>
          )}
        </Form.Group>

        <Form.Group className="mb-3 ">
          <Form.Label>charges</Form.Label>
          <Form.Control
            type="text"
            name="charges"
            value={formik.values.charges}
            placeholder="Enter The Charges "
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.charges && (
            <Form.Text className="text-danger">
              {formik.errors.charges}
            </Form.Text>
          )}
        </Form.Group>

        <Form.Group className="mb-3 ">
          <Form.Label>Image</Form.Label>
          <Form.Control
            type="text"
            name="image"
            value={formik.values.image}
            placeholder="Upload the Image "
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.image && (
            <Form.Text className="text-danger">{formik.errors.image}</Form.Text>
          )}
        </Form.Group>

        <Form.Group className="mb-3 ">
          <Form.Label>Available Quantity</Form.Label>
          <Form.Control
            type="number"
            name="availableQuantity"
            value={formik.values.availableQuantity}
            placeholder="Enter The Available Quantity of Service "
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.availableQuantity && (
            <Form.Text className="text-danger">
              {formik.errors.availableQuantity}
            </Form.Text>
          )}
        </Form.Group>

        <Form.Group className="mb-3 ">
          <Form.Label>Total Quantity</Form.Label>
          <Form.Control
            type="number"
            name="totalQuantity"
            value={formik.values.totalQuantity}
            placeholder="Enter The Total Quantity of Service "
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.totalQuantity && (
            <Form.Text className="text-danger">
              {formik.errors.totalQuantity}
            </Form.Text>
          )}
        </Form.Group>

        {/* {message && (
          <Form.Text
            className={`text-${
              message.toLowerCase().includes("success") ? "success" : "danger"
            }`}
          >
            {message}
          </Form.Text>
        )} */}

        <Button
          disabled={!formik.isValid}
          type="submit"
          variant="primary w-100"
        >
          Submit
        </Button>
      </Form>
    </>
  );
};

export default AddNewServiceScreen;

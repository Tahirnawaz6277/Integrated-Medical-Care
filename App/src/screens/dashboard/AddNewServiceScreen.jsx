import React, { Component } from "react";
import { useState } from "react";
import { Button, Form } from "react-bootstrap";
import { AddService } from "../../services/ManageService";
import { useFormik } from "formik";
import * as Yup from "yup";
import { useNavigate } from "react-router-dom";

const AddNewServiceScreen = () => {
  const [message, setMessage] = useState("");
  const navigate = useNavigate();

  const formik = useFormik({
    initialValues: {
      Service: "",
      Charges: "",
    },
    validationSchema: Yup.object().shape({
      Service: Yup.string().required(),
      Charges: Yup.string().required(),
    }),

    onSubmit: async (data) => {
      try {
        const res = await AddService(data);

        if (res.success) {
          formik.resetForm();
          setMessage(res.message);
          setTimeout(() => navigate("/dashboard/services"), 1000);
        }
      } catch (err) {
        setMessage(err.response.data.message);
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
            name="Service"
            value={formik.values.Service}
            placeholder="Enter The Service"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.Service && (
            <Form.Text className="text-danger">
              {formik.errors.Service}
            </Form.Text>
          )}
        </Form.Group>

        <Form.Group className="mb-3 ">
          <Form.Label>charges</Form.Label>
          <Form.Control
            type="text"
            name="Charges"
            value={formik.values.Charges}
            placeholder="Enter The Charges "
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.Charges && (
            <Form.Text className="text-danger">
              {formik.errors.Charges}
            </Form.Text>
          )}
        </Form.Group>

        {message && (
          <Form.Text
            className={`text-${
              message.toLowerCase().includes("success") ? "success" : "danger"
            }`}
          >
            {message}
          </Form.Text>
        )}

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

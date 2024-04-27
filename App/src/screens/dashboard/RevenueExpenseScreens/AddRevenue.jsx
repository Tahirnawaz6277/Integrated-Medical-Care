import { useFormik } from "formik";
import React, { useState } from "react";
import { Button, Form } from "react-bootstrap";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import * as Yup from "yup";
import { addRevenue } from "../../../services/revenueService";

const AddRevenue = () => {
  const [message, setMessage] = useState("");

  const navigate = useNavigate();
  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const formik = useFormik({
    initialValues: {
      amount: "",
      payerId: "",
      paymentMethod: "",
    },
    validationSchema: Yup.object().shape({
      amount: Yup.number().required(),
      paymentMethod: Yup.string().required(),
    }),

    onSubmit: async (values) => {
      addRevenue(values, loggedIn_User)
        .then((res) => {
          if (res.success) {
            formik.resetForm();
            setMessage(res.message);
            setTimeout(() => navigate("/dashboard/revenue"), 1000);
          }
        })
        .catch((err) => {
          formik.setFieldValue(
            "general",
            err.response?.data?.message || err.message
          );
        });
    },
  });
  return (
    <>
      {message && (
        <Form.Text
          className={`text-${
            message.toLowerCase().includes("success") ? "success" : "danger"
          }`}
          style={{ float: "end", fontSize: "20px", fontWeight: "bold" }}
        >
          {message}
        </Form.Text>
      )}
      <Form onSubmit={formik.handleSubmit} className="hcp-form">
        <Form.Group className="mb-3">
          <Form.Label>Amount</Form.Label>
          <Form.Control
            type="number"
            name="amount"
            value={formik.values.amount}
            placeholder="Enter Amount "
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.amount && (
            <Form.Text className="text-danger">
              {formik.errors.amount}
            </Form.Text>
          )}
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Payment Method</Form.Label>
          <Form.Select
            name="paymentMethod"
            value={formik.values.paymentMethod}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            isInvalid={
              formik.touched.paymentMethod && formik.errors.paymentMethod
            }
          >
            <option value="">Select Payment Method</option>
            <option value="Cash">Cash</option>
            <option value="Debit Card">other</option>
          </Form.Select>
          <Form.Control.Feedback type="invalid">
            {formik.errors.paymentMethod}
          </Form.Control.Feedback>
        </Form.Group>

        <Button
          disabled={!formik.isValid}
          type="submit"
          variant="primary w-100"
        >
          Add Revenue
        </Button>
      </Form>
    </>
  );
};

export default AddRevenue;

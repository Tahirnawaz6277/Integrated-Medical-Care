import { useFormik } from "formik";
import React, { useState } from "react";
import { Button, Form } from "react-bootstrap";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import * as Yup from "yup";
import { addExpense } from "../../../services/expenseServices";

const AddExpenseScreen = () => {
  const [message, setMessage] = useState("");

  const navigate = useNavigate();
  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const formik = useFormik({
    initialValues: {
      amount: "",
      PayeeId: "",
      expenseCategory: "",
    },
    validationSchema: Yup.object().shape({
      amount: Yup.number().required(),
      expenseCategory: Yup.string().required(),
    }),

    onSubmit: async (values) => {
      addExpense(values, loggedIn_User)
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
          <Form.Label>Expense Category</Form.Label>
          <Form.Control
            type="text"
            name="expenseCategory"
            value={formik.values.expenseCategory}
            placeholder="Enter Expense Category "
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.expenseCategory && (
            <Form.Text className="text-danger">
              {formik.errors.expenseCategory}
            </Form.Text>
          )}
        </Form.Group>

        <Button
          disabled={!formik.isValid}
          type="submit"
          variant="primary w-100"
        >
          Add Expense
        </Button>
      </Form>
    </>
  );
};

export default AddExpenseScreen;

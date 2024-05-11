import { useFormik } from "formik";
import React, { useState } from "react";
import { useSelector } from "react-redux";
import { useLocation, useNavigate } from "react-router-dom";
import { updateExpense } from "../../../services/expenseServices";
import * as Yup from "yup";
import { Button, Card, Form } from "react-bootstrap";

const UpdateExpenseScreen = () => {
  const [message, setMessage] = useState([]);
  const { state } = useLocation();

  const navigate = useNavigate();
  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const { id, amount, payeeId, expenseCategory } = state.expense;

  const formik = useFormik({
    initialValues: {
      amount: amount,
      payeeId: payeeId,
      expenseCategory: expenseCategory,
    },
    validationSchema: Yup.object().shape({
      amount: Yup.number().required(),
      expenseCategory: Yup.string().required(),
    }),

    onSubmit: async (values) => {
      updateExpense(id, values, loggedIn_User)
        .then((res) => {
          console.log(res);
          if (res.success) {
            formik.resetForm();
            setMessage(res.message, res.success);
            setTimeout(() => navigate("/dashboard/revenue"), 1000);
          }
        })
        .catch((err) => {
          setMessage(err.response?.data?.message, err.success);
        });
    },
  });
  return (
    <>
      <Card>
        <Card.Header
          style={{
            background: "black",
            padding: "20px",
            color: "white",
          }}
        >
          Manage Expense
        </Card.Header>
        <Card.Body>
          {message && (
            <p
              className={`text-${
                message.success == true ? "success" : "danger"
              }`}
              style={{ float: "end", fontSize: "20px", fontWeight: "bold" }}
            >
              {message}
            </p>
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
              Save Expense
            </Button>
          </Form>
        </Card.Body>
      </Card>
    </>
  );
};

export default UpdateExpenseScreen;

import { useFormik } from "formik";
import React, { useEffect, useState } from "react";
import { Button, Card, Form } from "react-bootstrap";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import * as Yup from "yup";
import { addExpense } from "../../../services/expenseServices";
import { GetServiceProviders } from "../../../services/serviceProvidersService";

const AddExpenseScreen = () => {
  const [message, setMessage] = useState("");
  const [serviceProvider, setServiceProviders] = useState([]);

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

  const fetchHcps = () => {
    GetServiceProviders()
      .then((res) => {
        if (res.success) {
          var hcps = res.data.filter((hcp) => {
            return hcp.role === "ServiceProvider";
          });

          setServiceProviders(hcps);
        }
      })
      .catch((err) => {
        console.log(err);
      });
  };

  useEffect(() => {
    fetchHcps();
  }, [loggedIn_User]);

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
          Manage Expenses
        </Card.Header>
        <Card.Body>
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
              <Form.Label>Select Service Providers</Form.Label>
              <Form.Select
                disabled={serviceProvider.length === 0}
                name="PayeeId"
                value={formik.values.PayeeId}
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
              >
                <option value="" label="Select Service Provider" />

                {serviceProvider.map((hcp, index) => (
                  <option key={index} value={hcp.id}>
                    {hcp.firstName}
                    {hcp.lastName}
                  </option>
                ))}
              </Form.Select>

              {formik.touched.PayeeId && (
                <Form.Text className="text-danger">
                  {formik.errors.PayeeId}
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
              className="btn-custom"
            >
              Add Expense
            </Button>
          </Form>
        </Card.Body>
      </Card>
    </>
  );
};

export default AddExpenseScreen;

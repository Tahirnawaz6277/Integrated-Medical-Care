import { useFormik } from "formik";
import React, { useState } from "react";
import { Button, Card, Col, Container, Form, Row } from "react-bootstrap";
import { useSelector } from "react-redux";
import { NavLink, useNavigate } from "react-router-dom";
import * as Yup from "yup";
import { addRevenue } from "../../../services/revenueService";

const TransferPaymentScreen = (props) => {
  const [message, setMessage] = useState("");
  const navigate = useNavigate();

  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const formik = useFormik({
    initialValues: {
      amount: props.amount,
      paymentMethod: "",
      payerId: "",
    },
    validationSchema: Yup.object().shape({
      amount: Yup.string().required(),
      paymentMethod: Yup.string().required(),
    }),

    onSubmit: async (data) => {
      try {
        const res = await addRevenue(data, loggedIn_User);
        if (res.success) {
          formik.resetForm();
          setMessage("Payement Transfer Successfully!");
          setTimeout(() => navigate("/dashboard"), 1000);
        }
      } catch (err) {
        setMessage(err.response.data.message);
      }
    },
  });

  return (
    <>
      <section style={{ backgroundColor: "#eee" }}>
        <Container className="py-5">
          <Row className="d-flex justify-content-center">
            <Col md={8} lg={6} xl={4}>
              <Card className="rounded-3">
                <Card.Body className="mx-1 my-2">
                  <Form onSubmit={formik.handleSubmit}>
                    <Form.Group className="mb-3">
                      <Form.Label>Amount</Form.Label>
                      <Form.Control
                        type="number"
                        name="amount"
                        value={formik.values.amount}
                        placeholder="Enter Total Amount"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                      />
                      {formik.touched.amount && formik.errors.amount && (
                        <Form.Text className="text-danger">
                          {formik.errors.amount}
                        </Form.Text>
                      )}
                    </Form.Group>

                    <Form.Group className="mb-3">
                      <Form.Label>Select Payment Mode</Form.Label>
                      <Form.Select
                        name="paymentMethod"
                        aria-label="Payment Method"
                        value={formik.values.paymentMethod}
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                      >
                        <option value="">Select Payment Method</option>
                        <option value="Cash">Cash-On-Delivery</option>
                      </Form.Select>
                      {formik.touched.paymentMethod &&
                        formik.errors.paymentMethod && (
                          <Form.Text className="text-danger">
                            {formik.errors.paymentMethod}
                          </Form.Text>
                        )}
                    </Form.Group>

                    <div className="d-flex justify-content-between align-items-center pb-1">
                      <NavLink to="/dashboard/payement" className="text-muted">
                        <Button
                          style={{
                            borderRadius: "0px",
                            background: "#dbdbdb",
                            color: "black",
                            border: "none",
                            paddingRight: "48px",
                            paddingLeft: "42px",
                          }}
                          type="button"
                        >
                          Go back
                        </Button>
                      </NavLink>
                      <Button
                        variant="primary"
                        style={{
                          borderRadius: "0px",
                          paddingRight: "48px",
                          paddingLeft: "40px",
                        }}
                        type="submit"
                      >
                        Pay amount
                      </Button>
                    </div>
                  </Form>
                  {message && (
                    <div className="text-center text-success">{message}</div>
                  )}
                </Card.Body>
              </Card>
            </Col>
          </Row>
        </Container>
      </section>
    </>
  );
};

export default TransferPaymentScreen;

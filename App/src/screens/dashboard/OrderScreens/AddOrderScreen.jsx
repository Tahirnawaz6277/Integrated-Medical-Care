import { useFormik } from "formik";
import React, { useEffect, useState } from "react";
import { Button, Card, CardBody, CardHeader, Form } from "react-bootstrap";
import * as Yup from "yup";
import { getUsers } from "../../../services/accountService";
import "./style.scss";
import { getServices } from "../../../services/ManageService";
import { AddOrder } from "../../../services/orderService";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";

const AddOrderScreen = () => {
  const [customer, setCustomers] = useState([]);
  const [service, setServices] = useState([]);
  const [message, setMessage] = useState("");
  const navigate = useNavigate();

  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const fetchUsers = () => {
    getUsers()
      .then((res) => {
        if (res.success) {
          let customers = res.data.filter((customer) => {
            return customer.role === "Customer";
          });
          setCustomers(customers);
        }
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const formik = useFormik({
    initialValues: {
      contact: "",
      address: "",
      amount: "",
      paymentMode: "",
      serviceId: "",
      orderToUserId: "",
    },
    validationSchema: Yup.object().shape({
      contact: Yup.number().required(),
      address: Yup.string().required(),
      amount: Yup.string().required(),
      paymentMode: Yup.string().required(),
      serviceId: Yup.string().required(),
      orderToUserId: Yup.string().required(),
    }),

    onSubmit: async (data) => {
      try {
        const res = await AddOrder(data, loggedIn_User);
        if (res.success) {
          formik.resetForm();
          setMessage(res.message);
          setTimeout(() => navigate("/dashboard/orders"), 1000);
        }
      } catch (err) {
        console.log(err);
        setMessage(err.response.data.message);
      }
    },
  });

  useEffect(() => {
    getServices(loggedIn_User)
      .then((res) => {
        if (res.success) {
          setServices(res.data);
        }
      })
      .catch((error) => {
        console.log(error);
      });
    fetchUsers();
  }, []);

  return (
    <Card>
      <CardHeader
        style={{
          background: "black",
          padding: "20px",
          color: "white",
        }}
      >
        Manage Order
      </CardHeader>
      <CardBody>
        <Form onSubmit={formik.handleSubmit}>
          <Form.Group className="mb-3">
            <Form.Label>Select Service</Form.Label>
            <Form.Select
              name="serviceId"
              aria-label="Service"
              value={formik.values.serviceId}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
            >
              <option value="" label="Select Service" />

              {service.map((service) => (
                <option key={service.id} value={service.id}>
                  {service.serviceName}
                </option>
              ))}
            </Form.Select>
            {formik.touched.serviceId && (
              <Form.Text className="text-danger">
                {formik.errors.serviceId}
              </Form.Text>
            )}
          </Form.Group>

          <Form.Group className="mb-3 ">
            <Form.Label>Contact</Form.Label>
            <Form.Control
              type="number"
              name="contact"
              value={formik.values.providerName}
              placeholder="Enter Your Contact Number"
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
            />
            {formik.touched.contact && (
              <Form.Text className="text-danger">
                {formik.errors.contact}
              </Form.Text>
            )}
          </Form.Group>

          <Form.Group className="mb-3 ">
            <Form.Label>Address</Form.Label>
            <Form.Control
              type="text"
              name="address"
              value={formik.values.address}
              placeholder="Enter Your Address"
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
            />
            {formik.touched.address && (
              <Form.Text className="text-danger">
                {formik.errors.address}
              </Form.Text>
            )}
          </Form.Group>

          <Form.Group className="mb-3 ">
            <Form.Label>Amount</Form.Label>
            <Form.Control
              type="number"
              name="amount"
              value={formik.values.amount}
              placeholder="Enter Total Amount"
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
            <Form.Label>Select Customer</Form.Label>
            <Form.Select
              name="orderToUserId"
              aria-label="Customer  / Patients"
              value={formik.values.orderToUserId}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
            >
              <option value="" label="Select Customer / Patient" />

              {customer.map((customer) => (
                <option key={customer.id} value={customer.id}>
                  {customer.firstName}
                </option>
              ))}
            </Form.Select>
            {formik.touched.orderToUserId && (
              <Form.Text className="text-danger">
                {formik.errors.orderToUserId}
              </Form.Text>
            )}
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Select PayementMode</Form.Label>
            <Form.Select
              name="paymentMode"
              aria-label="PayementMethod"
              value={formik.values.paymentMode}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
            >
              <option value="" label="Select PayementMethod" />
              <option value="Cash">Cash-On-Delivery</option>
            </Form.Select>
            {formik.touched.paymentMode && (
              <Form.Text className="text-danger">
                {formik.errors.paymentMode}
              </Form.Text>
            )}
          </Form.Group>

          <Button
            disabled={!formik.isValid}
            type="submit"
            variant="primary w-100"
            className="btn-custom"
          >
            Order Now
          </Button>
        </Form>
      </CardBody>
    </Card>
  );
};

export default AddOrderScreen;

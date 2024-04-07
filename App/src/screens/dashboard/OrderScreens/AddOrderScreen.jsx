import { useFormik } from "formik";
import React, { useEffect, useState } from "react";
import { Button, Form } from "react-bootstrap";
import * as Yup from "yup";
import { getUsers } from "../../../services/accountService";
import "./style.scss";
import { getServices } from "../../../services/ManageService";
import { AddOrder } from "../../../services/orderService";
import { useSelector } from "react-redux";

const AddOrderScreen = () => {
  const [service, setServices] = useState([]);
  const [message, setMessage] = useState("");

  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const formik = useFormik({
    initialValues: {
      contact: "",
      address: "",
      amount: "",
      paymentMode: "",

      serviceId: "",
    },
    validationSchema: Yup.object().shape({
      contact: Yup.string().required(),
      address: Yup.string().required(),

      amount: Yup.string().required(),
      paymentMode: Yup.string().required(),

      serviceId: Yup.string().required(),
    }),

    onSubmit: async (data) => {
      try {
        const res = await AddOrder(data, loggedIn_User);
        if (res.success) {
          formik.resetForm();
          setMessage(res.message);
          // setTimeout(() => navigate("/dashboard/orders"), 1000);
        }
      } catch (err) {
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
  }, []);

  return (
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
          type="text"
          name="contact"
          value={formik.values.providerName}
          placeholder="Enter Your Contact Number"
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
        />
        {formik.touched.contact && (
          <Form.Text className="text-danger">{formik.errors.contact}</Form.Text>
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
          <Form.Text className="text-danger">{formik.errors.address}</Form.Text>
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
          <Form.Text className="text-danger">{formik.errors.amount}</Form.Text>
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

      <Button disabled={!formik.isValid} type="submit" variant="primary w-100">
        Submit
      </Button>
    </Form>
  );
};

export default AddOrderScreen;

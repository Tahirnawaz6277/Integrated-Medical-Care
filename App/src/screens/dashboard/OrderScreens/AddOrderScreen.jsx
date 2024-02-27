import { useFormik } from "formik";
import React, { useEffect, useState } from "react";
import { Button, Form } from "react-bootstrap";
import * as Yup from "yup";
import { getUsers } from "../../../services/accountService";
import "./style.scss";
import { getServices } from "../../../services/ManageService";

const AddOrderScreen = () => {
  const [customers, setCustomers] = useState([]);
  const [service, setServices] = useState([]);
  const [message, setMessage] = useState("");

  const formik = useFormik({
    initialValues: {
      contact: "",
      address: "",
      orderQuantity: "",
      amount: "",
      payementMode: "",
      customers: "",
      service: "",
    },
    validationSchema: Yup.object().shape({
      contact: Yup.string().required(),
      address: Yup.string().required(),
      orderQuantity: Yup.number().required(),
      amount: Yup.string().required(),
      payementMode: Yup.string().required(),
      customers: Yup.string().required(),
      service: Yup.string().required(),
    }),

    onSubmit: async (data) => {
      try {
        console.log(data);
      } catch (err) {
        setMessage(err.response.data.message);
      }
    },
  });

  useEffect(() => {
    getUsers()
      .then((res) => {
        if (res.success) {
          setCustomers(res.data);
        }
      })
      .catch((error) => {
        console.log(error);
      });
    getServices()
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
        <Form.Label>Select Customer</Form.Label>
        <Form.Select
          name="customers"
          aria-label="Customer"
          value={formik.values.customers}
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
        >
          <option value="" label="Select Customer" />

          {customers.map((customer) => (
            <option key={customer.id} value={customer.id}>
              {customer.firstName}
            </option>
          ))}
        </Form.Select>
        {formik.touched.customers && (
          <Form.Text className="text-danger">
            {formik.errors.customers}
          </Form.Text>
        )}
      </Form.Group>

      <Form.Group className="mb-3">
        <Form.Label>Select Service</Form.Label>
        <Form.Select
          name="service"
          aria-label="Service"
          value={formik.values.service}
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
        {formik.touched.service && (
          <Form.Text className="text-danger">{formik.errors.service}</Form.Text>
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
        <Form.Label>Quantity</Form.Label>
        <Form.Control
          type="number"
          name="orderQuantity"
          value={formik.values.orderQuantity}
          placeholder="Enter The Order Quantity"
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
        />
        {formik.touched.orderQuantity && (
          <Form.Text className="text-danger">
            {formik.errors.orderQuantity}
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
          <Form.Text className="text-danger">{formik.errors.amount}</Form.Text>
        )}
      </Form.Group>

      <Form.Group className="mb-3">
        <Form.Label>Select PayementMode</Form.Label>
        <Form.Select
          name="payementMode"
          aria-label="PayementMethod"
          value={formik.values.payementMode}
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
        >
          <option value="" label="Select PayementMethod" />
          <option value="Cash">Cash-On-Delivery</option>
        </Form.Select>
        {formik.touched.payementMode && (
          <Form.Text className="text-danger">
            {formik.errors.payementMode}
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

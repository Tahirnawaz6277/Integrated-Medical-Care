import { useFormik } from "formik";
import React, { useEffect, useState } from "react";
import { Form, Button } from "react-bootstrap";
import * as Yup from "yup";
import { getUsers } from "../../../services/accountService";
import { SendPromotion } from "../../../services/promotionService";
import { useSelector } from "react-redux";
const AddNewPromotionScreen = () => {
  const [customers, setCustomers] = useState([]);
  const [message, setMessage] = useState("");

  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const formik = useFormik({
    initialValues: {
      promotion_Type: "",
      description: "",
      promoteToId: "",
    },
    validationSchema: Yup.object().shape({
      promotion_Type: Yup.string().required(),
      description: Yup.string().required(),
      promoteToId: Yup.string().required(),
    }),

    onSubmit: async (data) => {
      try {
        const res = await SendPromotion(data, loggedIn_User);

        if (res.success) {
          formik.resetForm();
          setMessage(res.message);
        }
      } catch (error) {
        if (error.response && error.response.status === 401) {
          setMessage(error.response.data.message);
        }
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
  }, []);

  return (
    <Form onSubmit={formik.handleSubmit}>
      <Form.Group className="mb-3 ">
        <Form.Label>Promotion Type</Form.Label>
        <Form.Control
          type="text"
          name="promotion_Type"
          value={formik.values.promotion_Type}
          placeholder="Enter Promotion Type"
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
        />
        {formik.touched.promotion_Type && (
          <Form.Text className="text-danger">
            {formik.errors.promotion_Type}
          </Form.Text>
        )}
      </Form.Group>

      <Form.Group className="mb-3">
        <Form.Label>Select Customer</Form.Label>
        <Form.Select
          name="promoteToId"
          aria-label="Customer"
          value={formik.values.promoteToId}
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

      <Form.Group className="mb-3 ">
        <Form.Label>Message</Form.Label>
        <Form.Control
          type="text"
          name="description"
          value={formik.values.description}
          placeholder="Enter Promotion Type"
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
        />
        {formik.touched.description && (
          <Form.Text className="text-danger">
            {formik.errors.description}
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

      <Button disabled={!formik.isValid} type="submit" variant="primary w-100">
        Submit
      </Button>
    </Form>
  );
};

export default AddNewPromotionScreen;

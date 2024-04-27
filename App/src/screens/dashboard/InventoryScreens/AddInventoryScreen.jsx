import { useFormik } from "formik";
import React, { useState } from "react";
import { Button, Col, Form, Row } from "react-bootstrap";
import * as Yup from "yup";
import { AddInventory } from "../../../services/InventoryService";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";

const AddInventoryScreen = () => {
  const [message, setMessage] = useState("");

  const navigate = useNavigate();
  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const formik = useFormik({
    initialValues: {
      service: "",
      availableQuantity: "",
      totalQuantity: "",
    },
    validationSchema: Yup.object().shape({
      service: Yup.string().required(),
      availableQuantity: Yup.number().required(),
      totalQuantity: Yup.number().required(),
    }),

    onSubmit: async (values) => {
      AddInventory(values, loggedIn_User)
        .then((res) => {
          if (res.success) {
            formik.resetForm();
            setMessage(res.message);
            setTimeout(() => navigate("/dashboard/inventory"), 1000);
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
          <Form.Label>Items / Service</Form.Label>
          <Form.Control
            type="text"
            name="service"
            value={formik.values.service}
            placeholder="Enter The Service / Item "
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.service && (
            <Form.Text className="text-danger">
              {formik.errors.service}
            </Form.Text>
          )}
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>availableQuantity</Form.Label>
          <Form.Control
            type="text"
            name="availableQuantity"
            value={formik.values.availableQuantity}
            placeholder="Enter availableQuantity"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.availableQuantity && (
            <Form.Text className="text-danger">
              {formik.errors.availableQuantity}
            </Form.Text>
          )}
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>totalQuantity</Form.Label>
          <Form.Control
            type="text"
            name="totalQuantity"
            value={formik.values.totalQuantity}
            placeholder="Enter totalQuantity"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.totalQuantity && (
            <Form.Text className="text-danger">
              {formik.errors.totalQuantity}
            </Form.Text>
          )}
        </Form.Group>

        <Button
          disabled={!formik.isValid}
          type="submit"
          variant="primary w-100"
        >
          Add Inventory
        </Button>
      </Form>
    </>
  );
};

export default AddInventoryScreen;

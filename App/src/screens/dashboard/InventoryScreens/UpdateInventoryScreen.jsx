import { useFormik } from "formik";
import React, { useState } from "react";
import { Button, Form } from "react-bootstrap";
import { useSelector } from "react-redux";
import { useLocation, useNavigate } from "react-router-dom";
import * as Yup from "yup";
import { UpdateInventory } from "../../../services/InventoryService";

const UpdateInventoryScreen = () => {
  const [message, setMessage] = useState("");
  const navigate = useNavigate();
  const { state } = useLocation();

  const { id, service, totalQuantity, availableQuantity } = state.inventory;

  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const formik = useFormik({
    initialValues: {
      service: service,
      availableQuantity: availableQuantity,
      totalQuantity: totalQuantity,
    },
    validationSchema: Yup.object().shape({
      service: Yup.string().required(),
      availableQuantity: Yup.number().required(),
      totalQuantity: Yup.number().required(),
    }),

    onSubmit: async (values) => {
      UpdateInventory(id, values, loggedIn_User)
        .then((res) => {
          if (res.success) {
            formik.resetForm();
            setMessage(res.message);
            setTimeout(() => navigate("/dashboard/inventory"), 1000);
          }
        })
        .catch((err) => {
          let errorMessage = "An error occurred.";

          if (err.response && err.response.data && err.response.data.title) {
            errorMessage = err.response.data.title;
          }

          setMessage(errorMessage);
        });
    },
  });

  return (
    <>
      <Form.Text
        className={`text-${
          message && message.toLowerCase().includes("error")
            ? "danger"
            : "success"
        }`}
        style={{ float: "end", fontSize: "20px", fontWeight: "bold" }}
      >
        {message}
      </Form.Text>

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
          Save
        </Button>
      </Form>
    </>
  );
};

export default UpdateInventoryScreen;

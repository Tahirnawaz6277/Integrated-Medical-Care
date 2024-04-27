import React, { Component } from "react";
import { useState } from "react";
import { Button, Dropdown, Form } from "react-bootstrap";

import { useFormik } from "formik";
import * as Yup from "yup";
import { useLocation, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import { AddService, updateService } from "../../../services/ManageService";

const UpdateServiceScreen = () => {
  const [message, setMessage] = useState("");
  const navigate = useNavigate();
  const [loading, setLoading] = useState(true);
  const { state } = useLocation();

  const {
    id,
    serviceName,
    charges,
    image,
    totalQuantity,
    availableQuantity,
    status,
  } = state.service;

  const { LOGGED_IN_USER: loggedIn_User } = useSelector(
    (state) => state.actionsReducer
  );

  const role = loggedIn_User.role;

  const formik = useFormik({
    initialValues: {
      serviceId: id,
      serviceName: serviceName,
      charges: charges,
      image: image,
      availableQuantity: availableQuantity,
      totalQuantity: totalQuantity,
      status: status,
    },
    validationSchema: Yup.object().shape({
      serviceName: Yup.string().required(),
      charges: Yup.string().required(),
    }),

    onSubmit: async (data) => {
      try {
        const res = await updateService(data, loggedIn_User);
        if (res.success) {
          setMessage(res.message);
          setTimeout(() => navigate("/dashboard/pservices"), 1000);
        }
      } catch (error) {
        if (error.response && error.response.status === 401) {
          history.push("/login");
          setMessage(error.response.data.message);
        }
      } finally {
        setLoading(false);
      }
    },
  });

  return (
    <>
      {message && (
        <Form.Text
          className={`text-${
            message.toLowerCase().includes("success") ? "" : "success"
          } `}
          style={{ float: "right", fontSize: "18px", fontWeight: "500px" }}
        >
          {message}
        </Form.Text>
      )}
      <Form onSubmit={formik.handleSubmit}>
        <Form.Group className="mb-3 ">
          <Form.Label>Service</Form.Label>
          <Form.Control
            type="text"
            name="serviceName"
            value={formik.values.serviceName}
            placeholder="Enter The Service"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.serviceName && (
            <Form.Text className="text-danger">
              {formik.errors.serviceName}
            </Form.Text>
          )}
        </Form.Group>

        <Form.Group className="mb-3 ">
          <Form.Label>charges</Form.Label>
          <Form.Control
            type="number"
            name="charges"
            value={formik.values.charges}
            placeholder="Enter The Charges "
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.charges && (
            <Form.Text className="text-danger">
              {formik.errors.charges}
            </Form.Text>
          )}
        </Form.Group>

        <Form.Group className="mb-3 ">
          <Form.Label>Image</Form.Label>
          <Form.Control
            type="text"
            name="image"
            value={formik.values.image}
            placeholder="Upload the Image "
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.image && (
            <Form.Text className="text-danger">{formik.errors.image}</Form.Text>
          )}
        </Form.Group>

        <Form.Group className="mb-3 ">
          <Form.Label>Available Quantity</Form.Label>
          <Form.Control
            type="number"
            name="availableQuantity"
            value={formik.values.availableQuantity}
            placeholder="Enter The Available Quantity of Service "
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.availableQuantity && (
            <Form.Text className="text-danger">
              {formik.errors.availableQuantity}
            </Form.Text>
          )}
        </Form.Group>

        <Form.Group className="mb-3 ">
          <Form.Label>Total Quantity</Form.Label>
          <Form.Control
            type="number"
            name="totalQuantity"
            value={formik.values.totalQuantity}
            placeholder="Enter The Total Quantity of Service "
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.totalQuantity && (
            <Form.Text className="text-danger">
              {formik.errors.totalQuantity}
            </Form.Text>
          )}
        </Form.Group>

        {role === "Admin" && (
          <Form.Group className="mb-3">
            <Form.Label>Status</Form.Label>
            <Form.Select
              name="status"
              value={formik.values.status}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
            >
              <option value="false">Pending</option>
              <option value="true">Approved</option>
            </Form.Select>
            {formik.touched.status && formik.errors.status && (
              <Form.Text className="text-danger">
                {formik.errors.status}
              </Form.Text>
            )}
          </Form.Group>
        )}

        <Form.Group className="mb-3">
          <Form.Control
            type="hidden"
            name="serviceId"
            value={formik.values.serviceId}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
        </Form.Group>

        <Button
          disabled={!formik.isValid}
          type="submit"
          variant="primary w-100"
        >
          Update Service
        </Button>
      </Form>
    </>
  );
};

export default UpdateServiceScreen;

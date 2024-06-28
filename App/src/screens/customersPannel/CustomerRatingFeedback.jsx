import React, { useEffect, useState } from "react";
import { Button, Col, Container, Form } from "react-bootstrap";
import "./feedbackRating.scss";
import { FaStar } from "react-icons/fa";
import { useFormik } from "formik";
import * as Yup from "yup";
import { useSelector } from "react-redux";
import { addFeedback } from "../../services/feedbackService";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { useLocation } from "react-router-dom";
import { GetSingleServiceProvider } from "../../services/serviceProvidersService";

const CustomerRatingFeedback = () => {
  const [services, setServices] = useState([]);
  const [rating, setRating] = useState(0);
  const location = useLocation();

  const handleClick = (value) => {
    setRating(value);
  };

  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );
  const fetchServices = (id) => {
    GetSingleServiceProvider(id)
      .then((res) => {

        console.log(res);
        if (res.success && res.data?.services) {
          setServices(res.data.services);
        }
      })
      .catch((err) => {
        console.log(err);
      });
  };
  const formik = useFormik({
    initialValues: {
      Description: "",
      Rating: "",
      ratedToId: "",
    },
    validationSchema: Yup.object().shape({
      Description: Yup.string().required(),
      ratedToId: Yup.string().required(),
    }),

    onSubmit: async (data) => {
      data.Rating = rating;
      try {
        const res = await addFeedback(data, loggedIn_User);
        if (res.success) {
          formik.resetForm();

          setRating(0);
          toast.success("Feedback Submited");
        }
      } catch (err) {
        setMessage(err.response.data.message);
        formik.setFieldValue(
          "general",
          err.response?.data?.message || err.message
        );
      }
    },
  });

  useEffect(() => {
    fetchServices(location.state.id);
  }, [loggedIn_User, location]);

  return (
    <>
      <ToastContainer />
      <Container className="feedback-container">
        <Form
          id="contact_form"
          className="contact_form"
          onSubmit={formik.handleSubmit}
        >
          <h1>Share Your Feedback</h1>

          {Array(5)
            .fill(0)
            .map((_, index) => {
              let startValue = index + 1;
              return (
                <FaStar
                  key={index}
                  onClick={() => handleClick(startValue)}
                  color={startValue <= rating ? "orange" : "black"}
                  style={{ fontSize: "28px", marginBottom: "30px" }}
                />
              );
            })}

          <p>How Would You Rate Your Experience?</p>

          <p> Tell us About Your Experience</p>

          <Form.Group className="mb-3">
            <Form.Label>Select Service</Form.Label>
            <Form.Select
              disabled={services.length === 0}
              name="ratedToId"
              value={formik.values.ratedToId}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
            >
              <option value="" label="Select Service" />

              {services.map((service) => (
                <option key={service.id} value={service.id}>
                  {service.serviceName}
                </option>
              ))}
            </Form.Select>

            {formik.touched.ratedToId && (
              <Form.Text className="text-danger">
                {formik.errors.ratedToId}
              </Form.Text>
            )}
          </Form.Group>

          <Form.Group className="mb-5">
            <Form.Label htmlFor="message"></Form.Label>

            <Form.Control
              disabled={services.length === 0}
              as="textarea"
              id="message"
              name="Description"
              rows={5}
              value={formik.values.Description}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
            />
            {formik.touched.Description && (
              <Form.Text className="text-danger">
                {formik.errors.Description}
              </Form.Text>
            )}
          </Form.Group>

          <Button
            disabled={!formik.isValid || services.length === 0}
            style={{ borderRadius: "0%" }}
            type="submit"
            className="btn"
          >
            Submit
          </Button>

          {services.length === 0 && <p>Not service Provided Yet</p>}
        </Form>
      </Container>
    </>
  );
};

export default CustomerRatingFeedback;

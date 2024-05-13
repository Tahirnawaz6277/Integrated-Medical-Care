import React, { useEffect, useState } from "react";
import { Button, Card, Container, Form, Modal } from "react-bootstrap";
import "./checkout.scss";
import { useFormik } from "formik";
import * as Yup from "yup";
import { useSelector } from "react-redux";
import { AddOrder } from "../../services/orderService";
import Swal from "sweetalert2";
import { useNavigate } from "react-router-dom";

const CheckoutScreen = () => {
  const [services, setServices] = useState([]);
  const [showConfirmationModal, setShowConfirmationModal] = useState(false);
  const [message, setMessage] = useState("");
  const [show, setShow] = useState(true);

  const navigate = useNavigate();

  const getCartServices = useSelector((state) => state.actionsReducer.Cart);
  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const formik = useFormik({
    initialValues: {
      contact: "",
      address: "",
      paymentMode: "",
    },
    validationSchema: Yup.object().shape({
      contact: Yup.string().required(),
      address: Yup.string().required(),
      paymentMode: Yup.string().required(),
    }),

    onSubmit: async () => {
      setShowConfirmationModal(true);
    },
  });

  const handleConfirmedSubmit = async () => {
    try {
      const orderDetails = {
        contact: formik.values.contact,
        address: formik.values.address,
        amount: services.map((service) => service.charges * service.quantity),
        paymentMode: formik.values.paymentMode,
        serviceId: services.map((service) => service.service_id),
        quantity: services.map((service) => service.quantity),
      };

      const res = await AddOrder(orderDetails, loggedIn_User);

      if (res.success) {
        setTimeout(() => {
          formik.resetForm();
          setMessage(res.data.message);
          Swal.fire({
            title: "Congratulation's",
            text: "Order Placed Successfully!",
            icon: "success",
          }).then(() => {
            navigate("/dashboard/provider_services");
          });
        }, 100);
      }

      setShow(false);
    } catch (err) {
      setMessage(err.response.data.message);
    }

    setShowConfirmationModal(false);
  };

  useEffect(() => {
    setServices(getCartServices);
  }, [getCartServices]);

  return (
    <>
      <Container className="d-flex justify-content-center align-items-center">
        {show && (
          <Card className="checkout-form">
            <Card.Body>
              <div className="card-text">
                <Form onSubmit={formik.handleSubmit}>
                  <Form.Group className="mb-3 ">
                    <Form.Label>Contact</Form.Label>
                    <Form.Control
                      type="text"
                      name="contact"
                      value={formik.values.contact}
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
                    onClick={
                      !formik.isValid
                        ? () => {
                            setShowConfirmationModal(true);
                          }
                        : () => {
                            setShowConfirmationModal(false);
                          }
                    }
                  >
                    Pay Now
                  </Button>
                </Form>
              </div>
            </Card.Body>
          </Card>
        )}

        {/* Confirmation modal */}
        <Modal
          show={showConfirmationModal}
          onHide={() => setShowConfirmationModal(false)} // Hide modal when closed
          backdrop="static"
          keyboard={false}
        >
          <Modal.Header closeButton>
            <Modal.Title>Order Confirmation</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            Are you sure you want to proceed with the payment?
          </Modal.Body>
          <Modal.Footer>
            <Button
              variant="secondary"
              onClick={() => setShowConfirmationModal(false)}
            >
              Cancel
            </Button>
            <Button variant="primary" onClick={handleConfirmedSubmit}>
              Confirm
            </Button>
          </Modal.Footer>
        </Modal>
      </Container>
    </>
  );
};

export default CheckoutScreen;

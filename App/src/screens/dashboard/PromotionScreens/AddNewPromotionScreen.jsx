import { useFormik } from "formik";
import React, { useEffect, useState } from "react";
import { Form, Button, Spinner, Card } from "react-bootstrap";
import * as Yup from "yup";
import { getUsers } from "../../../services/accountService";
import { SendPromotion } from "../../../services/promotionService";
import { useSelector } from "react-redux";
const AddNewPromotionScreen = () => {
  const [customers, setCustomers] = useState([]);
  const [message, setMessage] = useState("");
  const [loading, setLoading] = useState(false);
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
        setLoading(true);
        const res = await SendPromotion(data, loggedIn_User);

        if (res.success) {
          formik.resetForm();
          setMessage(res.message);
        }
      } catch (error) {
        if (error.response && error.response.status === 401) {
          setMessage(error.response.data.message);
        }
      } finally {
        setLoading(false);
      }
    },
  });

  useEffect(() => {
    getUsers()
      .then((res) => {
        if (res.success) {
          var customers = res.data.filter((user) => {
            return user.role === "Customer";
          });

          setCustomers(customers);
        }
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  return (
    <Card>
      <Card.Header
        style={{
          background: "black",
          padding: "20px",
          color: "white",
        }}
      >
        Manage Promotion
      </Card.Header>

      <Card.Body>
        {message && (
          <Form.Text
            className={`text-${
              message.toLowerCase().includes("success") ? "danger" : "success"
            }`}
            style={{ fontSize: "20px", fontWeight: "bold" }}
          >
            {message}
          </Form.Text>
        )}

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

          <Form.Group className="mb-3">
            <Form.Label>Message</Form.Label>
            <Form.Control
              as="textarea"
              name="description"
              rows={4}
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

          <Button
            disabled={!formik.isValid}
            type="submit"
            className="btn-custom"
          >
            {loading ? (
              <>
                <span
                  className="spinner-border spinner-border-sm"
                  role="status"
                  aria-hidden="true"
                ></span>
                <span>Sending...</span>
              </>
            ) : (
              <>Send Promotion</>
            )}
          </Button>
        </Form>
      </Card.Body>
    </Card>
  );
};

export default AddNewPromotionScreen;

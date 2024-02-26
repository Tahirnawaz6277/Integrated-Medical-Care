import { useState } from "react";
import { Button, Form } from "react-bootstrap";
import { AddServiceProviders } from "../../services/serviceProvidersService";
import { useFormik } from "formik";
import * as Yup from "yup";
import "../site/signup.scss";
import { useNavigate } from "react-router";

const AddNewHCPScreen = () => {
  const navigate = useNavigate();
  const [message, setMessage] = useState("");
  const formik = useFormik({
    initialValues: {
      providerName: "",
    },
    validationSchema: Yup.object().shape({
      providerName: Yup.string().required(),
    }),

    onSubmit: async (data) => {
      try {
        const res = await AddServiceProviders(data);

        if (res.success) {
          formik.resetForm();
          setMessage(res.message);
          formik.resetForm();
          setTimeout(() => navigate("/dashboard/healthcareproviders"), 1000);
        }
      } catch (err) {
        setMessage(err.response.data.message);
      }
    },
  });

  return (
    <>
      <Form onSubmit={formik.handleSubmit}>
        <Form.Group className="mb-3 ">
          <Form.Label>ProviderName</Form.Label>
          <Form.Control
            type="text"
            name="providerName"
            value={formik.values.providerName}
            placeholder="Enter The Provider Name"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.providerName && (
            <Form.Text className="text-danger">
              {formik.errors.providerName}
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

        <Button
          disabled={!formik.isValid}
          type="submit"
          variant="primary w-100"
        >
          Submit
        </Button>
      </Form>
    </>
  );
};

export default AddNewHCPScreen;

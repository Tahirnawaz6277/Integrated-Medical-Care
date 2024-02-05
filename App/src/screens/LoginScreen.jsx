// import React from "react";
// import {
//   Button,
//   Form,
//   FormGroup,
//   FormControl,
//   FormLabel,
// } from "react-bootstrap";
// import { loginUser } from "../services/accountService";
// import { useFormik } from "formik";
// import * as Yup from "yup";
// import { useNavigate } from "react-router";

// const LoginScreen = () => {
//   const navigate = useNavigate();
//   const formik = useFormik({
//     initialValues: {
//       email: "",
//       password: "",
//     },
//     validationSchema: Yup.object().shape({
//       email: Yup.string().email().required("Email is required"),
//       password: Yup.string().required("Password is required"),
//     }),
//     onSubmit: async (values, { setFieldError }) => {
//       try {
//         const res = await loginUser(values);
//         if (res.success) {
//           formik.resetForm();
//           localStorage.setItem("token", res.data.jwtToken);
//           navigate("/dashboard");
//         }
//       } catch (error) {
//         if (error.response && error.response.data) {
//           console.log("Error response from server:", error.response.data);

//           // Check if the error message exists and is not empty
//           if (
//             error.response.data.message &&
//             error.response.data.message.trim() !== ""
//           ) {
//             if (error.response.data.message === "Invalid email or password") {
//               console.log("Setting password error");
//               setFieldError(
//                 "password",
//                 "Incorrect password. Please try again."
//               );
//               console.log("Password error set");
//             } else {
//               setFieldError("general", error.response.data.message);
//             }
//           }
//         }
//       }
//     },
//   });

//   return (
//     <>
//       <Form onSubmit={formik.handleSubmit}>
//         <FormGroup>
//           <FormLabel>Email address</FormLabel>
//           <FormControl
//             required
//             type="email"
//             name="email"
//             value={formik.values.email}
//             placeholder="name@gmail.com"
//             onChange={formik.handleChange}
//             onBlur={formik.handleBlur}
//           />
//           {formik.touched.email && (
//             <Form.Text className="text-danger">{formik.errors.email}</Form.Text>
//           )}
//         </FormGroup>

//         <FormGroup>
//           <FormLabel>Password</FormLabel>
//           <FormControl
//             required
//             type="password"
//             name="password"
//             placeholder="Enter the password"
//             onChange={formik.handleChange}
//             onBlur={formik.handleBlur}
//             value={formik.values.password}
//           />
//           {formik.touched.password && (
//             <Form.Text className="text-danger">
//               {formik.errors.password}
//             </Form.Text>
//           )}
//         </FormGroup>
//         {/* <Form.Text className="text-success">{formik.values.general}</Form.Text> */}

//         <Button
//           disabled={!formik.isValid}
//           type="submit"
//           variant="primary w-100"
//         >
//           Login
//         </Button>
//       </Form>
//     </>
//   );
// };

// export default LoginScreen;

import React from "react";
import {
  Button,
  Form,
  FormGroup,
  FormControl,
  FormLabel,
} from "react-bootstrap";
import { loginUser } from "../services/accountService";
import { useFormik } from "formik";
import * as Yup from "yup";
import { useNavigate } from "react-router";

const LoginScreen = () => {
  const navigate = useNavigate();
  const formik = useFormik({
    initialValues: {
      email: "",
      password: "",
    },
    validationSchema: Yup.object().shape({
      email: Yup.string().email().required("Email is required"),
      password: Yup.string().required("Password is required"),
    }),
    onSubmit: async (values, { setFieldError }) => {
      try {
        const res = await loginUser(values);
        if (res.success) {
          formik.resetForm();
          localStorage.setItem("token", res.data.jwtToken);
          navigate("/dashboard");
        }
      } catch (error) {
        if (error.response?.data == "Invalid email or password.") {
          setFieldError(
            "password",
            "Incorrect email or password. Please try again."
          );
        } else {
          setFieldError("general", "An error occurred. Please try again.");
        }
      }
    },
  });

  return (
    <>
      <Form onSubmit={formik.handleSubmit}>
        <FormGroup>
          <FormLabel>Email address</FormLabel>
          <FormControl
            required
            type="email"
            name="email"
            value={formik.values.email}
            placeholder="name@gmail.com"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.email && (
            <Form.Text className="text-danger">{formik.errors.email}</Form.Text>
          )}
        </FormGroup>

        <FormGroup>
          <FormLabel>Password</FormLabel>
          <FormControl
            required
            type="password"
            name="password"
            placeholder="Enter the password"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.password}
          />
          {formik.touched.password && (
            <Form.Text className="text-danger">
              {formik.errors.password}
            </Form.Text>
          )}
        </FormGroup>

        <Button
          disabled={!formik.isValid}
          type="submit"
          variant="primary w-100"
        >
          Login
        </Button>
      </Form>
    </>
  );
};

export default LoginScreen;

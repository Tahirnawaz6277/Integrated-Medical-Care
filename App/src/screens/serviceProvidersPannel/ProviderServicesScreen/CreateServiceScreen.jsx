import React, { Component, useEffect } from "react";
import { useState } from "react";
import { Button, ButtonGroup, Col, Container, Dropdown, Form, Row } from "react-bootstrap";

import { useFormik } from "formik";
import * as Yup from "yup";
import { useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import { AddService } from "../../../services/ManageService";
import { getInventory } from "../../../services/InventoryServices";
import { UpdateSingleInventory } from "../../../services/InventoryService";

const CreateServiceScreen = () => {
  const [inventory,setInventory] = useState([]);
  const [message, setMessage] = useState("");
  const navigate = useNavigate();

  const [loading, setLoading] = useState(true);
  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const fetchInventory = async () => {
    try {
      const response = await getInventory(loggedIn_User);
      setInventory(response.data);
     
    } catch (error) {
      console.error("Failed to fetch inventory", error);
    } finally {
      setLoading(false);
    }
  };


  const formik = useFormik({
    initialValues: {
      serviceName: "",
      charges: 0,
      availableQuantity:  0,
      totalQuantity:  0,
      qualityTermsAgreedWithAdmin: false,
      selectedId:"",

    },
    validationSchema: Yup.object().shape({
      serviceName: Yup.string().required("Service name is required"),
      charges: Yup.number().required("Charges are required"),
      availableQuantity: Yup.number().required("Available quantity is required"),
      totalQuantity: Yup.number().required("Total quantity is required"),
      qualityTermsAgreedWithAdmin: Yup.bool().oneOf(
        [true],
        "You must agree to the quality terms"
      ),
    }),

    onSubmit: async (data) => {
      try {
        const res = await AddService(data, loggedIn_User);

        if (res.success) {

          const inventoryRes = await UpdateSingleInventory(data.selectedId , res.data.availableQuantity,inventory,loggedIn_User);
        
          if(inventoryRes.success){

            formik.resetForm();
            setMessage(res.message);
            setTimeout(() => navigate("/dashboard/pservices"), 1000);
          }
        
        }
      } catch (error) {
        if (error.response && error.response.status === 401) {
          // Redirect to login page or handle unauthorized access
          history.push("/login");
          setMessage(error.response.data.message);
        }
      } finally {
        setLoading(false);
      }
    },
  });


  useEffect(()=>{
    fetchInventory();
  },[]);






const handleDropdownSelect = (eventKey) => {
  const selectedItem = inventory.find(item => item.id === eventKey);
  if (selectedItem) {
    formik.setFieldValue("availableQuantity", selectedItem.availableQuantity);
    formik.setFieldValue("totalQuantity", selectedItem.totalQuantity);
  formik.setFieldValue("selectedId", eventKey);
  }

  // console.log(eventKey ,selectedItem.availableQuantity);
};

  return (
<>
      {message && (
        <Form.Text
          className={`text-${
            message.toLowerCase().includes("success") ? "success" : "danger"
          }`}
          style={{ fontSize: "20px", fontWeight: "bold" }}
        >
          {message}
        </Form.Text>
      )}
      <Form onSubmit={formik.handleSubmit}>
        <Form.Group className="mb-3">
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

        <Form.Group className="mb-3">
          <Form.Label>Charges</Form.Label>
          <Form.Control
            type="number"
            name="charges"
            value={formik.values.charges}
            placeholder="Enter The Charges"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.charges && (
            <Form.Text className="text-danger">
              {formik.errors.charges}
            </Form.Text>
          )}
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Available Quantity</Form.Label>
          <Dropdown as={ButtonGroup} onSelect={handleDropdownSelect}>
            <Dropdown.Toggle variant="secondary" id="dropdownMenuButton">
     
            </Dropdown.Toggle>
            <Dropdown.Menu style={{width:"100%"}}>
              {inventory.map((item) => (
                <Dropdown.Item key={item.id} eventKey={item.id}>
                  <span style={{ display: 'inline-block', width: '100px' }}>{item.service}</span> {item.availableQuantity}
                </Dropdown.Item>
              ))} 
            </Dropdown.Menu>
          </Dropdown>
          <Form.Control
            type="number"
            name="availableQuantity"
       
            value= {formik.values.availableQuantity}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            style={{ marginTop: "10px" }}
          />
          {formik.touched.availableQuantity && (
            <Form.Text className="text-danger">
              {formik.errors.availableQuantity}
            </Form.Text>
          )}
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Total Quantity</Form.Label>
          <Form.Control
            type="number"
            name="totalQuantity"
            value={formik.values.totalQuantity}
            placeholder="Enter The Total Quantity of Service"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
          />
          {formik.touched.totalQuantity && (
            <Form.Text className="text-danger">
              {formik.errors.totalQuantity}
            </Form.Text>
          )}
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Check
            type="checkbox"
            name="qualityTermsAgreedWithAdmin"
            id="qualityTermsAgreedWithAdmin"
            label="Check to agree with Administrator"
            checked={formik.values.qualityTermsAgreedWithAdmin}
            onChange={formik.handleChange}
            isInvalid={
              formik.errors.qualityTermsAgreedWithAdmin &&
              formik.touched.qualityTermsAgreedWithAdmin
            }
          />
          <Form.Control.Feedback type="invalid">
            {formik.errors.qualityTermsAgreedWithAdmin}
          </Form.Control.Feedback>
        </Form.Group>
        <Button
          disabled={!formik.isValid}
          type="submit"
          variant="primary w-100"
        >
          Submit
        </Button>
      </Form>
    </>  );
};

export default CreateServiceScreen;






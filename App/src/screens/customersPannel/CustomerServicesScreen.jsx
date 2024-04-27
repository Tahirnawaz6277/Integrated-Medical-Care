import React, { useEffect, useState } from "react";
import { NavLink } from "react-router-dom";
import {
  Button,
  Card,
  Col,
  Form,
  FormControl,
  InputGroup,
  Row,
  Spinner,
  Table,
} from "react-bootstrap";
import { getServices } from "../../../src/services/ManageService";
import "./style.scss";
import { useDispatch, useSelector } from "react-redux";
import { AddToCart } from "../../Redux/Action";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const CustomerServicesScreen = () => {
  const [services, setServices] = useState([]);
  const [loading, setLoading] = useState(true);

  const dispatch = useDispatch();
  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const fetchServices = () => {
    getServices(loggedIn_User)
      .then((res) => {
        if (res.success) {
          setServices(res.data);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  };

  const handleCart = (service, index) => {
    const data = {
      id: index,
      service_id: service.id,
      serviceName: service.serviceName,
      charges: service.charges,
      service_img: "https://bootdey.com/img/Content/avatar/avatar1.png",
      quantity: 0,
    };

    dispatch(AddToCart(data));
    toast("Added to cart!");
  };

  useEffect(() => {
    fetchServices();
  }, [loggedIn_User]);

  return (
    <>
      <ToastContainer />
      <Row>
        <Col className="col-md-12">
          <InputGroup className="mb-3">
            <FormControl
              placeholder="Search"
              aria-label="Search"
              aria-describedby="basic-addon2"
            />
            <Button variant="primary" id="button-addon2">
              <i className="fas fa-search"></i>
            </Button>
          </InputGroup>
        </Col>
      </Row>

      <Row className="row ">
        {loading && <Spinner animation="border" />}

        {services.length > 0 ? (
          services.map((service, index) => (
            <Col className="col-md-3 mb-3" key={index}>
              <Card style={{ cursor: "pointer" }}>
                <NavLink to="/dashboard/service_details">
                  <Card.Img
                    src="../images/tablet.jpg"
                    className="card-img-top"
                    alt="..."
                  />
                </NavLink>
                <Card.Body>
                  <Card.Text>
                    <strong>Service:</strong> {service.serviceName}
                  </Card.Text>

                  {service.status && (
                    <Card.Text>
                      <strong>Charges:</strong>

                      {service.charges}
                    </Card.Text>
                  )}

                  <Card.Text>
                    <strong>Provided By:</strong>{" "}
                    {`${service.user.firstName} ${service.user.lastName}`}
                  </Card.Text>
                  <Card.Text>
                    <strong>Publish Date:</strong> {service.createdAt}
                  </Card.Text>
                  <div
                    style={{
                      display: "flex",
                      justifyContent: "space-between",
                    }}
                  >
                    <Button
                      variant={service.status ? "primary" : "danger"}
                      className="add-to-cart"
                      onClick={() => {
                        handleCart(service, index);
                      }}
                      disabled={!service.status}
                    >
                      {service.status
                        ? "Add to Cart"
                        : "Service Pending Approval"}
                    </Button>
                  </div>
                </Card.Body>
              </Card>
            </Col>
          ))
        ) : (
          <b>Services Not Available</b>
        )}
      </Row>
    </>
  );
};

export default CustomerServicesScreen;

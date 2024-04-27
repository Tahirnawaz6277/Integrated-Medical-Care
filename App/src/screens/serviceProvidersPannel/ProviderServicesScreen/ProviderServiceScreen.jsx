import React, { useEffect, useState } from "react";
import { Button, Card, Spinner, Table } from "react-bootstrap";
import {
  getServices,
  DeleteService,
  getService,
} from "../../../services/ManageService";
import { NavLink, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";

const ProviderServiceScreen = () => {
  const [services, setServices] = useState([]);
  const [service, setService] = useState([]);
  const [loading, setLoading] = useState(true);

  const navigate = useNavigate();

  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const handleDelete = (id) => {
    DeleteService(id, loggedIn_User)
      .then((res) => {
        if (res.success) {
          fetchServices();
        }
      })
      .catch((error) => {
        console.log(error.message);
      });
  };

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

  const handleEditService = (id) => {
    getService(id, loggedIn_User)
      .then((res) => {
        if (res.success) {
          navigate("/dashboard/updateService", {
            state: { service: res.data },
          });
        }
      })
      .catch((err) => {
        console.log(err);
      });
  };

  useEffect(() => {
    fetchServices();
  }, [loggedIn_User]);

  return (
    <Card>
      <Card.Header
        style={{
          background: "black  ",
          padding: "20px ",
          color: "white",
        }}
      >
        Manage Services
        <NavLink to="/dashboard/createService">
          <Button className="float-end">Add New Service</Button>
        </NavLink>
      </Card.Header>

      <Card.Body>
        {loading && <Spinner size="sm" />}
        <Table responsive="sm">
          <thead>
            <tr>
              <th>#</th>
              <th>Service</th>
              <th>Charges</th>
              <th>Provided By</th>
              <th>Role</th>
              <th>Approval status</th>
              <th>Date Created</th>
              <th>Action</th>
            </tr>
          </thead>

          <tbody>
            {services.map((service, index) => (
              <tr key={index}>
                <td>{index}</td>
                <td>{service.serviceName}</td>
                <td>{service.charges}</td>
                <td>{`${service.user.firstName}  ${service.user.lastName}`}</td>

                <td>{service.user.role}</td>

                <td>
                  <span
                    style={{
                      color: service.status ? "green" : "red",
                      fontWeight: "bold",
                    }}
                  >
                    {service.status ? "Approved" : "Pending"}
                  </span>
                </td>
                <td>{service.createdAt}</td>

                <td style={{ display: "flex", gap: "8px" }}>
                  <Button
                    variant="primary"
                    onClick={() => {
                      handleEditService(service.id);
                    }}
                  >
                    Edit
                  </Button>
                  <Button
                    variant="danger"
                    onClick={() => {
                      handleDelete(service.id);
                    }}
                  >
                    Delete
                  </Button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      </Card.Body>
    </Card>
  );
};

export default ProviderServiceScreen;

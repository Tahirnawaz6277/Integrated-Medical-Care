import React, { useEffect, useState } from "react";
import { Button, Card, Spinner, Table } from "react-bootstrap";
import { getServices, DeleteService } from "../../../services/ManageService";
import { NavLink } from "react-router-dom";
import { useSelector } from "react-redux";

const ServiceScreen = () => {
  const [services, setServices] = useState([]);
  const [loading, setLoading] = useState(true);

  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const handleDelete = (id) => {
    DeleteService(id, loggedIn_User)
      .then((res) => {
        if (res.success) {
          getServices();
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

  useEffect(() => {
    fetchServices();
  }, [loggedIn_User]);

  return (
    <Card>
      <Card.Header>
        Manage Services
        <NavLink to="/dashboard/AddNewServiceScreen">
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
                <td>{service.createdAt}</td>

                <td style={{ display: "flex", gap: "8px" }}>
                  <Button variant="primary">Edit</Button>
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

export default ServiceScreen;

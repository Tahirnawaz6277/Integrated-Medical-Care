import React, { useEffect, useState } from "react";
import { Button, Card, Spinner, Table } from "react-bootstrap";
import { getServices } from "../../services/ManageService";

const ServiceScreen = () => {
  const [services, setServices] = useState([]);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    getServices()
      .then((res) => {
        if (res.success) {
          setServices(res.data);

          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  }, []);

  return (
    <Card>
      <Card.Header>
        Manage Services
        <Button className="float-end">Add New Service</Button>
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
                      handleDelete(user.id);
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

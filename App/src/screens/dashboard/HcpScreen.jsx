import React, { useEffect, useState } from "react";
import { Button, Card, Table } from "react-bootstrap";
import { getServiceProviders } from "../../services/serviceProvidersService";

const HcpScreen = () => {
  const [serviceProviders, setServiceProviders] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getServiceProviders()
      .then((res) => {
        if (res.success) {
          setServiceProviders(res.data);

          setLoading(false);
        }
      })
      .catch((error) => {
        console.log(error);
        setLoading(true);
      });
  }, []);

  return (
    <>
      <Card>
        <Card.Header>
          Manage Health Care Providers
          <Button className="float-end">Add New HealthCare Provider</Button>
        </Card.Header>

        <Card.Body>
          <Table responsive="sm">
            <thead>
              <tr>
                <th>#</th>
                <th>Name</th>

                <th>Date Created</th>
                <th>Action</th>
              </tr>
            </thead>

            <tbody>
              {serviceProviders.map((serviceProvider, index) => (
                <tr key={index}>
                  <td>{index}</td>
                  <td>{serviceProvider.providerName}</td>
                  <td>{serviceProvider.createdAt}</td>

                  <td style={{ display: "flex", gap: "8px" }}>
                    <Button variant="primary">Edit</Button>

                    <Button className="btn btn-danger">Delete</Button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        </Card.Body>
      </Card>
    </>
  );
};

export default HcpScreen;

import React, { useEffect, useState } from "react";
import { Button, Card, Spinner, Table } from "react-bootstrap";
import {
  GetServiceProviders,
  DeleteServiceProviders,
} from "../../services/serviceProvidersService";
import { NavLink } from "react-router-dom";

const HcpScreen = () => {
  const [HCP, setHCP] = useState([]);
  const [loading, setLoading] = useState(true);

  const updatedHCP = () => {
    GetServiceProviders()
      .then((res) => {
        if (res.success) {
          setHCP(res.data);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  };
  const handleDelete = (id) => {
    DeleteServiceProviders(id)
      .then((res) => {
        if (res.success) {
          updatedHCP();
        }
      })
      .catch((err) => {});
  };
  useEffect(() => {
    updatedHCP();
  }, []);

  return (
    <>
      <Card>
        <Card.Header>
          Manage Health Care Providers
          <NavLink to="/dashboard/AddNewHCPScreen">
            <Button className="float-end">Add NEW HCP</Button>
          </NavLink>
        </Card.Header>

        <Card.Body>
          {loading && <Spinner animation="border" />}
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
              {HCP.map((user, index) => (
                <tr key={index}>
                  <td>{index}</td>
                  <td>{user.providerName}</td>
                  <td>{user.createdAt}</td>
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
    </>
  );
};

export default HcpScreen;

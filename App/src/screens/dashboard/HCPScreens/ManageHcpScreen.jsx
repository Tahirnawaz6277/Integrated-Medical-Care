import React, { useEffect, useState } from "react";
import { Button, Card, Spinner, Table } from "react-bootstrap";

import { NavLink } from "react-router-dom";
import { GetServiceProviders } from "../../../services/serviceProvidersService";
import { deleteUser } from "../../../services/accountService";

const ManageHcpScreen = () => {
  const [HCP, setHCP] = useState([]);
  const [loading, setLoading] = useState(true);

  const updatedHCP = () => {
    GetServiceProviders()
      .then((res) => {
        if (res.success) {
          // Filter the list of health care providers based on the role being "ServiceProviders"
          const serviceProviders = res.data.filter(
            (hcp) => hcp.role === "ServiceProvider"
          );
          setHCP(serviceProviders);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  };
  const handleDelete = (id) => {
    deleteUser(id)
      .then((res) => {
        console.log(res);
        if (res.success) {
          updatedHCP();
        }
      })
      .catch((err) => {
        console.log(err);
      });
  };
  useEffect(() => {
    updatedHCP();
  }, []);

  return (
    <>
      <Card>
        <Card.Header
          style={{
            background: "black  ",
            padding: "20px ",
            color: "white",
          }}
        >
          Manage Health Care Providers
          <NavLink to="/dashboard/AddNewHCPScreen">
            <Button className="btn-custom float-end">Add NEW HCP</Button>
          </NavLink>
        </Card.Header>

        <Card.Body>
          {loading && <Spinner animation="border" />}
          <Table responsive="sm">
            <thead>
              <tr>
                <th>#</th>
                <th>Name</th>
                <th>Service</th>

                <th>Date Created</th>
                <th>Action</th>
              </tr>
            </thead>

            <tbody>
              {HCP.map((user, index) => (
                <tr key={index}>
                  <td>{index}</td>
                  <td>{user.firstName}</td>
                  <td>{user.serviceProviderType.providerName}</td>
                  <td>{user.createdAt}</td>
                  <td style={{ display: "flex", gap: "8px" }}>
                    <Button
                      variant="danger"
                      className="btn-custom"
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

export default ManageHcpScreen;

import React, { useEffect, useState } from "react";
import { Button, Card, Spinner, Table } from "react-bootstrap";
import {
  GetServiceProviders,
  DeleteServiceProviders,
  AddServiceProviders,
  UpdateServiceProviders,
} from "../../services/serviceProvidersService";

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
        console.log(err);
      });
  };

  const handleDelete = (id) => {
    DeleteServiceProviders(id)
      .then((res) => {
        if (res.success) {
          updatedHCP();
        }
      })
      .catch((err) => {
        console.log(err.message);
      });
  };
  useEffect(() => {
    updatedHCP();
  }, []);

  return (
    <>
      <Card>
        <Card.Header>
          Manage Health Care Providers
          <Button className="float-end">Add NEW HCP</Button>
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
                  <td>{index + 1}</td>
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

import React from "react";
import { Button, Card, Table } from "react-bootstrap";

const ServiceScreen = () => {
  return (
    <Card>
      <Card.Header>
        Manage Services
        <Button className="float-end">Add New Service</Button>
      </Card.Header>

      <Card.Body>
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
            <tr>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
            </tr>
          </tbody>
        </Table>
      </Card.Body>
    </Card>
  );
};

export default ServiceScreen;

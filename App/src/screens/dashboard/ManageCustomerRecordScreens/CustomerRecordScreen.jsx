import React from "react";
import { Card, Table } from "react-bootstrap";

const CustomerRecordScreen = () => {
  return (
    <Card>
      <Card.Header
        style={{
          background: "black  ",
          padding: "20px ",
          color: "white",
        }}
      >
        Manage Customer Record
      </Card.Header>

      <Card.Body>
        <Table responsive="sm">
          <thead>
            <tr>
              <th>#</th>
              <th>First Name</th>
              <th>Last Name</th>
              <th>Email Address</th>
              <th>Gender</th>
              <th>Account Status</th>
              <th>Ordered Services</th>

              <th>Rating</th>

              <th>Feedbacks</th>
            </tr>
          </thead>

          <tbody></tbody>
        </Table>
      </Card.Body>
    </Card>
  );
};

export default CustomerRecordScreen;

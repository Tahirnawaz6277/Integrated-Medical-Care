import React from "react";
import { Card, Table } from "react-bootstrap";

export const HcpRecordScreen = () => {
  return (
    <Card>
      <Card.Header>Manage Service Provider Records</Card.Header>

      <Card.Body>
        <Table responsive="sm">
          <thead>
            <tr>
              <th>#</th>
              <th>Name</th>
              <th>Phone Number</th>
              <th>Provided Services</th>
              <th>Service Rating</th>
              <th>Service Feedbacks</th>
              <th>Ordered Services</th>
            </tr>
          </thead>

          <tbody></tbody>
        </Table>
      </Card.Body>
    </Card>
  );
};

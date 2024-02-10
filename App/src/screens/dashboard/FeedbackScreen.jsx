import React from "react";
import { Button, Card, Table } from "react-bootstrap";

const FeedbackScreen = () => {
  return (
    <Card>
      <Card.Header>Manage Feedbacks</Card.Header>

      <Card.Body>
        <Table responsive="sm">
          <thead>
            <tr>
              <th>#</th>
              <th>Message</th>
              <th>Added By</th>
              <th>Service</th>
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

export default FeedbackScreen;

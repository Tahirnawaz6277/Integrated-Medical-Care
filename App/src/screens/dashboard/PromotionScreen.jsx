import React from "react";
import { Button, Card, Table } from "react-bootstrap";

const PromotionScreen = () => {
  return (
    <Card>
      <Card.Header>
        Manage Promotion
        <Button className="float-end">Send New Promotion</Button>
      </Card.Header>

      <Card.Body>
        <Table responsive="sm">
          <thead>
            <tr>
              <th>#</th>
              <th>Promotion Type</th>
              <th>Promot To </th>
              <th></th>
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

export default PromotionScreen;

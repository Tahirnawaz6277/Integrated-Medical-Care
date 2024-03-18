import React from "react";
import { Card, Table } from "react-bootstrap";

const AgreementScreen = () => {
  return (
    <Card>
      <Card.Header>Manage Agreement</Card.Header>

      <Card.Body>
        <Table responsive="sm">
          <thead>
            <tr>
              <th>#</th>
              <th>Type</th>
              <th>Amount</th>
              <th>Description</th>
            </tr>
          </thead>

          <tbody></tbody>
        </Table>
      </Card.Body>
    </Card>
  );
};

export default AgreementScreen;

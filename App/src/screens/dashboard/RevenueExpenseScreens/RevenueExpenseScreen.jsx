import { Button, Card, Table } from "react-bootstrap";

const RevenueExpenseScreen = () => {
  return (
    <Card>
      <Card.Header>Manage Revenue & Expense</Card.Header>

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

export default RevenueExpenseScreen;

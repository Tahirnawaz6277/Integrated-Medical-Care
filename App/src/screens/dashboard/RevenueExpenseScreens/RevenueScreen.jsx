import { useEffect, useState } from "react";
import { Button, Card, Spinner, Tab, Table, Tabs } from "react-bootstrap";
import {
  deleteRevenue,
  getRevenue,
  getRevenues,
} from "../../../services/revenueService";
import { useSelector } from "react-redux";
import { NavLink, useNavigate } from "react-router-dom";
import "../RevenueExpenseScreens/revenueExpense.scss";
import ExpenseScreen from "./ExpenseScreen";

const RevenueScreen = () => {
  const [loading, setLoading] = useState(true);
  const [Revenue, setRevenues] = useState([]);
  const navigate = useNavigate();

  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const fetchRevenues = () => {
    getRevenues(loggedIn_User)
      .then((res) => {
        if (res.success) {
          setRevenues(res.data);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  };

  const handleDeleteRevenue = (id) => {
    deleteRevenue(id, loggedIn_User)
      .then((res) => {
        if (res.success) {
          fetchRevenues();
        }
      })
      .catch((error) => {
        console.log(error.message);
      });
  };

  const handleEditRevenue = (id) => {
    getRevenue(id, loggedIn_User)
      .then((res) => {
        if (res.success) {
          navigate("/dashboard/updateRevenue", {
            state: { revenue: res.data },
          });
        }
      })
      .catch((err) => {
        console.log(err);
      });
  };
  useEffect(() => {
    fetchRevenues();
  }, [loggedIn_User]);

  return (
    <Tabs defaultActiveKey="home">
      <Tab eventKey="home" title="Manage Revenue" className="revenueTab">
        <Card>
          <Card.Header>
            <div className="d-flex justify-content-between align-items-center">
              <h5 className="m-0">Manage Revenue </h5>
              <NavLink to="/dashboard/AddRevenue">
                <Button className="btn-custom">Add Revenue</Button>
              </NavLink>
            </div>
          </Card.Header>

          <Card.Body>
            {loading && <Spinner animation="border" />}
            {!loading && (
              <Table striped bordered hover responsive>
                <thead>
                  <tr>
                    <th>#</th>
                    <th>Date</th>
                    <th>Amount</th>
                    <th>Category/Method</th>
                    <th>Payee/Payer</th>
                    <th>Action</th>
                  </tr>
                </thead>
                <tbody>
                  {Revenue.map((revenue, index) => (
                    <tr key={index}>
                      <td>{index + 1}</td>
                      <td>{revenue.transactionDate}</td>
                      <td>{revenue.amount}</td>
                      <td>{revenue.paymentMethod}</td>
                      <td>
                        {revenue.payer.firstName} {revenue.payer.lastName}
                      </td>
                      <td>
                        <Button
                          variant="danger"
                          className="me-2 btn-custom"
                          onClick={() => handleDeleteRevenue(revenue.id)}
                        >
                          Delete
                        </Button>
                        <Button
                          variant="primary"
                          className="btn-custom"
                          onClick={() => handleEditRevenue(revenue.id)}
                        >
                          Edit
                        </Button>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </Table>
            )}
          </Card.Body>
        </Card>
      </Tab>
      <Tab eventKey="profile" title="Manage Expense">
        <ExpenseScreen />
      </Tab>
    </Tabs>
  );
};

export default RevenueScreen;

import React, { useEffect, useState } from "react";
import { Button, Card, Spinner, Table } from "react-bootstrap";
import { useSelector } from "react-redux";
import { useNavigate, NavLink } from "react-router-dom";
import {
  DeleteExpense,
  getExpense,
  getExpenses,
} from "../../../services/expenseServices";

const ExpenseScreen = () => {
  const [loading, setLoading] = useState(true);
  const [expense, setExpenses] = useState([]);
  const navigate = useNavigate();

  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const fetchExpenses = () => {
    getExpenses(loggedIn_User)
      .then((res) => {
        if (res.success) {
          setExpenses(res.data);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  };

  const handleDeleteExpense = (id) => {
    DeleteExpense(id, loggedIn_User)
      .then((res) => {
        if (res.success) {
          fetchExpenses();
        }
      })
      .catch((error) => {
        console.log(error.message);
      });
  };

  const handleEditExpense = (id) => {
    getExpense(id, loggedIn_User)
      .then((res) => {
        if (res.success) {
          navigate("/dashboard/updateExpense", {
            state: { expense: res.data },
          });
        }
      })
      .catch((err) => {
        console.log(err);
      });
  };
  useEffect(() => {
    fetchExpenses();
  }, [loggedIn_User]);
  return (
    <>
      <Card>
        <Card.Header>
          <div className="d-flex justify-content-between align-items-center">
            <h5 className="m-0">Manage Expense </h5>
            <NavLink to="/dashboard/CreateExpense">
              <Button className="btn-custom">Add Expense</Button>
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
                  <th>Payee/Payer</th>
                  <th>Expense Category</th>
                  <th>Action</th>
                </tr>
              </thead>
              <tbody>
                {expense.map((expense, index) => (
                  <tr key={index}>
                    <td>{index + 1}</td>
                    <td>{expense.transactionDate}</td>
                    <td>{expense.amount}</td>

                    <td>
                      {expense.payee.firstName} {expense.payee.lastName}
                    </td>

                    <td>{expense.expenseCategory}</td>

                    <td>
                      <Button
                        variant="danger"
                        className="me-2 btn-custom"
                        onClick={() => handleDeleteExpense(expense.id)}
                      >
                        Delete
                      </Button>
                      <Button
                        variant="primary"
                        className="btn-custom"
                        onClick={() => handleEditExpense(expense.id)}
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
    </>
  );
};

export default ExpenseScreen;

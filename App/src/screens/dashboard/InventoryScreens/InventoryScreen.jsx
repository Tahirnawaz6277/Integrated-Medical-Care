import React, { useEffect, useState } from "react";
import { Button, Card, Spinner, Table } from "react-bootstrap";
import { useSelector } from "react-redux";
import { NavLink, useNavigate } from "react-router-dom";
import {
  DeleteInventory,
  getInventories,
  getInventory,
} from "../../../services/InventoryService";
import "../RevenueExpenseScreens/revenueExpense.scss";

const InventoryScreen = () => {
  const [loading, setLoading] = useState(true);
  const [inventory, setInventories] = useState([]);

  const navigate = useNavigate();

  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const fetchInventories = () => {
    getInventories(loggedIn_User)
      .then((res) => {
        if (res.success) {
          setInventories(res.data);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  };

  const handleDeleteInventory = (id) => {
    DeleteInventory(id, loggedIn_User)
      .then((res) => {
        if (res.success) {
          fetchInventories();
        }
      })
      .catch((error) => {
        console.log(error.message);
      });
  };

  const handleEditInventory = (id) => {
    getInventory(id, loggedIn_User)
      .then((res) => {
        if (res.success) {
          navigate("/dashboard/UpdateInventory", {
            state: { inventory: res.data },
          });
        }
      })
      .catch((err) => {
        console.log(err);
      });
  };
  useEffect(() => {
    fetchInventories();
  }, [loggedIn_User]);

  return (
    <Card>
      <Card.Header
        style={{
          background: "black  ",
          padding: "20px ",
          color: "white",
        }}
      >
        Manage Inventory
        <NavLink to="/dashboard/AddInventory">
          <Button className="float-end btn-custom">Add Item</Button>
        </NavLink>
      </Card.Header>

      <Card.Body>
        {loading && <Spinner size="sm" />}
        <Table striped bordered hover responsive>
          <thead>
            <tr>
              <th>#</th>
              <th>Item</th>
              <th>Total Quantity</th>
              <th>Available Quantity</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {inventory.map((inventory, index) => (
              <tr key={index}>
                <td>{index + 1}</td>
                <td>{inventory.service}</td>
                <td>{inventory.totalQuantity}</td>
                <td>{inventory.availableQuantity}</td>

                <td>
                  <Button
                    variant="danger"
                    className="me-2 btn-custom"
                    onClick={() => {
                      handleDeleteInventory(inventory.id);
                    }}
                  >
                    Delete
                  </Button>
                  <Button
                    variant="primary"
                    className="btn-custom"
                    onClick={() => {
                      handleEditInventory(inventory.id);
                    }}
                  >
                    Edit
                  </Button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      </Card.Body>
    </Card>
  );
};

export default InventoryScreen;

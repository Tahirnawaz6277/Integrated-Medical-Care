import React, { useEffect, useState } from "react";
import { Button, Card, Spinner, Table } from "react-bootstrap";
import { NavLink } from "react-router-dom";

import { getOrders, DeleteOrder } from "../../../services/orderService";
import { useSelector } from "react-redux";

const OrderScreen = () => {
  const [orders, setOrder] = useState([]);
  const [loading, setLoading] = useState(true);

  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );
  const fetchOrders = () => {
    getOrders(loggedIn_User)
      .then((res) => {
        if (res.success) {
          setOrder(res.data);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  };
  const handleDelete = (id) => {
    DeleteOrder(id, loggedIn_User)
      .then((res) => {
        if (res.success) {
          fetchOrders();
        }
      })
      .catch((err) => {});
  };
  useEffect(() => {
    fetchOrders();
  }, []);

  return (
    <>
      <Card>
        <Card.Header>
          Manage Orders
          <NavLink to="/dashboard/AddOrderScreen">
            <Button className="float-end">Create Order</Button>
          </NavLink>
        </Card.Header>

        <Card.Body>
          {loading && <Spinner size="sm" />}
          <Table responsive="sm">
            <thead>
              <tr>
                <th>Order Id</th>
                <th>Customer</th>
                <th>Order Date</th>
                <th>Price</th>
                <th>status </th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              {orders.map((order, index) => (
                <tr key={index}>
                  <td> {order.id} </td>

                  <td> {order.orderBy.firstName} </td>
                  <td> {order.orderDate} </td>
                  <td> {order.amount} </td>
                  <td> {order.orderStatus} </td>
                  <td style={{ display: "flex", gap: "8px" }}>
                    <Button
                      variant="danger"
                      onClick={() => {
                        handleDelete(order.id);
                      }}
                    >
                      Delete
                    </Button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        </Card.Body>
      </Card>
    </>
  );
};

export default OrderScreen;

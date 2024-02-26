import React, { useEffect, useState } from "react";
import { Button, Card, NavLink, Spinner, Table } from "react-bootstrap";
import { getOrders } from "../../../services/orderService";

const OrderScreen = () => {
  const [orders, setOrders] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getOrders()
      .then((res) => {
        if (res.success) {
          setOrders(res.data);

          setLoading(false);
        }
      })
      .catch((error) => {
        setLoading(true);
      });
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

                  <td> {order.user.firstName} </td>
                  <td> {order.orderDate} </td>
                  <td> {order.amount} </td>
                  <td> {order.orderStatus} </td>
                  <td style={{ display: "flex", gap: "8px" }}>
                    <Button className="btn btn-danger">Delete</Button>
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

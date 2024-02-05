import React, { useEffect, useState } from "react";
import { Button, Card, Table } from "react-bootstrap";
import { getOrders } from "../../services/orderService";

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
        console.log(error);
        setLoading(true);
      });
  }, []);

  return (
    <>
      <Card>
        <Card.Header>Manage Orders</Card.Header>

        <Card.Body>
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
              {orders.map((order, index) => {
                <tr key={index}>
                  <td> {order.id} </td>

                  <td> {order.createdAt} </td>
                  <td> {order.Amount} </td>
                  <td> {order.orderStatus} </td>
                  <td> {order.id} </td>
                  <td style={{ display: "flex", gap: "8px" }}>
                    <Button className="btn btn-danger">Delete</Button>
                  </td>
                </tr>;
              })}
            </tbody>
          </Table>
        </Card.Body>
      </Card>
    </>
  );
};

export default OrderScreen;

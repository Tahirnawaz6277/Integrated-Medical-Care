import React, { useEffect, useState } from "react";
import { Button, Card, NavLink, Spinner, Table } from "react-bootstrap";
import { getOrders, DeleteOrder } from "../../../services/orderService";

const OrderScreen = () => {
  const [orders, setOrder] = useState([]);
  const [loading, setLoading] = useState(true);

  const updatedOrders = () => {
    getOrders()
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
    DeleteOrder(id)
      .then((res) => {
        if (res.success) {
          updatedOrders();
        }
      })
      .catch((err) => {});
  };
  useEffect(() => {
    updatedOrders();
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

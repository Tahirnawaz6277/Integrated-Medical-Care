import React, { useEffect, useState } from "react";
import { Button, Card, Dropdown, Spinner, Table } from "react-bootstrap";
import { NavLink } from "react-router-dom";

import { useSelector } from "react-redux";
import {
  DeleteOrder,
  UpdateOrderStatus,
  getOrders,
} from "../../../services/orderService";
const ManageOrderScreen = () => {
  const [orders, setOrder] = useState([]);
  const [loading, setLoading] = useState(true);

  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );
  const fetchOrders = () => {
    getOrders(loggedIn_User)
      .then((res) => {
        console.log(res);
        if (res.success) {
          setOrder(res.data);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  };
  const handleOrderStatus = (id, status) => {
    UpdateOrderStatus(id, loggedIn_User, status)
      .then((res) => {
        if (res.success) {
          fetchOrders();
        }
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const handleOrderDelete = (id) => {
    DeleteOrder(id, loggedIn_User)
      .then((res) => {
        console.log(res);
        if (res.success) {
          fetchOrders();
        }
      })
      .catch((err) => {
        console.log(err);
      });
  };

  useEffect(() => {
    fetchOrders();
  }, []);

  return (
    <>
      <Card>
        <Card.Header
          style={{
            background: "black  ",
            padding: "20px ",
            color: "white",
          }}
        >
          Deliver Orders To The Customer
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
                <th>Payement Status </th>

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

                  <td>
                    {order.paid == true ? (
                      <b style={{ color: "green" }}>Paid</b>
                    ) : (
                      <b style={{ color: "red" }}>UnPaid</b>
                    )}
                  </td>

                  <td style={{ display: "flex", gap: "8px" }}>
                    {order.orderStatus !== "Delivered" ? (
                      <Dropdown className="float-end" key={order.id}>
                        <Dropdown.Toggle variant="success">
                          Order Status
                        </Dropdown.Toggle>
                        <Dropdown.Menu style={{ width: "200px" }}>
                          <Dropdown.Item
                            onClick={() =>
                              handleOrderStatus(order.id, "Pending")
                            }
                          >
                            Pending
                          </Dropdown.Item>
                          <Dropdown.Item
                            onClick={() =>
                              handleOrderStatus(order.id, "Processing")
                            }
                          >
                            Processing
                          </Dropdown.Item>
                          <Dropdown.Item
                            onClick={() =>
                              handleOrderStatus(order.id, "Shipped")
                            }
                          >
                            Shipped
                          </Dropdown.Item>
                          <Dropdown.Item
                            onClick={() =>
                              handleOrderStatus(order.id, "Cancelled")
                            }
                          >
                            Cancelled
                          </Dropdown.Item>
                          <Dropdown.Item
                            onClick={() =>
                              handleOrderStatus(order.id, "Delivered")
                            }
                          >
                            Delivered
                          </Dropdown.Item>
                        </Dropdown.Menu>
                      </Dropdown>
                    ) : (
                      <Button
                        variant="danger"
                        onClick={() => {
                          handleOrderDelete(order.id);
                        }}
                      >
                        Delete
                      </Button>
                    )}
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

export default ManageOrderScreen;

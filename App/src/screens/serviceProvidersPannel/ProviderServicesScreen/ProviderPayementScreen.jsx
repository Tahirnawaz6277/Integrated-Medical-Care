import React, { useEffect, useState } from "react";
import { Button, Card, Table } from "react-bootstrap";
import { getOrder, getOrders } from "../../../services/orderService";
import { useSelector } from "react-redux";
import { NavLink, useNavigate } from "react-router-dom";

const ProviderPayementScreen = () => {
  const [orders, setOrder] = useState([]);
  const [loading, setLoading] = useState(true);

  const navigate = useNavigate();

  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );
  const fetchOrders = () => {
    getOrders(loggedIn_User)
      .then((res) => {
        if (res.success) {
          // Filter orders with status "Delivered"
          const deliveredOrders = res.data.filter(
            (order) =>
              order.orderStatus === "Delivered" &&
              order.isTransferPayment === false
          );

          setOrder(deliveredOrders);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  };

  const handleTransferPayement = (id) => {
    getOrder(id, loggedIn_User)
      .then((res) => {
        if (res.success) {
          navigate("/dashboard/transferPayement", {
            state: { order: res.data },
          });
        }
      })
      .catch((err) => {
        console.log(err);
      });
  };

  useEffect(() => {
    fetchOrders();
  }, []);

  // Function to format date
  const formatDate = (dateString) => {
    const options = { year: "numeric", month: "long", day: "numeric" };
    return new Date(dateString).toLocaleDateString("en-US", options);
  };

  return (
    <Card>
      <Card.Header
        style={{
          background: "black  ",
          padding: "20px ",
          color: "white",
        }}
      >
        Recieved Orders Amount
      </Card.Header>

      <Card.Body>
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>Date</th>
              <th>Payement Type</th>
              <th>Amount</th>
              <th>Patient</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {orders.map((order, index) => (
              <tr key={index}>
                <td>{formatDate(order.orderDate)}</td>
                <td>{order.paymentMode}</td>
                <td>{order.amount}</td>
                <td>{order.orderBy.firstName}</td>
                <td>
                  <Button
                    className="float-end"
                    onClick={() => {
                      handleTransferPayement(order.id);
                    }}
                  >
                    Transfer Payment
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

export default ProviderPayementScreen;

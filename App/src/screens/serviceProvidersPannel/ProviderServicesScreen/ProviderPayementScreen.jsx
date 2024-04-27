import React, { useEffect, useState } from "react";
import { Button, Card, Table } from "react-bootstrap";
import { getOrders } from "../../../services/orderService";
import { useSelector } from "react-redux";
import { NavLink, useNavigate } from "react-router-dom";
import TransferPaymentScreen from "./TransferPaymentScreen";

const ProviderPayementScreen = () => {
  const [orders, setOrder] = useState([]);
  const [loading, setLoading] = useState(true);
  const [totalAmount, setTotalAmounts] = useState(0);
  const [isVisible, setIsVisible] = useState(false);
  const [paidAmount, setPaidAmount] = useState(0);

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
            (order) => order.orderStatus === "Delivered"
          );
          setOrder(deliveredOrders);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  };

  const handleTransferPayement = () => {
    setIsVisible(true);
  };

  useEffect(() => {
    fetchOrders();
  }, []);

  // Calculate total amount when orders change or paidAmount changes
  useEffect(() => {
    const total = orders.reduce((acc, order) => acc + order.amount, 0);
    setTotalAmounts(total - paidAmount); // Subtract paidAmount from total
  }, [orders, paidAmount]);

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
        Total Amount :<b>{totalAmount}$</b>
        <Button
          className="float-end"
          disabled={!isVisible && totalAmount <= 0}
          onClick={handleTransferPayement}
        >
          Transfer Payment
        </Button>
      </Card.Header>

      {isVisible && totalAmount > 0 && (
        <TransferPaymentScreen amount={totalAmount} />
      )}

      {!isVisible && (
        <Card.Body>
          <Table striped bordered hover>
            <thead>
              <tr>
                <th>Date</th>
                <th>Payement Type</th>
                <th>Amount</th>
                <th>Patient</th>
              </tr>
            </thead>
            <tbody>
              {orders.map((order, index) => (
                <tr key={index}>
                  <td>{formatDate(order.orderDate)}</td>
                  <td>{order.paymentMode}</td>
                  <td>{order.amount}</td>
                  <td>{order.orderBy.firstName}</td>
                </tr>
              ))}
            </tbody>
          </Table>
        </Card.Body>
      )}
    </Card>
  );
};

export default ProviderPayementScreen;

import React, { useEffect, useState } from "react";
import { Card, Table, Button, Form, Row, Col } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { NavLink } from "react-router-dom";
import { DeleteFromCart } from "../../Redux/Action";

const ShoppingCart = () => {
  const [cartItem, setCartItems] = useState([]);
  const [totalPrice, setTotalPrice] = useState(0);

  const getCartItems = useSelector((state) => state.actionsReducer.Cart);
  const dispatch = useDispatch();

  const handleDelete = (index) => {
    dispatch(DeleteFromCart(index));
  };

  const getTotalPrice = () => {
    let totalPrice = 0;
    cartItem.forEach((item) => {
      totalPrice += item.charges * item.quantity;
    });
    setTotalPrice(totalPrice);
  };
  useEffect(() => {
    if (getCartItems && getCartItems.length >= 0) {
      setCartItems(getCartItems);
    } else {
      setCartItems([]);
    }
  }, [getCartItems]);

  useEffect(() => {
    getTotalPrice();
  }, [cartItem]);

  return (
    <>
      {cartItem.length > 0 ? (
        <Card>
          <Card.Header>
            <h2>Booking Services Cart</h2>
          </Card.Header>
          <Card.Body>
            <Table bordered className="m-0">
              <thead>
                <tr>
                  <th
                    className="text-center py-3 px-4"
                    style={{ minWidth: "400px" }}
                  >
                    Service Name & Details
                  </th>
                  <th
                    className="text-right py-3 px-4"
                    style={{ width: "100px" }}
                  >
                    Price
                  </th>
                  <th
                    className="text-center py-3 px-4"
                    style={{ width: "120px" }}
                  >
                    Quantity
                  </th>
                  <th
                    className="text-right py-3 px-4"
                    style={{ width: "100px" }}
                  >
                    Total
                  </th>
                  <th
                    className="text-center align-middle py-3 px-0"
                    style={{ width: "40px" }}
                  >
                    <a
                      href="#"
                      className="shop-tooltip float-none text-light"
                      title=""
                      data-original-title="Clear cart"
                    >
                      <i className="ino ion-md-trash"></i>
                    </a>
                  </th>
                </tr>
              </thead>
              <tbody>
                {cartItem.map((cart, index) => (
                  <tr key={index}>
                    <td className="p-10">
                      <div
                        className="media align-items-center"
                        style={{ display: "flex" }}
                      >
                        <img
                          src={cart.service_img}
                          className="d-block ui-w-40 ui-bordered mr-4"
                          alt=""
                          style={{ width: "15%" }}
                        />
                        <div className="media-body" style={{ padding: "40px" }}>
                          <b>Service :</b>
                          <p className="d-block text-dark">
                            {cart.serviceName}
                          </p>

                          <b>Service Charges:</b>
                          <p className="d-block text-dark">{cart.charges}</p>
                        </div>
                      </div>
                    </td>
                    <td className="text-right font-weight-semibold align-middle p-4">
                      ${cart.charges}
                    </td>
                    <td className="align-middle p-4">
                      <i
                        className="fa fa-plus-circle "
                        style={{ marginRight: "7px", cursor: "pointer" }}
                        aria-hidden="true"
                        onClick={() => {}}
                      ></i>
                      {cart.quantity}
                      <i
                        class="fa fa-minus-circle "
                        style={{ marginLeft: "7px", cursor: "pointer" }}
                        aria-hidden="true"
                      ></i>
                    </td>
                    <td className="text-right font-weight-semibold align-middle p-4">
                      ${cart.charges * cart.quantity}
                    </td>
                    <td
                      className="text-center align-middle px-0"
                      style={{ cursor: "pointer" }}
                    >
                      <i
                        onClick={() => {
                          handleDelete(cart.id);
                        }}
                        class="fa fa-trash"
                        aria-hidden="true"
                      ></i>
                    </td>
                  </tr>
                ))}
              </tbody>
            </Table>
          </Card.Body>

          <Card.Footer>
            <Row>
              <Col>
                <small style={{ fontSize: "20px" }}>
                  <strong>Total Price :</strong>${totalPrice}
                </small>
              </Col>
              <Col>
                <NavLink to="/dashboard/checkout">
                  <Button
                    className="btn-lg mt-2"
                    variant="dark"
                    style={{
                      float: "right",

                      paddingRight: "20px",
                      paddingLeft: "20px",
                      borderRadius: "0px",
                    }}
                  >
                    Checkout
                  </Button>
                </NavLink>
                <NavLink to="/dashboard/provider_services">
                  <Button
                    className="btn-lg mt-2 "
                    variant="dark"
                    style={{
                      float: "right",

                      paddingRight: "20px",
                      paddingLeft: "20px",
                      borderRadius: "0px",
                      marginInlineEnd: "2px",
                    }}
                  >
                    Back to shopping
                  </Button>
                </NavLink>
              </Col>
            </Row>
          </Card.Footer>
        </Card>
      ) : (
        <b
          className="empty-cart"
          style={{
            color: "red",
            position: "relative",
            left: "40%",
            fontsize: "20px",
          }}
        >
          Cart is Empty
        </b>
      )}
    </>
  );
};

export default ShoppingCart;

import React, { useEffect, useState } from "react";
import { Button, Card, Spinner, Table } from "react-bootstrap";
import { NavLink } from "react-router-dom";
import {
  DeletePromotion,
  getPromotions,
} from "../../../services/promotionService";
import { useSelector } from "react-redux";

const PromotionScreen = () => {
  const [promotions, setPromotions] = useState([]);
  const [loading, setLoading] = useState(true);

  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const fetchPromotions = () => {
    getPromotions(loggedIn_User)
      .then((res) => {
        setPromotions(res.data);

        setLoading(false);
      })
      .catch((err) => {
        setLoading(true);
      });
  };

  const handleDelete = (id) => {
    DeletePromotion(id, loggedIn_User)
      .then((res) => {
        console.log(res);
        if (res.success) {
          fetchPromotions();
        }
      })
      .catch((error) => {
        console.log(error.message);
      });
  };

  useEffect(() => {
    fetchPromotions();
  }, [loggedIn_User]);

  return (
    <Card>
      <Card.Header>
        Manage Promotion
        <NavLink to="/dashboard/AddNewPromotionScreen">
          <Button className="float-end">Send New Promotion</Button>
        </NavLink>
      </Card.Header>

      <Card.Body>
        {loading && <Spinner size="sm" />}
        <Table responsive="sm">
          <thead>
            <tr>
              <th>#</th>
              <th>Promotion Type</th>
              <th>Promot To </th>
              {/* <th></th> */}
              <th>Date Created</th>
              <th>Action</th>
            </tr>
          </thead>

          <tbody>
            {promotions.map((promotion, index) => (
              <tr key={index}>
                <td>{index}</td>

                <td>{promotion.promotion_Type}</td>
                <td>{`${promotion.promoteToUser.firstName}  ${promotion.promoteToUser.lastName}  `}</td>

                <td>{promotion.createdAt}</td>
                <td style={{ display: "flex", gap: "8px" }}>
                  <Button
                    variant="danger"
                    onClick={() => {
                      handleDelete(promotion.id);
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
  );
};

export default PromotionScreen;

import React, { useEffect, useState } from "react";
import { Button, Card, Spinner, Table } from "react-bootstrap";
import { getPromotions } from "../../services/promotionService";

const PromotionScreen = () => {
  const [promotions, setPromotions] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getPromotions()
      .then((res) => {
        setPromotions(res.data);

        setLoading(false);
      })
      .catch((err) => {
        setLoading(true);
      });
  }, []);

  return (
    <Card>
      <Card.Header>
        Manage Promotion
        <Button className="float-end">Send New Promotion</Button>
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
                  <Button variant="primary">Edit</Button>
                  <Button
                    variant="danger"
                    onClick={() => {
                      handleDelete(user.id);
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

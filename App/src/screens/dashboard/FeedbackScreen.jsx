import React, { useEffect, useState } from "react";
import { Button, Card, Spinner, Table } from "react-bootstrap";
import { getFeedbacks } from "../../services/feedbackService";

const FeedbackScreen = () => {
  const [feedbacks, setFeedbacks] = useState([]);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    getFeedbacks()
      .then((res) => {
        if (res.success) {
          setFeedbacks(res.data);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  }, []);

  return (
    <Card>
      <Card.Header>Manage Feedbacks</Card.Header>

      <Card.Body>
        {loading && <Spinner size="sm" />}
        <Table responsive="sm">
          <thead>
            <tr>
              <th>#</th>
              <th>Message</th>
              <th>Added By</th>
              <th>Service</th>

              <th>Rating</th>
              <th>Date Created</th>
              <th>Action</th>
            </tr>
          </thead>

          <tbody>
            {feedbacks.map((feedback, index) => (
              <tr key={index}>
                <td>{index}</td>
                <td>{feedback.description}</td>
                <td>{`${feedback.user.firstName}   ${feedback.user.lastName}`}</td>
                <td>{feedback.service.serviceName}</td>
                <td>{feedback.rating}</td>
                <td>{feedback.createdAt}</td>
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

export default FeedbackScreen;

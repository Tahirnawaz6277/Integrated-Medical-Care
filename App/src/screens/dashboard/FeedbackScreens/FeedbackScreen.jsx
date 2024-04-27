import React, { useEffect, useState } from "react";
import { Button, Card, Spinner, Table } from "react-bootstrap";
import { useSelector } from "react-redux";
import {
  DeleteFeedback,
  getFeedbacks,
} from "../../../services/feedbackService";

const FeedbackScreen = () => {
  const [feedbacks, setFeedbacks] = useState([]);
  const [loading, setLoading] = useState(true);

  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const fetchFeedbacks = () => {
    getFeedbacks(loggedIn_User)
      .then((res) => {
        if (res.success) {
          setFeedbacks(res.data);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  };

  const handleDelete = (id) => {
    DeleteFeedback(id, loggedIn_User)
      .then((res) => {
        if (res.success) {
          fetchFeedbacks();
        }
      })
      .catch((error) => {
        console.log(error.message);
      });
  };

  useEffect(() => {
    fetchFeedbacks();
  }, [loggedIn_User]);

  return (
    <Card>
      <Card.Header
        style={{
          background: "black  ",
          padding: "20px ",
          color: "white",
        }}
      >
        Manage Feedbacks
      </Card.Header>

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
                  <Button
                    variant="danger"
                    onClick={() => {
                      handleDelete(feedback.id);
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

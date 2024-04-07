import React, { useEffect, useState } from "react";

import { useSelector } from "react-redux";

import {
  Button,
  Card,
  Col,
  Form,
  FormControl,
  InputGroup,
  NavLink,
  Row,
  Spinner,
  Table,
} from "react-bootstrap";
import { getFeedbacks } from "../../services/feedbackService";

const Customer_FeedbackScreen = () => {
  const [feedbacks, setFeedbacks] = useState([]);
  const [loading, setLoading] = useState(true);

  const [filterOn, setFilterOn] = useState("firstName");
  const [filterQuery, setFilterQuery] = useState("");
  const [pageNumber, setPageNumber] = useState(1);
  const [pageSize, setPageSize] = useState(10);

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

  const handleChange = (e) => {
    // e.preventDefault();
    // setFilterQuery(e.target.value);
    // (filterOn, filterQuery, pageNumber, pageSize)
    //   .then((res) => {
    //     if (res.success) {
    //       setUsers(res.data);
    //       setLoading(false);
    //     }
    //   })
    //   .catch((err) => {
    //     setLoading(true);
    //   });
    // setFilterQuery("");
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
    <>
      <Card>
        <Card.Header>
          <Row>
            <Col className="col-md-6">
              <span>Feedbacks</span>
            </Col>
            <Col className="col-md-6">
              <Form onSubmit={handleChange} className="searchForm">
                <InputGroup className="mb-3">
                  <FormControl
                    placeholder="Search"
                    aria-label="Search"
                    aria-describedby="basic-addon2"
                    value={filterQuery}
                    onChange={(e) => setFilterQuery(e.target.value)}
                  />
                  <Button variant="primary" id="button-addon2">
                    <i className="fas fa-search"></i>
                  </Button>
                </InputGroup>
              </Form>
            </Col>
          </Row>
        </Card.Header>

        <Card.Body>
          {loading && <Spinner size="sm" />}
          <Table responsive="sm">
            <thead>
              <tr>
                <th>#</th>
                <th>Message</th>

                <th>Service</th>

                <th>Rating</th>
                <th>Date Created</th>
              </tr>
            </thead>

            <tbody>
              {feedbacks.map((feedback, index) => (
                <tr key={index}>
                  <td>{index}</td>
                  <td>{feedback.description}</td>

                  <td>{feedback.service.serviceName}</td>
                  <td>{feedback.rating}</td>
                  <td>{feedback.createdAt}</td>
                  {/* <td style={{ display: "flex", gap: "8px" }}> */}
                  {/* <Button
                      variant="primary"
                      onClick={() => {
                        handleDelete(feedback.id);
                      }}
                    >
                      Edit
                    </Button>
                    <Button
                      variant="danger"
                      onClick={() => {
                        handleDelete(feedback.id);
                      }}
                    >
                      Delete
                    </Button>
                  </td> */}
                </tr>
              ))}
            </tbody>
          </Table>
        </Card.Body>
      </Card>
    </>
  );
};

export default Customer_FeedbackScreen;

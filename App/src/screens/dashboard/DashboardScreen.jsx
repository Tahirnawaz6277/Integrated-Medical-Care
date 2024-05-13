import React from "react";
import { Button, Col, Container, Row } from "react-bootstrap";
import { Link } from "react-router-dom";

const DashboardScreen = () => {
  return (
    <Container className="h-100">
      <Row className="justify-content-center align-items-center ">
        <Col md={4}>
          <Button
            as={Link}
            to="/dashboard/accounts"
            variant="primary"
            size="lg"
            block
          >
            <i className="fa fa-users-cog mr-2"></i> Manage Accounts
          </Button>
        </Col>
        <Col md={4}>
          <Button
            as={Link}
            to="/dashboard/orders"
            variant="primary"
            size="lg"
            block
          >
            <i className="fa fa-file-invoice-dollar mr-2"></i> Manage Orders
          </Button>
        </Col>
        <Col md={4}>
          <Button
            as={Link}
            to="/dashboard/healthcareproviders"
            variant="primary"
            size="lg"
            block
          >
            <i className="fa fa-clinic-medical mr-2"></i> Manage HCP's
          </Button>
        </Col>
      </Row>
      <Row className="justify-content-center align-items-center mt-4">
        <Col md={4}>
          <Button
            as={Link}
            to="/dashboard/ManageHcpRecord"
            variant="primary"
            size="lg"
            block
          >
            <i className="fa fa-file-alt mr-2"></i> Manage HCP Records
          </Button>
        </Col>
        <Col md={4}>
          <Button
            as={Link}
            to="/dashboard/feedbacks"
            variant="primary"
            size="lg"
            block
          >
            <i className="fa fa-comments mr-2"></i> Manage Feedback
          </Button>
        </Col>
        <Col md={4}>
          <Button
            as={Link}
            to="/dashboard/customerrecord"
            variant="primary"
            size="lg"
            block
          >
            <i className="fa fa-users mr-2"></i> Manage Customer Record
          </Button>
        </Col>
      </Row>
    </Container>
  );
};

export default DashboardScreen;

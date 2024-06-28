import React, { useEffect, useState } from "react";
import { Button, Col, Container, Row } from "react-bootstrap";
import { Link } from "react-router-dom";
import "./dashboardScreen.css"
import { useSelector } from "react-redux";

const DashboardScreen = () => {

  const [loggedInUserRole, setLoggedInUserRole] = useState("");
  const loggedInUser = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  useEffect(() => {
    if (loggedInUser) {
      setLoggedInUserRole(loggedInUser.role);
    } 
  }, [loggedInUser]);

  

  return (
    <Container className="h-100">
      
      {/* ----> Admin  */}

{(loggedInUserRole==="Admin") && (
<>
<Row className="justify-content-center align-items-center ">
        <Col md={4}>
          <Button
          className="quickAccess"
            as={Link}
            to="/dashboard/accounts"
          
          >
            <i className="fa fa-users-cog mr-2"></i> <br/>Manage Accounts
          </Button>
        </Col>
        <Col md={4}>
          <Button
            as={Link}
            to="/dashboard/orders"
              className="quickAccess"
          >
            <i className="fa fa-file-invoice-dollar mr-2"></i> <br/>Manage Orders
          </Button>
        </Col>
        <Col md={4}>
          <Button
            as={Link}
            to="/dashboard/healthcareproviders"
          className="quickAccess"
          > 
            <i className="fa fa-clinic-medical mr-2"></i><br/> Manage HCP's
          </Button>
        </Col>
      </Row>
      <Row className="justify-content-center align-items-center mt-4">
        <Col md={4}>
          <Button
            as={Link}
            to="/dashboard/ManageHcpRecord"
            className="quickAccess"
          >
            <i className="fa fa-file-alt mr-2"></i><br/> Manage HCP Records
          </Button>
        </Col>
        <Col md={4}>
         
      
          <Button
            as={Link}
            to="/dashboard/feedbacks"
            className="quickAccess" 
          >
            <i className="fa fa-comments mr-2"></i> <br/>Manage Feedback
          </Button>
      
        </Col>
        <Col md={4}>
          <Button
            as={Link}
            to="/dashboard/customerrecord"
            className="quickAccess"  
          >
            <i className="fa fa-users mr-2"></i> <br/>Manage Customer Record
          </Button>
        </Col>
      </Row>
      <Row className="justify-content-center align-items-center mt-4">
        <Col md={4}>
            <Button
            as={Link}
            to="/dashboard/services"
            className="quickAccess"
          >
            <i className="fa fa-store mr-2"></i><br/> Manage Services
          </Button>
         
        </Col>
        <Col md={4}>
          <Button
            as={Link}
            to="/dashboard/inventory"
            className="quickAccess" 
          >
            <i className="fa fa-hammer mr-2"></i> <br/> Manage Inventory
          </Button>
        </Col>
        <Col md={4}>
          <Button
            as={Link}
            to="/dashboard/Revenue"
            className="quickAccess"  
          >
            <i className="fa fa-money-bill mr-2"></i> <br/> Manage Revenue & Expense
          </Button>
        </Col>
      </Row>
      </>
      )}

      


   
      {/* ----> Service Provider  */}
      
      {(loggedInUserRole==="ServiceProvider") && (

<Row className="justify-content-center align-items-center mt-4">
<Col md={4}>
  

    <Button
    as={Link}
    to="/dashboard/pservices"
    className="quickAccess"
  >
    <i className="fa fa-store mr-2"></i><br/> Manage Services
  </Button>
 
</Col>
<Col md={4}>
  <Button
    as={Link}
    to="/dashboard/order"
    className="quickAccess" 
  >
    <i className="fa fa-hammer mr-2"></i> <br/> Manage Orders
  </Button>
</Col>
<Col md={4}>
  <Button
    as={Link}
    to="/dashboard/payement"
    className="quickAccess"  
  >
    <i className="fa fa-money-bill mr-2"></i> <br/> Payement
  </Button>
</Col>
</Row>
      )}
   


      {/* ----->> Customer  */}
    
      {(loggedInUserRole==="Customer") &&(
      <Row className="justify-content-center align-items-center mt-4">
        <Col md={4}>
          
         
            <Button
            as={Link}
            to="/dashboard/provider_services"
            className="quickAccess"
          >
            <i className="fa fa-store mr-2"></i><br/> View Services
          </Button>
          
        </Col>
        <Col md={4}>
          <Button
            as={Link}
            to="/dashboard/serviceProviders"
            className="quickAccess" 
          >
            <i className="fa fa-users mr-2"></i> <br/> View Service Providers
          </Button>
        </Col>
        <Col md={4}>
          <Button
            as={Link}
            to="/dashboard/Customerfeedback"
            className="quickAccess"  
          >
            <i className="fa fa-comments mr-2"></i> <br/> Manage Feedbacks
          </Button>
        </Col>
      </Row>
    )}
    </Container>
  );
};

export default DashboardScreen;

import React, { useEffect, useState } from "react";
import { Button, Card, Col, Image, Row, Spinner } from "react-bootstrap";
import { GetServiceProviders } from "../../services/serviceProvidersService";
import "./ServiceProviders.scss";
import { useNavigate } from "react-router-dom";

const ServiceProvidersScreen = () => {
  const [HCP, setHCP] = useState([]);
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();

  const fetchHcps = () => {
    GetServiceProviders()
      .then((res) => {
        if (res.success) {
          let hcps = res.data.filter((hcp) => {
            return hcp.role === "ServiceProvider";
          });

          setHCP(hcps);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  };

  const hanldeFeedbackRating = (id) => {
    navigate("/dashboard/feedback", { state: { id: id } });
  };

  useEffect(() => {
    fetchHcps();
  }, []);

  return (
    <>
      <Row className="row ">
        {loading && <Spinner animation="border" />}

        {HCP.length > 0 ? (
          HCP.map((user, index) => (
            <Col className="col-md-4  " key={index}>
              <Card className="provider-card ">
                <Image
                  src="https://bootdey.com/img/Content/avatar/avatar1.png"
                  className="Card-img rounded-circle img-fluid"
                  alt="providers"
                />

                <Card.Body className="Card-Body">
                  <Card.Title className="mb-3">
                    {user.firstName} {user.lastName}
                  </Card.Title>
                  <Card.Text>
                    <strong>Email:</strong> {user.email} <br />
                    <strong>Phone Number:</strong> {user.phoneNumber} <br />
                    <strong>Service:</strong>
                    {user.serviceProviderType?.providerName || "N/A"}
                  </Card.Text>

                  <Button onClick={() => hanldeFeedbackRating(user.id)}>
                    Rate Me
                  </Button>
                </Card.Body>
              </Card>
            </Col>
          ))
        ) : (
          <b>Services Not Available</b>
        )}
      </Row>
    </>
  );
};

export default ServiceProvidersScreen;

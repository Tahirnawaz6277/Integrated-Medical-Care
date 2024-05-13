import React, { useEffect, useState } from "react";
import {
  Button,
  Card,
  Col,
  Container,
  Dropdown,
  DropdownButton,
  Form,
  FormControl,
  Image,
  InputGroup,
  Row,
  Spinner,
} from "react-bootstrap";
import { GetServiceProviders } from "../../services/serviceProvidersService";
import "./ServiceProviders.scss";
import { useNavigate } from "react-router-dom";
import { getUsers } from "../../services/accountService";
import { FaStar } from "react-icons/fa";

const ServiceProvidersScreen = () => {
  const [HCP, setHCP] = useState([]);
  const [showRanking, setShowRanking] = useState(false);

  const [loading, setLoading] = useState(true);
  const [filterOn, setFilterOn] = useState("");
  const [filterQuery, setFilterQuery] = useState("");

  const navigate = useNavigate();

  const fetchHcps = () => {
    GetServiceProviders(filterOn, filterQuery)
      .then((res) => {
        if (res.success) {
          let hcps = res.data.filter((hcp) => {
            return hcp.role === "ServiceProvider";
          });

          // Calculate average rating for each service provider
          let updatedHCPs = hcps.map((hcp) => {
            if (hcp.services.length > 0) {
              let totalRating = hcp.services.reduce((total, service) => {
                if (
                  service.user_Feedbacks &&
                  service.user_Feedbacks.length > 0
                ) {
                  return (
                    total +
                    service.user_Feedbacks.reduce(
                      (acc, feedback) => acc + feedback.rating,
                      0
                    ) /
                      service.user_Feedbacks.length
                  );
                } else {
                  return total;
                }
              }, 0);
              hcp.averageRating = totalRating / hcp.services.length;
            }
            return hcp; // Return the modified object
          });

          setHCP(updatedHCPs);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  };

  const handleChange = (eventKey) => {
    eventKey === "Doctor" ? setShowRanking(true) : setShowRanking(false);

    GetServiceProviders(eventKey, eventKey)
      .then((res) => {
        if (res.success) {
          let hcps = res.data.filter((hcp) => {
            return hcp.role === "ServiceProvider";
          });

          // Calculate average rating for each service provider
          let updatedHCPs = hcps.map((hcp) => {
            if (hcp.services.length > 0) {
              let totalRating = hcp.services.reduce((total, service) => {
                if (
                  service.user_Feedbacks &&
                  service.user_Feedbacks.length > 0
                ) {
                  return (
                    total +
                    service.user_Feedbacks.reduce(
                      (acc, feedback) => acc + feedback.rating,
                      0
                    ) /
                      service.user_Feedbacks.length
                  );
                } else {
                  return total;
                }
              }, 0);
              hcp.averageRating = totalRating / hcp.services.length;
            }
            return hcp;
          });

          setHCP(updatedHCPs);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  };

  const handleRanking = (e, filterOn, filterQuery) => {
    e.preventDefault();

    GetServiceProviders(filterOn, filterQuery)
      .then((res) => {
        if (res.success) {
          let hcps = res.data.filter((hcp) => {
            return hcp.role === "ServiceProvider";
          });

          // Calculate average rating for each service provider
          let updatedHCPs = hcps.map((hcp) => {
            if (hcp.services.length > 0) {
              let totalRating = hcp.services.reduce((total, service) => {
                if (
                  service.user_Feedbacks &&
                  service.user_Feedbacks.length > 0
                ) {
                  return (
                    total +
                    service.user_Feedbacks.reduce(
                      (acc, feedback) => acc + feedback.rating,
                      0
                    ) /
                      service.user_Feedbacks.length
                  );
                } else {
                  return total;
                }
              }, 0);
              hcp.averageRating = totalRating / hcp.services.length;
            }
            return hcp;
          });

          setHCP(updatedHCPs);
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
      <Row>
        <Col className="mb-5">
          <Container fluid className="d-flex justify-content-center h-100">
            {!showRanking && (
              <Form
                onSubmit={(e) => handleChange(e, filterQuery, filterOn)}
                className="search"
              >
                <DropdownButton
                  id="dropdown-basic-button"
                  title="Filter On"
                  onSelect={(eventKey) => handleChange(eventKey)}
                >
                  <Dropdown.Item eventKey="Ambulance">Ambulance</Dropdown.Item>
                  <Dropdown.Item eventKey="Pharmacy">Pharmacy</Dropdown.Item>
                  <Dropdown.Item eventKey="Doctor">Doctor</Dropdown.Item>
                </DropdownButton>
                <FormControl
                  type="text"
                  className="search-input"
                  placeholder="search..."
                  value={filterQuery}
                  onChange={(e) => setFilterQuery(e.target.value)}
                />
                <Button variant="primary" type="submit" className="search-icon">
                  <i className="fa fa-search"></i>
                </Button>
              </Form>
            )}

            {showRanking && (
              <Form
                onSubmit={(e) => handleRanking(e, filterOn, filterQuery)}
                className="search"
              >
                <DropdownButton
                  id="dropdown-basic-button"
                  title="Ranking"
                  onSelect={(eventKey) => setFilterOn(eventKey)}
                >
                  <Dropdown.Item eventKey="Experience">Exprience</Dropdown.Item>
                </DropdownButton>
                <FormControl
                  type="text"
                  className="search-input"
                  placeholder="search..."
                  value={filterQuery}
                  onChange={(e) => setFilterQuery(e.target.value)}
                />
                <Button variant="primary" type="submit" className="search-icon">
                  <i className="fa fa-search"></i>
                </Button>
              </Form>
            )}
          </Container>
        </Col>
      </Row>

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
                  {user.services.map((service, serviceIndex) => (
                    <div key={serviceIndex}>
                      {service.user_Feedbacks &&
                      service.user_Feedbacks.length > 0 ? (
                        <span>
                          {Array(5)
                            .fill(0)
                            .map((_, index) => (
                              <FaStar
                                key={index}
                                style={{
                                  fontSize: "28px",
                                  marginBottom: "30px",
                                }}
                                color={
                                  index < Math.ceil(user.averageRating)
                                    ? "#fbb238"
                                    : "black"
                                }
                              />
                            ))}
                        </span>
                      ) : (
                        <span>
                          {[...Array(5)].map((_, index) => (
                            <FaStar
                              key={index}
                              style={{
                                fontSize: "28px",
                                marginBottom: "30px",
                              }}
                              color="black"
                            />
                          ))}
                        </span>
                      )}
                    </div>
                  ))}

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
          <b>Service Provider Not Found</b>
        )}
      </Row>
    </>
  );
};

export default ServiceProvidersScreen;

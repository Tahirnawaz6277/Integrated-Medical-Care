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

const ServiceProvidersScreen = () => {
  const [HCP, setHCP] = useState([]);

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

          setHCP(hcps);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });
  };

  const handleChange = (e, filterQuery, filterOn) => {
    e.preventDefault();

    getUsers(filterOn, filterQuery)
      .then((res) => {
        if (res.success) {
          console.log(res);
          var serviceProviders = res.data.filter((sp) => {
            return sp.role === "ServiceProvider";
          });
          setHCP(serviceProviders);

          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });

    setFilterQuery("");
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
            <Form
              onSubmit={(e) => handleChange(e, filterQuery, filterOn)}
              className="search"
            >
              <InputGroup>
                <DropdownButton
                  id="dropdown-basic-button"
                  title="Filter"
                  onSelect={(eventKey) => setFilterOn(eventKey)}
                >
                  <Dropdown.Item eventKey="Rating">Rating</Dropdown.Item>
                  <Dropdown.Item eventKey="providerType">
                    Ambulance
                  </Dropdown.Item>
                  <Dropdown.Item eventKey="providerType">
                    Pharmacy
                  </Dropdown.Item>
                  <Dropdown.Item eventKey="providerType">Doctor</Dropdown.Item>
                  <Dropdown.Item eventKey="providerType">
                    Hospital
                  </Dropdown.Item>
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
              </InputGroup>
            </Form>
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

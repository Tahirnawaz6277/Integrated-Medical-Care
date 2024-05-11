import React, { useEffect, useState } from "react";
import {
  Button,
  Card,
  FormControl,
  Spinner,
  Table,
  Form,
  Row,
  Col,
  Container,
  InputGroup,
  DropdownButton,
  Dropdown,
} from "react-bootstrap";
import {
  deleteUser,
  getSingleUser,
  getUsers,
} from "../../../services/accountService";
import { NavLink, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";

import "../ManageAccountScreens/accountScreen.scss";
const AccountScreen = () => {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();

  const [filterOn, setFilterOn] = useState("");
  const [filterQuery, setFilterQuery] = useState("");

  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  const fetchUsers = () => {
    getUsers(filterOn, filterQuery)
      .then((res) => {
        if (res.success) {
          setUsers(res.data);
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
          setUsers(res.data);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
      });

    setFilterQuery("");
  };

  const handleDelete = (id) => {
    deleteUser(id)
      .then((res) => {
        if (res.success) {
          fetchUsers();
        }
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const handleEdit = (id) => {
    getSingleUser(id, loggedIn_User)
      .then((res) => {
        navigate("/dashboard/UpdateUserScreen", {
          state: { user: res.data },
        });
      })
      .catch((err) => {
        console.log(err);
      });
  };

  useEffect(() => {
    fetchUsers();
  }, []);

  return (
    <>
      <Card>
        <Card.Header
          style={{
            background: "black",
            padding: "20px",
            color: "white",
          }}
        >
          <Row className="align-items-center">
            <Col>
              <p>Manage Accounts</p>
            </Col>

            <Col>
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
                      <Dropdown.Item eventKey="role">Role</Dropdown.Item>
                      <Dropdown.Item eventKey="firstName">Name</Dropdown.Item>
                    </DropdownButton>
                    <FormControl
                      type="text"
                      className="search-input"
                      placeholder="search..."
                      value={filterQuery}
                      onChange={(e) => setFilterQuery(e.target.value)}
                    />
                    <Button
                      variant="primary"
                      type="submit"
                      className="search-icon"
                    >
                      <i className="fa fa-search"></i>
                    </Button>
                  </InputGroup>
                </Form>
              </Container>
            </Col>

            <Col className="text-end">
              <NavLink to="/dashboard/createUser">
                <Button className="btn-custom">Create User</Button>
              </NavLink>
            </Col>
          </Row>
        </Card.Header>

        <Card.Body>
          {loading && <Spinner size="sm" />}
          <Table responsive="sm">
            <thead>
              <tr>
                <th>#</th>
                <th>Name</th>
                <th>Email</th>
                <th>Role</th>
                <th>Date Created</th>
                <th>Status</th>
                <th>Action</th>
              </tr>
            </thead>

            <tbody>
              {users.map((user, index) => (
                <tr key={index}>
                  <td>{index + 1}</td>
                  <td>{user.firstName}</td>
                  <td>{user.email}</td>
                  <td>{user.role}</td>
                  <td>{user.createdAt}</td>
                  <td>Active</td>
                  <td style={{ display: "flex", gap: "8px" }}>
                    <Button
                      ClassName="btn-custom"
                      variant="danger"
                      onClick={() => {
                        handleDelete(user.id);
                      }}
                    >
                      Delete
                    </Button>
                    <Button
                      ClassName="btn-custom"
                      variant="primary"
                      onClick={() => {
                        handleEdit(user.id);
                      }}
                    >
                      Edit
                    </Button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        </Card.Body>
      </Card>
    </>
  );
};

export default AccountScreen;

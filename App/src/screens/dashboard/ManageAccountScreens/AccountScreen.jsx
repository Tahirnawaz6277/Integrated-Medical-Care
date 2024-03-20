import React, { useEffect, useState } from "react";
import {
  Button,
  Card,
  FormControl,
  Spinner,
  Table,
  Form,
} from "react-bootstrap";
import { deleteUser, getUsers } from "../../../services/accountService";
import { NavLink } from "react-router-dom";

const AccountScreen = () => {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);

  const [filterOn, setFilterOn] = useState("firstName");
  const [filterQuery, setFilterQuery] = useState("");
  const [pageNumber, setPageNumber] = useState(1);
  const [pageSize, setPageSize] = useState(10);

  const fetchUsers = () => {
    getUsers(filterOn, filterQuery, pageNumber, pageSize)
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

  const handleChange = (e) => {
    e.preventDefault();
    setFilterQuery(e.target.value);

    getUsers(filterOn, filterQuery, pageNumber, pageSize)
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
      .catch((err) => {});
  };

  useEffect(() => {
    fetchUsers();
  }, []);

  return (
    <>
      <Card>
        <Card.Header>
          Manage Accounts
          <NavLink to="/dashboard/signup">
            <Button className="float-end">Add New User</Button>{" "}
          </NavLink>
          <Form
            onSubmit={(e) => {
              handleChange(e);
            }}
          >
            <FormControl
              type="search"
              placeholder="Search"
              className="mr-sm-2"
              aria-label="Search"
              value={filterQuery}
              onChange={(e) => {
                setFilterQuery(e.target.value);
              }}
            />
            <Button
              variant="outline-success"
              className="my-2 my-sm-0"
              type="submit"
            >
              Search
            </Button>
          </Form>
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
                      className="btn btn-danger"
                      onClick={() => {
                        handleDelete(user.id);
                      }}
                    >
                      Delete
                    </Button>
                    <Button className="btn btn-primary">Details</Button>
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

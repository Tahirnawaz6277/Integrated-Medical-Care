import React, { useEffect, useState } from "react";
import { Button, Card, Spinner, Table } from "react-bootstrap";
import { deleteUser, getUsers } from "../../services/accountService";
import { useNavigate } from "react-router-dom";

const AccountScreen = () => {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);

  const updatedUser = () => {
    getUsers()
      .then((res) => {
        if (res.success) {
          setUsers(res.data);
          setLoading(false);
        }
      })
      .catch((err) => {
        setLoading(true);
        console.log(err);
      });
  };
  const handleDelete = (id) => {
    deleteUser(id)
      .then((res) => {
        if (res.success) {
          updatedUser();
        }
      })
      .catch((err) => {
        console.log(err.message);
      });
  };

  useEffect(() => {
    updatedUser();
  }, []);

  return (
    <>
      <Card>
        <Card.Header>
          Manage Accounts
          <Button className="float-end">Add New User</Button>
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
                <th>Action</th>
              </tr>
            </thead>

            <tbody>
              {users.map((user, index) => (
                <tr key={index}>
                  <td>{index}</td>
                  <td>{user.firstName}</td>
                  <td>{user.email}</td>
                  <td>{user.role}</td>
                  <td>{user.createdAt}</td>
                  <td style={{ display: "flex", gap: "8px" }}>
                    <Button variant="primary">Edit</Button>

                    <Button
                      className="btn btn-danger"
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
    </>
  );
};

export default AccountScreen;

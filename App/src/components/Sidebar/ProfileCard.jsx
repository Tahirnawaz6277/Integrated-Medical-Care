import React from "react";
import { Button, Card } from "react-bootstrap";

const ProfileCard = ({ user }) => {
  return (
    <>
      <Card className="p-4">
        <div className="image d-flex flex-column justify-content-center align-items-center">
          <Button
            className="btn btn-secondary"
            style={{ height: "140px", width: "140px", borderRadius: "50%" }}
          >
            <img
              src="https://bootdey.com/img/Content/avatar/avatar1.png"
              height="100"
              width="100"
              alt="Profile"
            />
          </Button>
          <span className="name mt-3">{user.Name}</span>
          <span className="name mt-3">{user.role}</span>
        </div>
      </Card>
    </>
  );
};

export default ProfileCard;

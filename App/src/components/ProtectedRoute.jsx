import React, { useEffect } from "react";
import { useNavigate } from "react-router";
import { useSelector } from "react-redux";

export const ProtectedRoute = (props) => {
  const navigate = useNavigate();
  const loggedIn_User = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  useEffect(() => {
    if (!loggedIn_User) {
      navigate("/");
    }
  }, [loggedIn_User, navigate]);

  return (
    <>
      <props.component />
    </>
  );
};

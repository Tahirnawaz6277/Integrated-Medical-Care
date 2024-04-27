import React, { useEffect } from "react";
import { useNavigate } from "react-router";
import { useSelector } from "react-redux";

export const ProtectedRoute = ({ children, allowedRoles }) => {
  const navigate = useNavigate();
  const userData = useSelector((state) => state.actionsReducer.LOGGED_IN_USER);

  let isValidRole = allowedRoles.includes(userData?.role);
  useEffect(() => {
    if (!userData) {
      navigate("/");
    }

    if (!isValidRole) navigate("/");
  }, [userData, navigate]);

  return <>{children}</>;
};

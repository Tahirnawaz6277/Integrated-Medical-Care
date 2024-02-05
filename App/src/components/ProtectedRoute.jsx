import React, { useEffect } from "react";
import { useNavigate } from "react-router";

export const ProtectedRoute = (props) => {
  const navigate = useNavigate();

  useEffect(() => {
    let User = localStorage.getItem("token");
    if (!User) {
      navigate("/");
    }
  });

  return (
    <>
      <props.component />
    </>
  );
};

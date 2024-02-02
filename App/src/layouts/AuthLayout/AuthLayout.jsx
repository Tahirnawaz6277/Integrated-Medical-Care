import React from "react";
import LoginScreen from "../../screens/LoginScreen";
import { Link, Outlet } from "react-router-dom";
import "../AuthLayout/style.scss";

const AuthLayout = () => {
  return (
    <>
      <div className="container-fluid">
        <div className="row">
          <div className="col-md-8">
            <Outlet />
          </div>
          <div className="col-md-4 AuthSidebar">
            <h1>IMC</h1>
          </div>
        </div>
      </div>
    </>
  );
};

export default AuthLayout;

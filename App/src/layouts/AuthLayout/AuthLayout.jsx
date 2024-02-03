import React from "react";
import { Outlet } from "react-router-dom";
import "../AuthLayout/style.scss";

const AuthLayout = () => {
  return (
    <>
      <div className="container-fluid">
        <div className="row">
          <div className="col-md-6 p-5">
            <Outlet />
          </div>
          <div className="col-md-6 AuthSidebar">
            <h1>IMC</h1>
          </div>
        </div>
      </div>
    </>
  );
};

export default AuthLayout;

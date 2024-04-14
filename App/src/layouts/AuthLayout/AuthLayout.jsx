import React from "react";
import { Outlet } from "react-router-dom";
import "../AuthLayout/style.scss";

const AuthLayout = () => {
  return (
    <>
      <div className="container-fluid">
        <div className="row">
          <div className="col-md-12 AuthSidebar">
            <Outlet />
          </div>
        </div>
      </div>
    </>
  );
};

export default AuthLayout;

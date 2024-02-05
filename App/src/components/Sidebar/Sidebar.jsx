import React from "react";
import { Link } from "react-router-dom";

const Sidebar = () => {
  return (
    <>
      <header className="navbar p-3 navbar-dark sticky-top bg-dark flex-md-nowrap p-0 shadow">
        <a className="navbar-brand col-md-3 col-lg-2 me-0 px-3" href="#">
          IMC
        </a>
        <button
          className="navbar-toggler position-absolute d-md-none collapsed"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#sidebarMenu"
          aria-controls="sidebarMenu"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span className="navbar-toggler-icon" />
        </button>
        <input
          className="form-control form-control-dark w-25"
          type="text"
          placeholder="Search"
          aria-label="Search"
        />
        <div className="navbar-nav">
          <div className="nav-item text-nowrap">
            <a className="nav-link px-3" href="#">
              Sign out
            </a>
          </div>
        </div>
      </header>

      <nav
        id="sidebarMenu"
        className="col-md-3 col-lg-2 d-md-block bg-light sidebar collapse"
      >
        <div className="position-sticky pt-3">
          <ul className="nav flex-column">
            <li className="nav-item">
              <Link className="nav-link active" to="/dashboard">
                Dashboard
              </Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link active" to="/dashboard/accounts">
                Manage Accounts
              </Link>
            </li>

            <li className="nav-item">
              <Link className="nav-link active" to="/dashboard/orders">
                Manage Orders
              </Link>
            </li>

            <li className="nav-item">
              <Link
                className="nav-link active"
                to="/dashboard/healthcareproviders"
              >
                Manage Health Care Providers
              </Link>
            </li>

            <li className="nav-item">
              <Link className="nav-link active" to="/dashboard/feedbacks">
                Manage Customer Feedback
              </Link>
            </li>

            <li className="nav-item">
              <Link className="nav-link active" to="/dashboard/services">
                Manage Services
              </Link>
            </li>

            <li className="nav-item">
              <Link className="nav-link active" to="/dashboard/promotions">
                Manage Promotion
              </Link>
            </li>
          </ul>
        </div>
      </nav>
    </>
  );
};

export default Sidebar;

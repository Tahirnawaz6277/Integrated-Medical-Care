import React from "react";
import { Link, NavLink, useNavigate } from "react-router-dom";
import "./style.scss";
import { useDispatch } from "react-redux";
import { loggedOut_User } from "../../Redux/Action";
const Sidebar = () => {
  const navigate = useNavigate();

  const dispatch = useDispatch();
  const handleLogout = () => {
    dispatch(loggedOut_User());
    navigate("/");
  };
  return (
    <>
      <header className="navbar p-3 navbar-dark sticky-top bg-dark flex-md-nowrap p-0 shadow">
        <a
          className="navbar-brand col-md-3 col-lg-2 me-0 px-3"
          href="/dashboard"
        >
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

        <div className="navbar-nav">
          <div className="nav-item text-nowrap">
            <a className="nav-link px-3" href="#" onClick={handleLogout}>
              Sign out
            </a>
          </div>
        </div>
      </header>

      <nav
        id="sidebarMenu"
        className="col-md-3 col-lg-2 d-md-block bg-dark sidebar collapse"
      >
        <div className="position-sticky pt-3">
          <ul className="nav flex-column ">
            <li className="nav-item">
              <NavLink
                end
                className={({ isActive, isPending }) =>
                  isPending ? "pending" : isActive ? "active nav-link" : ""
                }
                to="/dashboard"
              >
                Dashboard
              </NavLink>
            </li>
            <li className="nav-item">
              <NavLink
                end
                className={({ isActive, isPending }) =>
                  isPending ? "pending" : isActive ? "active nav-link" : ""
                }
                to="/dashboard/accounts"
              >
                Manage Accounts
              </NavLink>
            </li>

            <li className="nav-item">
              <NavLink
                end
                className={({ isActive, isPending }) =>
                  isPending ? "pending" : isActive ? "active nav-link" : ""
                }
                to="/dashboard/orders"
              >
                Manage Orders
              </NavLink>
            </li>

            <li className="nav-item">
              <NavLink
                end
                className={({ isActive, isPending }) =>
                  isPending ? "pending" : isActive ? "active nav-link" : ""
                }
                to="/dashboard/healthcareproviders"
              >
                Manage Health Care Providers
              </NavLink>
            </li>

            <li className="nav-item">
              <NavLink
                end
                className={({ isActive, isPending }) =>
                  isPending ? "pending" : isActive ? "active nav-link" : ""
                }
                to="/dashboard/ManageHcpRecord"
              >
                Manage Health Care Provider Records
              </NavLink>
            </li>

            <li className="nav-item">
              <NavLink
                end
                className={({ isActive, isPending }) =>
                  isPending ? "pending" : isActive ? "active nav-link" : ""
                }
                to="/dashboard/feedbacks"
              >
                Manage Customer Feedback
              </NavLink>
            </li>

            <li className="nav-item">
              <NavLink
                end
                className={({ isActive, isPending }) =>
                  isPending ? "pending" : isActive ? "active nav-link" : ""
                }
                to="/dashboard/customerrecord"
              >
                Manage Customer Record
              </NavLink>
            </li>

            <li className="nav-item">
              <NavLink
                end
                className={({ isActive, isPending }) =>
                  isPending ? "pending" : isActive ? "active nav-link" : ""
                }
                to="/dashboard/services"
              >
                Manage Services
              </NavLink>
            </li>

            <li className="nav-item">
              <NavLink
                end
                className={({ isActive, isPending }) =>
                  isPending ? "pending" : isActive ? "active nav-link" : ""
                }
                to="/dashboard/agreement"
              >
                Manage Agreement
              </NavLink>
            </li>

            <li className="nav-item">
              <NavLink
                end
                className={({ isActive, isPending }) =>
                  isPending ? "pending" : isActive ? "active nav-link" : ""
                }
                to="/dashboard/RevenueExpense"
              >
                Manage Revenue & Expense
              </NavLink>
            </li>

            <li className="nav-item">
              <NavLink
                end
                className={({ isActive, isPending }) =>
                  isPending ? "pending" : isActive ? "active nav-link" : ""
                }
                to="/dashboard/promotions"
              >
                Manage Promotion
              </NavLink>
            </li>
          </ul>
        </div>
      </nav>
    </>
  );
};

export default Sidebar;

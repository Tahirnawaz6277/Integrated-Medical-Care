import React, { useEffect, useState } from "react";
import { NavLink, useNavigate } from "react-router-dom";
import "./style.scss";
import { useDispatch, useSelector } from "react-redux";
import { loggedOut_User } from "../../Redux/Action";
import { Badge } from "react-bootstrap";

const Sidebar = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const [loggedInUserRole, setLoggedInUserRole] = useState("");
  const loggedInUser = useSelector(
    (state) => state.actionsReducer.LOGGED_IN_USER
  );

  let getCartItems = useSelector((state) => state.actionsReducer.Cart);

  const handleLogout = () => {
    dispatch(loggedOut_User());
    navigate("/");
  };

  useEffect(() => {
    if (loggedInUser) {
      setLoggedInUserRole(loggedInUser.role);
    } else {
      navigate("/login");
    }
  }, [loggedInUser]);
  return (
    <>
      <header className="navbar p-3 navbar-dark sticky-top bg-dark flex-md-nowrap p-0 shadow">
        <a
          className="navbar-brand col-md-3 col-lg-2 me-0 px-3"
          href="/dashboard/cart"
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
          <div className="nav-item text-nowrap " style={{ display: "flex" }}>
            {loggedInUserRole === "Customer" && (
              <NavLink to="/dashboard/cart">
                <i
                  className="fa-solid fa-cart-shopping text-light"
                  style={{
                    fontSize: "40px",
                    cursor: "pointer",
                    position: "relative",
                    display: "inline-block",
                  }}
                >
                  <Badge
                    pill
                    bg="danger"
                    style={{
                      fontSize: "10px",
                      position: "absolute",
                      top: "-10px",
                      right: "-10px",
                    }}
                  >
                    {getCartItems.length}
                  </Badge>
                </i>
              </NavLink>
            )}

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
                <span>Dashboard</span>
              </NavLink>
            </li>

            {loggedInUserRole === "Admin" && (
              <>
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
              </>
            )}

            {/* --------------------------------- Customer Pannel */}

            {loggedInUserRole === "Customer" && (
              <>
                <li className="nav-item">
                  <NavLink
                    end
                    className={({ isActive, isPending }) =>
                      isPending ? "pending" : isActive ? "active nav-link" : ""
                    }
                    to="/dashboard/provider_services"
                  >
                    Services
                  </NavLink>
                </li>

                <li className="nav-item">
                  <NavLink
                    end
                    className={({ isActive, isPending }) =>
                      isPending ? "pending" : isActive ? "active nav-link" : ""
                    }
                    to="/dashboard/serviceProviders"
                  >
                    Service Providers
                  </NavLink>
                </li>

                <li className="nav-item">
                  <NavLink
                    end
                    className={({ isActive, isPending }) =>
                      isPending ? "pending" : isActive ? "active nav-link" : ""
                    }
                    to="/dashboard/Customerfeedback"
                  >
                    Feedbacks
                  </NavLink>
                </li>
              </>
            )}

            {loggedInUserRole === "ServiceProvider" && (
              <>
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
                    to="/dashboard/promotions"
                  >
                    Manage Promotion
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
                    View Agreements On Quality
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
                    Customer Feedbacks
                  </NavLink>
                </li>
              </>
            )}
          </ul>
        </div>
      </nav>
    </>
  );
};

export default Sidebar;

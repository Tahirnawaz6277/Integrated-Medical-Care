import React, { useEffect, useState } from "react";
import { NavLink, useNavigate } from "react-router-dom";
import "./style.scss";
import { useDispatch, useSelector } from "react-redux";
import { loggedOut_User } from "../../Redux/Action";
import { Badge, Button, Image } from "react-bootstrap";
import swal from "sweetalert2";
import ProfileCard from "./ProfileCard";
import { renderToString } from "react-dom/server";
import "./ProfileCard.scss";
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
  const showProfilePicture = () => {
    const htmlContent = renderToString(<ProfileCard user={loggedInUser} />);
    swal
      .fire({
        html: htmlContent,
        showConfirmButton: true,
        confirmButtonText: "Logout",
        showCancelButton: true,
        cancelButtonText: "Cancel",
        customClass: "sweet-alert-container",
      })
      .then((result) => {
        if (result.isConfirmed) {
          handleLogout();
        }
      });
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
      <header className="navbar p-3 navbar-dark sticky-top  flex-md-nowrap p-0 shadow">
        <a
          className="navbar-brand col-md-3 col-lg-2 me-0 px-3"
          href="/dashboard/cart"
          style={{
            fontSize: "40px",
            fontWeight: "800",
            fontFamily: "FontAwesome",
          }}
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
                    {getCartItems.length >= 1 ? getCartItems.length : 0}
                  </Badge>
                </i>
              </NavLink>
            )}

            <strong style={{ textAlign:"center", color: "white", marginTop: "13px" }}>
              Wellcome<br/>
              {loggedInUser.Name}
            </strong>
            <span
              className="nav-link px-3"
              onClick={showProfilePicture}
              style={{ cursor: "pointer" }}
            >
              <img
                src="https://bootdey.com/img/Content/avatar/avatar1.png"
                alt="Profile"
                style={{ width: "40px", height: "40px", borderRadius: "50%" }}
              />
            </span>
          </div>
        </div>
      </header>

      <nav
        id="sidebarMenu"
        className="col-md-3 col-lg-2 d-md-block  sidebar collapse"
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
                <i className="fa fa-file-alt"></i>

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
                    <i className="fa fa-users-cog"></i>
                    <span> Manage Accounts</span>
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
                    <i className="fa fa-file-invoice-dollar"></i>
                    <span>Manage Orders</span>
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
                    <i className="fa fa-clinic-medical"></i>

                    <span> Manage HCP's</span>
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
                    <i className="fa fa-file-alt"></i>
                    <span> Manage HCP Records</span>
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
                    <i className="fa fa-comments"></i>
                    <span> Manage Feedback</span>
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
                    <i className="fa fa-users"></i>

                    <span> Manage Customer Record</span>
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
                    <i className="fa fa-store"></i>

                    <span> Manage Services</span>
                  </NavLink>
                </li>

                <li className="nav-item">
                  <NavLink
                    end
                    className={({ isActive, isPending }) =>
                      isPending ? "pending" : isActive ? "active nav-link" : ""
                    }
                    to="/dashboard/inventory"
                  >
                    <i className="fa fa-hammer"></i>
                    <span> Manage Inventory</span>
                  </NavLink>
                </li>

                <li className="nav-item">
                  <NavLink
                    end
                    className={({ isActive, isPending }) =>
                      isPending ? "pending" : isActive ? "active nav-link" : ""
                    }
                    to="/dashboard/Revenue"
                  >
                    <i className="fa fa-money-bill"></i>

                    <span> Manage Revenue & Expense</span>
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
                    <i className="fa fa-tags"></i>

                    <span> Manage Promotion</span>
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
                    <i className="fa fa-store"></i>
                    <span>Services </span>
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
                    <i className="fa fa-users" aria-hidden="true"></i>
                    <span>Service Providers </span>
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
                    <i className="fa fa-comments" aria-hidden="true"></i>
                    <span> Feedbacks </span>
                  </NavLink>
                </li>
              </>
            )}

            {/* ------------------------------- Service Provider Pannel */}
            {loggedInUserRole === "ServiceProvider" && (
              <>
                <li className="nav-item">
                  <NavLink
                    end
                    className={({ isActive, isPending }) =>
                      isPending ? "pending" : isActive ? "active nav-link" : ""
                    }
                    to="/dashboard/pservices"
                  >
                    <i className="fa fa-store"></i>
                    <span>Manage Services </span>
                  </NavLink>
                </li>

                <li className="nav-item">
                  <NavLink
                    end
                    className={({ isActive, isPending }) =>
                      isPending ? "pending" : isActive ? "active nav-link" : ""
                    }
                    to="/dashboard/order"
                  >
                    <i className="fa fa-file-invoice-dollar"></i>
                    <span> Manage Orders</span>
                  </NavLink>
                </li>

                <li className="nav-item">
                  <NavLink
                    end
                    className={({ isActive, isPending }) =>
                      isPending ? "pending" : isActive ? "active nav-link" : ""
                    }
                    to="/dashboard/payement"
                  >
                    <i className="fa fa-dollar"></i>
                    <span>Payement</span>
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

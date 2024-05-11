import React, { useEffect, useState } from "react";
import { NavLink, useNavigate } from "react-router-dom";
import "./style.scss";
import { useDispatch, useSelector } from "react-redux";
import { loggedOut_User } from "../../Redux/Action";
import { Badge, Button, Image } from "react-bootstrap";
import swal from "sweetalert2";
import ProfileCard from "./profileCard";
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
    const htmlContent = renderToString(<ProfileCard />);
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
      <header className="navbar p-3 navbar-dark sticky-top bg-dark flex-md-nowrap p-0 shadow">
        <a
          className="navbar-brand col-md-3 col-lg-2 me-0 px-3"
          href="/dashboard/cart"
        >
          <Image src="../../../images/logo.png" style={{ width: "20%" }} />
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

            <strong style={{ color: "white", marginTop: "13px" }}>
              Aamir Nawaz
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
                <i class="fa fa-file-alt"></i>

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
                    <i class="fa fa-users-cog"></i>
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
                    <i class="fa fa-file-invoice-dollar"></i>
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
                    <i class="fa fa-clinic-medical"></i>

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
                    <i class="fa fa-file-alt"></i>
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
                    <i class="fa fa-comments"></i>
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
                    <i class="fa fa-users"></i>

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
                    <i class="fa fa-store"></i>

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
                    <i class="fa fa-hammer"></i>
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
                    <i class="fa fa-money-bill"></i>

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
                    <i class="fa fa-tags"></i>

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
                    <i class="fa fa-store"></i>
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
                    <i class="fa fa-store"></i>
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
                    <i class="fa fa-file-invoice-dollar"></i>
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
                    Payement
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

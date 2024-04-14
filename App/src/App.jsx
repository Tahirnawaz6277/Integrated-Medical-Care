import LoginScreen from "./screens/site/LoginScreen";
import { Route, Routes } from "react-router-dom";
import DashboardLayout from "./layouts/dashboard/DashboardLayout";
import DashboardScreen from "./screens/dashboard/DashboardScreen";
import AuthLayout from "./layouts/AuthLayout/AuthLayout";
import SignupScreen from "./screens/site/SignupScreen";
import ForgotScreen from "./screens/site/ForgotScreen";
import { ProtectedRoute } from "./components/ProtectedRoute";
import AccountScreen from "./screens/dashboard/ManageAccountScreens/AccountScreen";
import OrderScreen from "./screens/dashboard/OrderScreens/OrderScreen";
import HcpScreen from "./screens/dashboard/HcpScreen";
import FeedbackScreen from "./screens/dashboard/FeedbackScreens/FeedbackScreen";
import ServiceScreen from "./screens/dashboard/ServiceScreens/ServiceScreen";
import PromotionScreen from "./screens/dashboard/PromotionScreens/PromotionScreen";
import AddNewHCPScreen from "./screens/dashboard/AddNewHCPScreen";
import AddNewServiceScreen from "./screens/dashboard/ServiceScreens/AddNewServiceScreen";
import { RouteNames } from "./Routes";
import AddOrderScreen from "./screens/dashboard/OrderScreens/AddOrderScreen";
import AddNewPromotionScreen from "./screens/dashboard/PromotionScreens/AddNewPromotionScreen";
import RevenueExpenseScreen from "./screens/dashboard/RevenueExpenseScreens/RevenueExpenseScreen";
import AgreementScreen from "./screens/dashboard/AgreementScreens/AgreementScreen";
import CustomerRecordScreen from "./screens/dashboard/ManageCustomerRecordScreens/CustomerRecordScreen";
import { HcpRecordScreen } from "./screens/dashboard/HcpRecordScreens/HcpRecordScreen";
import CustomerServicesScreen from "./screens/customersPannel/CustomerServicesScreen";
import ServiceProvidersScreen from "./screens/customersPannel/ServiceProvidersScreen";
import Customer_FeedbackScreen from "./screens/customersPannel/Customer_FeedbackScreen";
import ServiceDetailsScreen from "./screens/customersPannel/ServiceDetailsScreen";
import ShoppingCart from "./screens/customersPannel/ShoppingCart";
import CheckoutScreen from "./screens/customersPannel/CheckoutScreen";
import CustomerRatingFeedback from "./screens/customersPannel/CustomerRatingFeedback";

function App() {
  return (
    <>
      <Routes>
        {/* Dashboard Routes */}

        <Route
          path={RouteNames.Admin.Dashboard.route}
          element={<DashboardLayout />}
        >
          <Route
            index
            element={
              <ProtectedRoute allowedRoles={["Customer", "Admin"]}>
                <DashboardScreen />
              </ProtectedRoute>
            }
          />

          <Route
            path={RouteNames.Admin.HealthCareProviders.route}
            element={
              <ProtectedRoute allowedRoles={["Customer", "Admin"]}>
                <HcpScreen />
              </ProtectedRoute>
            }
          />

          <Route
            path={RouteNames.Admin.Services.route}
            element={
              <ProtectedRoute allowedRoles={["Customer", "Admin"]}>
                <ServiceScreen />
              </ProtectedRoute>
            }
          />

          <Route
            path={RouteNames.Admin.Orders.AddNewOrder.route}
            element={<AddOrderScreen />}
          />

          <Route
            path={RouteNames.Admin.HealthCareProviders.route}
            element={<HcpScreen />}
          />

          <Route
            path={RouteNames.Admin.Services.route}
            element={
              <ProtectedRoute allowedRoles={["ServiceProvider", "Admin"]}>
                <ServiceScreen />
              </ProtectedRoute>
            }
          />

          <Route
            path={RouteNames.Admin.Orders.AddNewOrder.route}
            element={<AddOrderScreen />}
          />

          <Route
            path={RouteNames.Admin.ManageAccount.route}
            element={
              <ProtectedRoute
                allowedRoles={RouteNames.Admin.ManageAccount.roles}
              >
                <AccountScreen />
              </ProtectedRoute>
            }
          />

          <Route
            path={RouteNames.Admin.Orders.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <OrderScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Admin.HealthCareProviders.route}
            element={
              <ProtectedRoute
                allowedRoles={["Admin", "Customer", "ServiceProvider"]}
              >
                <HcpScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Admin.HealthCareProviders.AddNewHcp.route}
            element={
              <ProtectedRoute allowedRoles={["Admin", "ServiceProvider"]}>
                <AddNewHCPScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Admin.Feedbacks.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <FeedbackScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Admin.CustomerRecord.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <CustomerRecordScreen />
              </ProtectedRoute>
            }
          />

          <Route
            path={RouteNames.Admin.Services.route}
            element={
              <ProtectedRoute
                allowedRoles={["Admin", "ServiceProvider", "Customer"]}
              >
                <ServiceScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Admin.Services.AddNewService.route}
            element={
              <ProtectedRoute allowedRoles={["Admin", "ServiceProvider"]}>
                <AddNewServiceScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Admin.Promotions.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <PromotionScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Admin.Promotions.SendNewPromotion.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <AddNewPromotionScreen />
              </ProtectedRoute>
            }
          />

          <Route
            path={RouteNames.Admin.AddNewUser.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <SignupScreen />
              </ProtectedRoute>
            }
          />

          <Route
            path={RouteNames.Admin.Orders.AddNewOrder.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <AddOrderScreen />
              </ProtectedRoute>
            }
          />

          <Route
            path={RouteNames.Admin.RevenueExpense.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <RevenueExpenseScreen />
              </ProtectedRoute>
            }
          />

          <Route
            path={RouteNames.Admin.Agreement.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <AgreementScreen />
              </ProtectedRoute>
            }
          />

          <Route
            path={RouteNames.Admin.HcpRecord.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <HcpRecordScreen />
              </ProtectedRoute>
            }
          />

          <Route
            path={RouteNames.Customer.Services.route}
            element={
              <ProtectedRoute
                allowedRoles={["Admin", "ServiceProvider", "Customer"]}
              >
                <CustomerServicesScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Customer.serviceProviders.route}
            element={
              <ProtectedRoute
                allowedRoles={["Admin", "ServiceProvider", "Customer"]}
              >
                <ServiceProvidersScreen />
              </ProtectedRoute>
            }
          />

          <Route
            path={RouteNames.Customer.Feedbacks.route}
            element={
              <ProtectedRoute allowedRoles={["Admin", "Customer"]}>
                <Customer_FeedbackScreen />
              </ProtectedRoute>
            }
          />

          <Route
            path={RouteNames.Customer.Services.ServiceDetail.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <ServiceDetailsScreen />
              </ProtectedRoute>
            }
          />

          <Route
            path={RouteNames.Customer.Add_To_Cart.route}
            element={
              <ProtectedRoute allowedRoles={["Admin", "Customer"]}>
                <ShoppingCart />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Customer.checkout.route}
            element={
              <ProtectedRoute allowedRoles={["Admin", "Customer"]}>
                <CheckoutScreen />
              </ProtectedRoute>
            }
          />

          <Route
            path={RouteNames.Customer.customerFeedback.route}
            element={
              <ProtectedRoute allowedRoles={["Admin", "Customer"]}>
                <CustomerRatingFeedback />
              </ProtectedRoute>
            }
          />
        </Route>

        {/* Auth Routes */}
        <Route path={RouteNames.Default.route} element={<AuthLayout />}>
          <Route index element={<LoginScreen />} />
          <Route
            path={RouteNames.Auth.Register.route}
            element={<SignupScreen />}
          />
          <Route
            path={RouteNames.Auth.Forgot.route}
            element={<ForgotScreen />}
          />
        </Route>
      </Routes>
    </>
  );
}

export default App;

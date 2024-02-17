import LoginScreen from "./screens/site/LoginScreen";
import { Route, Routes } from "react-router-dom";
import DashboardLayout from "./layouts/dashboard/DashboardLayout";
import DashboardScreen from "./screens/dashboard/DashboardScreen";
import AuthLayout from "./layouts/AuthLayout/AuthLayout";
import SignupScreen from "./screens/site/SignupScreen";
import ForgotScreen from "./screens/site/ForgotScreen";
import { ProtectedRoute } from "./components/ProtectedRoute";
import AccountScreen from "./screens/dashboard/AccountScreen";
import OrderScreen from "./screens/dashboard/OrderScreen";
import HcpScreen from "./screens/dashboard/HcpScreen";
import FeedbackScreen from "./screens/dashboard/FeedbackScreen";
import ServiceScreen from "./screens/dashboard/ServiceScreen";
import PromotionScreen from "./screens/dashboard/PromotionScreen";
import AddNewHCPScreen from "./screens/dashboard/AddNewHCPScreen";
import { RouteNames } from "./Routes";

function App() {
  return (
    <>
      <Routes>
        {/* Dashboard Routes */}
        <Route
          path={RouteNames.Admin.Dashboard.route}
          element={<ProtectedRoute component={DashboardLayout} />}
        >
          <Route index element={<DashboardScreen />} />
          <Route
            path={RouteNames.Admin.ManageAccount.route}
            element={<AccountScreen />}
          />
          <Route
            path={RouteNames.Admin.Orders.route}
            element={<OrderScreen />}
          />
          <Route
            path={RouteNames.Admin.HealthCareProviders.route}
            element={<HcpScreen />}
          />
          <Route
            path={RouteNames.Admin.AddNewHcp.route}
            element={<AddNewHCPScreen />}
          />
          <Route
            path={RouteNames.Admin.Feedbacks.route}
            element={<FeedbackScreen />}
          />
          <Route
            path={RouteNames.Admin.Services.route}
            element={<ServiceScreen />}
          />
          <Route
            path={RouteNames.Admin.Promotions.route}
            element={<PromotionScreen />}
          />
          <Route
            path={RouteNames.Admin.AddNewUser.route}
            element={<SignupScreen />}
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

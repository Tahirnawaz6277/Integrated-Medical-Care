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
            path={RouteNames.Admin.HealthCareProviders.AddNewHcp.route}
            element={<AddNewHCPScreen />}
          />
          <Route
            path={RouteNames.Admin.Feedbacks.route}
            element={<FeedbackScreen />}
          />
          <Route
            path={RouteNames.Admin.CustomerRecord.route}
            element={<CustomerRecordScreen />}
          />

          <Route
            path={RouteNames.Admin.Services.route}
            element={<ServiceScreen />}
          />
          <Route
            path={RouteNames.Admin.Services.AddNewService.route}
            element={<AddNewServiceScreen />}
          />
          <Route
            path={RouteNames.Admin.Promotions.route}
            element={<PromotionScreen />}
          />
          <Route
            path={RouteNames.Admin.Promotions.SendNewPromotion.route}
            element={<AddNewPromotionScreen />}
          />
          <Route
            path={RouteNames.Admin.AddNewUser.route}
            element={<SignupScreen />}
          />

          <Route
            path={RouteNames.Admin.Orders.AddNewOrder.route}
            element={<AddOrderScreen />}
          />

          <Route
            path={RouteNames.Admin.RevenueExpense.route}
            element={<RevenueExpenseScreen />}
          />

          <Route
            path={RouteNames.Admin.Agreement.route}
            element={<AgreementScreen />}
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

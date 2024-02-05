import LoginScreen from "./screens/LoginScreen";
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

function App() {
  return (
    <>
      <Routes>
        {/* Dashboard Routes */}
        <Route
          path="/dashboard"
          element={<ProtectedRoute component={DashboardLayout} />}
        >
          <Route index element={<DashboardScreen />} />
          <Route path="accounts" element={<AccountScreen />} />
          <Route path="orders" element={<OrderScreen />} />
          <Route path="healthcareproviders" element={<HcpScreen />} />
          <Route path="feedbacks" element={<FeedbackScreen />} />
          <Route path="services" element={<ServiceScreen />} />
          <Route path="promotions" element={<PromotionScreen />} />
        </Route>

        {/* Auth Routes */}
        <Route path="/" element={<AuthLayout />}>
          <Route index element={<LoginScreen />} />
          <Route path="signup" element={<SignupScreen />} />
          <Route path="forgot" element={<ForgotScreen />} />
        </Route>
      </Routes>
    </>
  );
}

export default App;

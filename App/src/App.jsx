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

import FeedbackScreen from "./screens/dashboard/FeedbackScreens/FeedbackScreen";
import ServiceScreen from "./screens/dashboard/ServiceScreens/ServiceScreen";
import PromotionScreen from "./screens/dashboard/PromotionScreens/PromotionScreen";
import AddNewServiceScreen from "./screens/dashboard/ServiceScreens/AddNewServiceScreen";
import { RouteNames } from "./Routes";
import AddOrderScreen from "./screens/dashboard/OrderScreens/AddOrderScreen";
import AddNewPromotionScreen from "./screens/dashboard/PromotionScreens/AddNewPromotionScreen";
import CustomerRecordScreen from "./screens/dashboard/ManageCustomerRecordScreens/CustomerRecordScreen";
import { HcpRecordScreen } from "./screens/dashboard/HcpRecordScreens/HcpRecordScreen";
import CustomerServicesScreen from "./screens/customersPannel/CustomerServicesScreen";
import ServiceProvidersScreen from "./screens/customersPannel/ServiceProvidersScreen";
import Customer_FeedbackScreen from "./screens/customersPannel/Customer_FeedbackScreen";
import ServiceDetailsScreen from "./screens/customersPannel/ServiceDetailsScreen";
import ShoppingCart from "./screens/customersPannel/ShoppingCart";
import CheckoutScreen from "./screens/customersPannel/CheckoutScreen";
import CustomerRatingFeedback from "./screens/customersPannel/CustomerRatingFeedback";
import ProviderServiceScreen from "./screens/serviceProvidersPannel/ProviderServicesScreen/ProviderServiceScreen";
import CreateServiceScreen from "./screens/serviceProvidersPannel/ProviderServicesScreen/CreateServiceScreen";
import ManageOrderScreen from "./screens/serviceProvidersPannel/ProviderOrdersScreens/ManageOrderScreen";
import UpdateServiceScreen from "./screens/serviceProvidersPannel/ProviderServicesScreen/UpdateServiceScreen";
import ProviderPayementScreen from "./screens/serviceProvidersPannel/ProviderServicesScreen/ProviderPayementScreen";
import AddNewHCPScreen from "./screens/dashboard/HCPScreens/AddNewHCPScreen";
import ManageHcpScreen from "./screens/dashboard/HCPScreens/ManageHcpScreen";
import UpdateUserScreen from "./screens/dashboard/ManageAccountScreens/UpdateUserScreen";
import InventoryScreen from "./screens/dashboard/InventoryScreens/InventoryScreen";
import RevenueScreen from "./screens/dashboard/RevenueExpenseScreens/RevenueScreen";
import AddRevenue from "./screens/dashboard/RevenueExpenseScreens/AddRevenue";
import AddInventoryScreen from "./screens/dashboard/InventoryScreens/AddInventoryScreen";
import UpdateInventoryScreen from "./screens/dashboard/InventoryScreens/UpdateInventoryScreen";
import UpdateRevenueScreen from "./screens/dashboard/RevenueExpenseScreens/UpdateRevenueScreen";
import AddExpenseScreen from "./screens/dashboard/RevenueExpenseScreens/AddExpenseScreen";
import ExpenseScreen from "./screens/dashboard/RevenueExpenseScreens/ExpenseScreen";
import UpdateExpenseScreen from "./screens/dashboard/RevenueExpenseScreens/UpdateExpenseScreen";
import TransferPaymentScreen from "./screens/serviceProvidersPannel/ProviderServicesScreen/TransferPaymentScreen";

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
              <ProtectedRoute
                allowedRoles={["Customer", "ServiceProvider", "Admin"]}
              >
                <DashboardScreen />
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
            path={RouteNames.SProvider.Services.route}
            element={
              <ProtectedRoute allowedRoles={["ServiceProvider", "Admin"]}>
                <ProviderServiceScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.SProvider.Services.CreateNewService.route}
            element={
              <ProtectedRoute allowedRoles={["ServiceProvider"]}>
                <CreateServiceScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.SProvider.Services.UpdateService.route}
            element={
              <ProtectedRoute allowedRoles={["ServiceProvider", "Admin"]}>
                <UpdateServiceScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Admin.AddNewUser.UpdateUser.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <UpdateUserScreen />
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
            path={RouteNames.SProvider.Order.route}
            element={
              <ProtectedRoute allowedRoles={["ServiceProvider"]}>
                <ManageOrderScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.SProvider.Payement.route}
            element={
              <ProtectedRoute allowedRoles={["ServiceProvider"]}>
                <ProviderPayementScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.SProvider.Payement.TransferPayement.route}
            element={
              <ProtectedRoute allowedRoles={["ServiceProvider"]}>
                <TransferPaymentScreen />
              </ProtectedRoute>
            }
          />

          <Route
            path={RouteNames.Admin.Services.route}
            element={
              <ProtectedRoute
                allowedRoles={["ServiceProvider", "Admin", "Customer"]}
              >
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
              <ProtectedRoute allowedRoles={["Admin"]}>
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
                <ManageHcpScreen />
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
              <ProtectedRoute allowedRoles={["Admin", "Customer"]}>
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
            path={RouteNames.Admin.Revenue.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <RevenueScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Admin.Expense.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <ExpenseScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Admin.Expense.AddExpense.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <AddExpenseScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Admin.Expense.EditExpense.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <UpdateExpenseScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Admin.Revenue.AddRevenue.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <AddRevenue />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Admin.Revenue.UpdateRevenue.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <UpdateRevenueScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Admin.Inventory.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <InventoryScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Admin.Inventory.AddInventory.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <AddInventoryScreen />
              </ProtectedRoute>
            }
          />
          <Route
            path={RouteNames.Admin.Inventory.UpdateInventory.route}
            element={
              <ProtectedRoute allowedRoles={["Admin"]}>
                <UpdateInventoryScreen />
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

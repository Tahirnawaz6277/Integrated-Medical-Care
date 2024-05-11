let BASE_URL = import.meta.env.VITE_API_URL;

export const endPoints = {
  Account: {
    Login: `${BASE_URL}/Auth/Login`,
    Signup: `${BASE_URL}/Auth/SignUp`,
    GetUsers: `${BASE_URL}/ManageAcount/GetUsers`,
    DeleteUser: `${BASE_URL}/ManageAcount/DeleteUser`,
    UpdateUser: `${BASE_URL}/ManageAcount/UpdateUser`,
    AddUser: `${BASE_URL}/ManageAcount/CreateUser`,
    GetUser: `${BASE_URL}/ManageAcount/GetUserById`,
  },
  Orders: {
    GetOrders: `${BASE_URL}/ManageOrder/GetOrders`,
    GetOrder: `${BASE_URL}/ManageOrder/GetOrder`,
    DeleteOrder: `${BASE_URL}/ManageOrder/DeleteOrder`,
    AddOrder: `${BASE_URL}/ManageOrder/AddOrder`,
    UpdateOrder: `${BASE_URL}/ManageOrder/UpdateOrder`,
  },
  ServiceProviders: {
    GetHCPs: `${BASE_URL}/ManageHCP/GetHCPs`,
    GetSingleHCP: `${BASE_URL}/ManageHCP/GetHCP`,
    DeleteHcp: `${BASE_URL}/ManageHCP/DeleteHCP`,
    UpdateHCP: `${BASE_URL}/ManageHCP/UpdateHCP`,
    AddHCP: `${BASE_URL}/ManageHCP/AddHCP`,
  },

  Feedbacks: {
    AddFeedback: `${BASE_URL}/ManageFeedBack/AddFeedback`,
    GetFeedbacks: `${BASE_URL}/ManageFeedBack/GetFeedbacks`,
    DeleteFeedback: `${BASE_URL}/ManageFeedBack/DeleteFeedback`,
  },

  Services: {
    GetServices: `${BASE_URL}/ManageServices/GetServices`,
    GetServicebyId: `${BASE_URL}/ManageServices/GetServiceById`,
    DeleteService: `${BASE_URL}/ManageServices/DeleteService`,
    AddService: `${BASE_URL}/ManageServices/AddService`,
    EditService: `${BASE_URL}/ManageServices/UpdateService`,
  },

  Promotions: {
    GetPromotions: `${BASE_URL}/ManagePromotion/GetPromotions`,
    SendPromotion: `${BASE_URL}/ManagePromotion/AddPromotion`,
    DeletePromotion: `${BASE_URL}/ManagePromotion/DeletePromotion`,
  },

  Qualifications: {
    AddQualification: `${BASE_URL}/Auth/AddQualification`,
  },

  OrderItems: {
    Add_OrderItems: `${BASE_URL}/OrderItem/OrderItem`,
  },

  Expense: {
    GetExpenses: `${BASE_URL}/ManageExpense/GetExpenses`,
    GetExpenseById: `${BASE_URL}/ManageExpense/GetExpenseById`,
    DeleteExpense: `${BASE_URL}/ManageExpense/DeleteExpense`,
    AddExpense: `${BASE_URL}/ManageExpense/AddExpense`,
    UpdateExpense: `${BASE_URL}/ManageExpense/UpdateExpense`,
  },

  Revenue: {
    GetRevenues: `${BASE_URL}/ManageRevenue/GetRevenues`,
    GetRevenueById: `${BASE_URL}/ManageRevenue/GetRevenueById`,
    DeleteRevenue: `${BASE_URL}/ManageRevenue/DeleteRevenue`,
    AddRevenue: `${BASE_URL}/ManageRevenue/AddRevenue`,
    UpdateRevenue: `${BASE_URL}/ManageRevenue/UpdateRevenue`,
  },

  Inventory: {
    getInventories: `${BASE_URL}/ManageInventory/GetInventories`,
    getInventoryById: `${BASE_URL}/ManageInventory/getInventoryById`,
    DeleteInventory: `${BASE_URL}/ManageInventory/DeleteInventory`,
    AddInventory: `${BASE_URL}/ManageInventory/AddInventory`,
    UpdateInventory: `${BASE_URL}/ManageInventory/UpdateInventory`,
  },
};

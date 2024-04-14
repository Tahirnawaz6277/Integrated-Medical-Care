let BASE_URL = import.meta.env.VITE_API_URL;

export const endPoints = {
  Account: {
    Login: `${BASE_URL}/Auth/Login`,
    Signup: `${BASE_URL}/Auth/SignUp`,
    GetUsers: `${BASE_URL}/ManageAcount/GetUsers`,
    DeleteUser: `${BASE_URL}/ManageAcount/DeleteUser`,
    UpdateUser: `${BASE_URL}/ManageAcount/UpdateUser`,
    AddUser: `${BASE_URL}/ManageAcount/CreateUser`,
  },
  Orders: {
    GetOrders: `${BASE_URL}/ManageOrder/GetOrders`,
    DeleteOrder: `${BASE_URL}/ManageOrder/DeleteOrder`,
    AddOrder: `${BASE_URL}/ManageOrder/AddOrder`,
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

    DeleteService: `${BASE_URL}/ManageServices/DeleteService`,
    AddService: `${BASE_URL}/ManageServices/AddService`,
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
};

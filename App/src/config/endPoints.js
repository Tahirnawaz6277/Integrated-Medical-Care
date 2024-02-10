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
  },
  ServiceProviders: {
    GetHCPs: `${BASE_URL}/ManageHCP/GetHCPs`,
    DeleteHCP: `${BASE_URL}/ManageHCP/DeleteHCP`,
    UpdateHCP: `${BASE_URL}/ManageHCP/UpdateHCP`,
    AddHCP: `${BASE_URL}/ManageHCP/AddHCP`,
  },
};

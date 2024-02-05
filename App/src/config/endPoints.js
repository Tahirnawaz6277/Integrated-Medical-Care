let BASE_URL = import.meta.env.VITE_API_URL;
let loginurl = "https://localhost:7270/api";
export const endPoints = {
  Account: {
    Login: `${loginurl}/Auth/Login`,
    Signup: `${BASE_URL}/Auth/SignUp`,
  },
};

import axios from "axios";
import { endPoints } from "../config/endPoints";

export const registerUser = async (data) => {
  let result = await axios.post(endPoints.Account.Signup, data);
  return result.data;
};

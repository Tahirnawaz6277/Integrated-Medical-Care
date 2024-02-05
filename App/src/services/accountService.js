import axios from "axios";
import { endPoints } from "../config/endPoints";

export const registerUser = async (data) => {
  let result = await axios.post(endPoints.Account.Signup, data);

  return result.data;
};

export const getUsers = async () => {
  let result = await axios.get(endPoints.Account.GetUsers);
  return result.data;
};

export const deleteUser = async (id) => {
  let result = await axios.delete(`${endPoints.Account.DeleteUser}/${id}`);

  return result.data;
};

export const loginUser = async (data) => {
  let result = await axios.post(endPoints.Account.Login, data);
  return result.data;
};

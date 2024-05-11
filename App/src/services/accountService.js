import axios from "axios";
import { endPoints } from "../config/endPoints";

export const registerUser = async (
  data,
  serviceProviderTypeId = null,
  QualificationId = null
) => {
  data.ServiceProvidertypeId = serviceProviderTypeId;
  data.User_QualificationId = QualificationId;
  let result = await axios.post(endPoints.Account.Signup, data);
  return result.data;
};

export const getUsers = async (filterOn = null, filterQuery = null) => {
  const url = `${endPoints.Account.GetUsers}?filterOn=${filterOn}&filterQuery=${filterQuery}`;
  let result = await axios.get(url);
  return result.data;
};

export const getSingleUser = async (id) => {
  const url = `${endPoints.Account.GetUser}/${id}`;
  let result = await axios.get(url);
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

export const addUser = async (data) => {
  let result = await axios.post(endPoints.Account.AddUser, data);
  return result.data;
};

export const editUser = async (id, data, loggedIn_User) => {
  let result = await axios.put(`${endPoints.Account.UpdateUser}/${id}`, data);
  return result.data;
};

export const Add_User_Qualification = async (data) => {
  let result = await axios.post(
    endPoints.Qualifications.AddQualification,
    data
  );
  return result.data;
};

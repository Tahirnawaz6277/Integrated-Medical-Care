import axios from "axios";
import { endPoints } from "../config/endPoints";

export const getOrders = async (loggedIn_User) => {
  const result = await axios.get(endPoints.Orders.GetOrders, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });
  return result.data;
};
export const DeleteOrder = async (id, loggedIn_User) => {
  let result = await axios.delete(`${endPoints.Orders.DeleteOrder}/${id}`, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });
  return result.data;
};

export const AddOrder = async (data, loggedIn_User) => {
  data.OrderByUserId = loggedIn_User.LoggedIn_User_Id;
  let result = await axios.post(endPoints.Orders.AddOrder, data, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });
  return result.data;
};

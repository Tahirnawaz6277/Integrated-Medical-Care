import axios from "axios";
import { endPoints } from "../config/endPoints";

export const getRevenues = async (loggedIn_User) => {
  const result = await axios.get(endPoints.Revenue.GetRevenues, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });
  return result.data;
};

export const getRevenue = async (id, loggedIn_User) => {
  const result = await axios.get(`${endPoints.Revenue.GetRevenueById}/${id}`, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });

  return result.data;
};

export const addRevenue = async (data, loggedIn_User) => {
  data.payerId = loggedIn_User.LoggedIn_User_Id;
  let result = await axios.post(endPoints.Revenue.AddRevenue, data, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });

  return result.data;
};

export const deleteRevenue = async (id, loggedIn_User) => {
  const result = await axios.delete(
    `${endPoints.Revenue.DeleteRevenue}/${id}`,
    {
      headers: {
        Authorization: `Bearer ${loggedIn_User.token}`,
      },
    }
  );

  return result.data;
};

export const updateRevenue = async (id, data, loggedIn_User) => {
  const result = await axios.put(
    `${endPoints.Revenue.UpdateRevenue}/${id}`,
    data,
    {
      headers: {
        Authorization: `Bearer ${loggedIn_User.token}`,
      },
    }
  );

  return result.data;
};

import axios from "axios";
import { endPoints } from "../config/endPoints";
import exp from "constants";

export const getServices = async (loggedIn_User) => {
  const result = await axios.get(endPoints.Services.GetServices, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });

  return result.data;
};

export const getService = async (id, loggedIn_User) => {
  const result = await axios.get(`${endPoints.Services.GetServicebyId}/${id}`, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });

  return result.data;
};

export const DeleteService = async (id, loggedIn_User) => {
  let result = await axios.delete(
    `${endPoints.Services.DeleteService}?id=${id}`,
    {
      headers: {
        Authorization: `Bearer ${loggedIn_User.token}`,
      },
    }
  );
console.log(result);
  return result.data;
};

export const AddService = async (data, loggedIn_User) => {
  let result = await axios.post(endPoints.Services.AddService, data, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });

  return result.data;
};

export const updateService = async (data, loggedIn_User) => {
  let id = data.serviceId;
  const service = {
    serviceName: data.serviceName,
    charges: data.charges,
    image: data.charges,
    totalQuantity: data.totalQuantity,
    availableQuantity: data.availableQuantity,
    status: data.status,
  };
  let result = await axios.put(
    `${endPoints.Services.EditService}/${id}`,
    service,
    {
      headers: {
        Authorization: `Bearer ${loggedIn_User.token}`,
      },
    }
  );
  return result.data;
};

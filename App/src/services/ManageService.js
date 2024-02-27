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

export const DeleteService = async (id, loggedIn_User) => {
  let result = await axios.delete(
    `${endPoints.Services.DeleteService}?id=${id}`,
    {
      headers: {
        Authorization: `Bearer ${loggedIn_User.token}`,
      },
    }
  );

  return result.data;
};

export const AddService = async (data, loggedIn_User) => {
  data.CreatedByAdminId = loggedIn_User.LoggedIn_User_Id;
  let result = await axios.post(endPoints.Services.AddService, data, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });

  return result.data;
};

// CreatedByProviderTypeId: "",
//       CreatedByAdminId: "",

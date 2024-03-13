import axios from "axios";
import { endPoints } from "../config/endPoints";

export const getPromotions = async (loggedIn_User) => {
  let result = await axios.get(endPoints.Promotions.GetPromotions, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });
  return result.data;
};

export const SendPromotion = async (data, loggedIn_User) => {
  data.PromoteById = loggedIn_User.LoggedIn_User_Id;
  let result = await axios.post(endPoints.Promotions.SendPromotion, data, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });

  return result.data;
};

export const DeletePromotion = async (id, loggedIn_User) => {
  let result = await axios.delete(
    `${endPoints.Promotions.DeletePromotion}/${id}`,
    {
      headers: {
        Authorization: `Bearer ${loggedIn_User.token}`,
      },
    }
  );

  return result.data;
};

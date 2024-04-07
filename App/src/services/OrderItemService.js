import axios from "axios";
import { endPoints } from "../config/endPoints";

export const AddOrderItems = async (data) => {
  const res = await axios.post(endPoints.OrderItems.Add_OrderItems, data, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });

  return res.data;
};

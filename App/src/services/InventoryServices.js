import axios from "axios";
import { endPoints } from "../config/endPoints";


export const getInventory = async (loggedIn_User) => {
  const result = await axios.get(endPoints.Inventory.getInventories, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });

  return result.data;
};
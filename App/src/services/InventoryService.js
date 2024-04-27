import axios from "axios";
import { endPoints } from "../config/endPoints";

export const AddInventory = async (data, loggedIn_User) => {
  let result = await axios.post(endPoints.Inventory.AddInventory, data, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });

  return result.data;
};

export const getInventories = async (loggedIn_User) => {
  const result = await axios.get(endPoints.Inventory.getInventories, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });

  return result.data;
};

export const getInventory = async (id, loggedIn_User) => {
  const result = await axios.get(
    `${endPoints.Inventory.getInventoryById}/${id}`,
    {
      headers: {
        Authorization: `Bearer ${loggedIn_User.token}`,
      },
    }
  );

  return result.data;
};

export const DeleteInventory = async (id, loggedIn_User) => {
  const result = await axios.delete(
    `${endPoints.Inventory.DeleteInventory}/${id}`,
    {
      headers: {
        Authorization: `Bearer ${loggedIn_User.token}`,
      },
    }
  );

  return result.data;
};

export const UpdateInventory = async (id, data, loggedIn_User) => {
  const result = await axios.put(
    `${endPoints.Inventory.UpdateInventory}/${id}`,
    data,
    {
      headers: {
        Authorization: `Bearer ${loggedIn_User.token}`,
      },
    }
  );

  return result.data;
};

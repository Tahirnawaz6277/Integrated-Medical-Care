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




export const UpdateSingleInventory = async ( id,newQuantity,Inventory, loggedIn_User) => {
  


  // Find the inventory item by id
  const item = Inventory.find(element => element.id === id);

  // If item is not found, handle the error
  if (!item) {
    return {
      success: false,
      message: 'Inventory item not found.',
    };
  }

  // Extract oldQuantity
  const oldQuantity = item.availableQuantity;

  // Calculate the new available quantity
  const sub = oldQuantity - newQuantity;

  // Check if the result is negative
  if (sub < 0) {
    return {
      success: false,
      message: 'Invalid operation: resulting available quantity cannot be negative.',
    };
  }



  const patchDocument = [
    {
      path: "/availableQuantity",
      op: "replace",
      value: sub,
    },
  ];

  

  const result = await axios.patch(
    `${endPoints.Inventory.UpdateInventoryQuantity}/${id}`,
    patchDocument,
    {
      headers: {
        Authorization: `Bearer ${loggedIn_User.token}`,
      
      },
    }
  );

  return result.data;

};

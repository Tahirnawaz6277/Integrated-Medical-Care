import axios from "axios";
import { endPoints } from "../config/endPoints";

export const getOrders = async () => {
  const result = await axios.get(endPoints.Orders.GetOrders);
  return result.data;
};
export const DeleteOrder = async (id) => {
  let result = await axios.delete(`${endPoints.Orders.DeleteOrder}/${id}`);
  return result.data;
};

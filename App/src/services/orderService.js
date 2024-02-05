import axios from "axios";
import React from "react";
import { endPoints } from "../config/endPoints";

export const getOrders = async () => {
  const result = await axios.get(endPoints.Orders.GetOrders);
  return result.data;
};

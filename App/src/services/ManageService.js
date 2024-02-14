import axios from "axios";
import { endPoints } from "../config/endPoints";

export const getServices = async () => {
  const result = await axios.get(endPoints.Services.GetServices);
  return result.data;
};

export const DeleteService = async (id) => {
  let result = await axios.delete(
    `${endPoints.Services.DeleteService}?id = ${id}`
  );
  return result.data;
};

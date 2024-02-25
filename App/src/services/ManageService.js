import axios from "axios";
import { endPoints } from "../config/endPoints";
import exp from "constants";

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

export const AddService = async (data) => {
  let result = await axios.post(endPoints.Services.AddService, data);
  return result.data;
};

import axios from "axios";
import { endPoints } from "../config/endPoints";

export const getServices = async () => {
  const result = await axios.get(endPoints.Services.GetServices);
  return result.data;
};

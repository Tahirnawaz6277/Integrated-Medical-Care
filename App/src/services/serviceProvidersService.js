import axios from "axios";
import { endPoints } from "../config/endPoints";

export const getServiceProviders = async () => {
  const result = await axios.get(
    endPoints.ServiceProviders.GetServiceProviders
  );
  return result.data;
};

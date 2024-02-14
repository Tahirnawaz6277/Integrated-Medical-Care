import axios from "axios";
import { endPoints } from "../config/endPoints";

export const GetServiceProviders = async () => {
  const result = await axios.get(endPoints.ServiceProviders.GetHCPs);
  return result.data;
};

export const DeleteServiceProviders = async (id) => {
  let result = await axios.delete(
    `${endPoints.ServiceProviders.DeleteHCP}?id=${id}`
  );

  return result.data;
};

export const AddServiceProviders = async (data) => {
  const result = await axios.post(endPoints.ServiceProviders.AddHCP, data);
  return result.data;
};

export const UpdateServiceProviders = async (id, data) => {
  const result = await axios.put(
    `${endPoints.ServiceProviders.UpdateHCP}/${id}`,
    data
  );
  return result.data;
};

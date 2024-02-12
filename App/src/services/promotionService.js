import axios from "axios";
import { endPoints } from "../config/endPoints";

export const getPromotions = async () => {
  let result = await axios.get(endPoints.Promotions.GetPromotions);
  return result.data;
};

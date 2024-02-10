import axios from "axios";
import { endPoints } from "../config/endPoints";

export const getFeedbacks = async () => {
  let result = await axios.get(endPoints.Feedbacks.GetFeedbacks);
  return result.data;
};

import axios from "axios";
import { endPoints } from "../config/endPoints";

export const getFeedbacks = async () => {
  let result = await axios.get(endPoints.Feedbacks.GetFeedbacks);
  return result.data;
};
export const DeleteFeedback = async (id) => {
  let result = await axios.delete(
    `${endPoints.Feedbacks.DeleteFeedback}?id=${id}`
  );
  return result.data;
};

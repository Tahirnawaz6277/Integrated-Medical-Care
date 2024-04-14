import axios from "axios";
import { endPoints } from "../config/endPoints";

export const addFeedback = async (feedback, loggedIn_User) => {
  feedback.ratedById = loggedIn_User.LoggedIn_User_Id;

  const result = await axios.post(endPoints.Feedbacks.AddFeedback, feedback, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });
  return result.data;
};

export const getFeedbacks = async (loggedIn_User) => {
  let result = await axios.get(endPoints.Feedbacks.GetFeedbacks, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });

  return result.data;
};

export const DeleteFeedback = async (id, loggedIn_User) => {
  let result = await axios.delete(
    `${endPoints.Feedbacks.DeleteFeedback}?id=${id}`,
    {
      headers: {
        Authorization: `Bearer ${loggedIn_User.token}`,
      },
    }
  );

  return result.data;
};

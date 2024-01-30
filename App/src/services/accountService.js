import { endPoints } from "../config/endPoints";

export const onUserLogin = (data) => {
  let result = axios.post(endPoints.Account.Login, data);
  return result;
};

export const loggedIn_User = (data) => {
  return {
    type: "SET_LOGGED_IN_USER_ID",
    payload: data,
  };
};

export const loggedOut_User = () => {
  return {
    type: "SET_LOGGED_Out_USER",
  };
};

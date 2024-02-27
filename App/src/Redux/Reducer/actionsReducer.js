const initialState = {
  LOGGED_IN_USER: null,
};

export const actionsReducer = (state = initialState, action) => {
  switch (action.type) {
    case "SET_LOGGED_IN_USER_ID":
      return {
        ...state,
        LOGGED_IN_USER: action.payload,
      };

    case "SET_LOGGED_Out_USER":
      return {
        ...state,
        LOGGED_IN_USER: null,
      };

    default:
      return state;
  }
};

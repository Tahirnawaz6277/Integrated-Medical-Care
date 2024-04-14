const initialState = {
  LOGGED_IN_USER: null,
  Cart: [],
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

    case "Add_To_Cart":
      var itemExistsIndex = state.Cart.findIndex(
        (item) => item.id === action.payload.id
      );

      if (itemExistsIndex >= 0) {
        state.Cart[itemExistsIndex].quantity += 1;
      } else {
        let new_Item = { ...action.payload, quantity: 1 };
        return {
          // ...state,
          // Cart: [],

          ...state,
          Cart: [...state.Cart, new_Item],
        };
      }

    case "Delete_From_Cart":
      let result = state.Cart.filter((item) => {
        return item.id !== action.payload;
      });
      return {
        ...state,
        Cart: result,
      };

    default:
      return state;
  }
};

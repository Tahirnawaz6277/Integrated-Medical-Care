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
      if (!state.Cart) {
        return {
          ...state,
          Cart: [],
        };
      }

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

      case "Cart_Empty":
        return {
          ...state,
          Cart: [],
        };

        case "Increment":
          var itemExistsIndex = state.Cart.findIndex(
            (item) => item.id === action.payload
          );
  
          if (itemExistsIndex >= 0) {
            const newCart = [...state.Cart];
            newCart[itemExistsIndex].quantity += 1;
            return {
              ...state,
              Cart: newCart,
            };
          } else {
            return state; // if the item does not exist in the cart
          }
  

          case "Decrement":
            var decrementIndex = state.Cart.findIndex(
              (item) => item.id === action.payload
            );
      
            if (decrementIndex >= 0) {
              const newCart = [...state.Cart];
              if (newCart[decrementIndex].quantity > 1) {
                newCart[decrementIndex].quantity -= 1;
              } else {
                newCart.splice(decrementIndex, 1);
              }
              return {
                ...state,
                Cart: newCart,
              };
            } else {
              return state; // if the item does not exist in the cart
            }

    default:
      return state;
  }
};

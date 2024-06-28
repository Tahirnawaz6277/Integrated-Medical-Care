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

export const AddToCart = (data) => {
  return {
    type: "Add_To_Cart",
    payload: data,
  };
};

export const DeleteFromCart = (id) => {
  return {
    type: "Delete_From_Cart",
    payload: id,
  };
};


export const Cart_Empty = () => ({
  type: "Cart_Empty",
});


export const IncrementQuantity = (id) => ({
  type: "Increment",
  payload:id
});


export const DecrementQuantity = (id) => ({
  type: "Decrement",
  payload: id,
});

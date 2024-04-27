import axios from "axios";
import { endPoints } from "../config/endPoints";

export const getOrders = async (loggedIn_User) => {
  const result = await axios.get(endPoints.Orders.GetOrders, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });
  return result.data;
};
export const DeleteOrder = async (id, loggedIn_User) => {
  let result = await axios.delete(`${endPoints.Orders.DeleteOrder}/${id}`, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });
  return result.data;
};

export const AddOrder = async (orderData, loggedIn_User) => {
  orderData.OrderByUserId = loggedIn_User.LoggedIn_User_Id;

  // Iterate over each service ID and create an order for each
  const ordersPromises = orderData.serviceId.map(async (serviceId, index) => {
    const order = {
      contact: orderData.contact,
      address: orderData.address,
      amount: orderData.amount[index],
      paymentMode: orderData.paymentMode,
      quantity: orderData.quantity[index],
      OrderByUserId: orderData.OrderByUserId,
      serviceId: serviceId,
      Paid: true,
    };

    return axios.post(endPoints.Orders.AddOrder, order, {
      headers: {
        Authorization: `Bearer ${loggedIn_User.token}`,
      },
    });
  });

  const orderResponses = await Promise.all(ordersPromises);

  // Gather all order IDs
  const orderIds = orderResponses.map((response) => response.data.data.id);

  // Prepare order items array
  const orderItems = orderData.serviceId.map((serviceId, index) => ({
    ServiceId: serviceId,
    OrderId: orderIds[index],
    Quantity: orderData.quantity[index],
  }));

  // Insert all order items asynchronously
  const orderItemPromises = orderItems.map((element) => {
    return axios.post(endPoints.OrderItems.Add_OrderItems, element, {
      headers: {
        Authorization: `Bearer ${loggedIn_User.token}`,
      },
    });
  });

  const orderItemRes = await Promise.all(orderItemPromises);

  return orderItemRes;
};

export const UpdateOrderStatus = async (id, loggedIn_User, status) => {
  const patchDocument = [
    {
      path: "/orderStatus",
      op: "replace",
      value: status,
    },
  ];

  const result = await axios.patch(
    `${endPoints.Orders.UpdateOrder}/${id}`,
    patchDocument,
    {
      headers: {
        Authorization: `Bearer ${loggedIn_User.token}`,
      },
    }
  );

  return result.data;
};

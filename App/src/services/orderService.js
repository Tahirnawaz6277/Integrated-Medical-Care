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

export const getOrder = async (id, loggedIn_User) => {
  const result = await axios.get(`${endPoints.Orders.GetOrder}/${id}`, {
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

// export const AddOrder = async (orderData, loggedIn_User) => {
//   orderData.OrderByUserId = loggedIn_User.LoggedIn_User_Id;

//   let role = loggedIn_User.role;

//   if (role !== "Admin") {
//     // Iterate over each service ID and create an order for each
//     const ordersPromises = orderData.serviceId.map(async (serviceId, index) => {
//       const order = {
//         contact: orderData.contact,
//         address: orderData.address,
//         amount: orderData.amount[index],
//         paymentMode: orderData.paymentMode,
//         quantity: orderData.quantity[index],
//         OrderByUserId: orderData.OrderByUserId,
//         OrderToUserId: orderData.OrderToUserId,
//         serviceId: serviceId,
//         Paid: true,
//       };

//       return axios.post(endPoints.Orders.AddOrder, order, {
//         headers: {
//           Authorization: `Bearer ${loggedIn_User.token}`,
//         },
//       });
//     });

//     const orderResponses = await Promise.all(ordersPromises);

//     // Gather all order IDs
//     const orderIds = orderResponses.map((response) => response.data.data.id);

//     // Prepare order items array
//     const orderItems = orderData.serviceId.map((serviceId, index) => ({
//       ServiceId: serviceId,
//       OrderId: orderIds[index],
//       Quantity: orderData.quantity[index],
//     }));

//     // Insert all order items asynchronously
//     const orderItemPromises = orderItems.map((element) => {
//       return axios.post(endPoints.OrderItems.Add_OrderItems, element, {
//         headers: {
//           Authorization: `Bearer ${loggedIn_User.token}`,
//         },
//       });
//     });

//     const orderItemRes = await Promise.all(orderItemPromises);
//   } else {
//     try {
//       const order = {
//         contact: orderData.contact,
//         address: orderData.address,
//         amount: orderData.amount,
//         paymentMode: orderData.paymentMode,
//         OrderByUserId: orderData.OrderByUserId,
//         orderToUserId: orderData.orderToUserId,
//         Paid: true,
//       };

//       const orderRes = await axios.post(endPoints.Orders.AddOrder, order, {
//         headers: {
//           Authorization: `Bearer ${loggedIn_User.token}`,
//         },
//       });

//       const orderItem = {
//         ServiceId: orderData.serviceId,
//         OrderId: orderRes.data.data.id,
//         Quantity: 1,
//       };

//       const orderItemRes = await axios.post(
//         endPoints.OrderItems.Add_OrderItems,
//         orderItem,
//         {
//           headers: {
//             Authorization: `Bearer ${loggedIn_User.token}`,
//           },
//         }
//       );

//       return orderItemRes.data;
//     } catch (error) {
//       console.error("Error creating order:", error);
//       throw error;
//     }
//   }

//   return orderItemRes;
// };

export const AddOrder = async (orderData, loggedIn_User) => {
  orderData.OrderByUserId = loggedIn_User.LoggedIn_User_Id;

  let role = loggedIn_User.role;
  let orderItemRes;
  if (role !== "Admin") {
    // Iterate over each service ID and create an order for each
    const ordersPromises = orderData.serviceId.map(async (serviceId, index) => {
      const order = {
        contact: orderData.contact,
        address: orderData.address,
        amount: orderData.amount[index],
        paymentMode: orderData.paymentMode,
        quantity: orderData.quantity[index],
        OrderByUserId: orderData.OrderByUserId,
        OrderToUserId: orderData.OrderToUserId,
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

    orderItemRes = await Promise.all(orderItemPromises);
  } else {
    try {
      const order = {
        contact: orderData.contact,
        address: orderData.address,
        amount: orderData.amount,
        paymentMode: orderData.paymentMode,
        OrderByUserId: orderData.OrderByUserId,
        orderToUserId: orderData.orderToUserId,
        Paid: true,
      };

      const orderRes = await axios.post(endPoints.Orders.AddOrder, order, {
        headers: {
          Authorization: `Bearer ${loggedIn_User.token}`,
        },
      });

      const orderItem = {
        ServiceId: orderData.serviceId,
        OrderId: orderRes.data.data.id,
        Quantity: 1,
      };

      const orderItemRes = await axios.post(
        endPoints.OrderItems.Add_OrderItems,
        orderItem,
        {
          headers: {
            Authorization: `Bearer ${loggedIn_User.token}`,
          },
        }
      );

      return orderItemRes.data;
    } catch (error) {
      console.error("Error creating order:", error);
      throw error;
    }
  }

  return orderItemRes[0].data;
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

export const UpdatePaymentTransferStatus = async (id, loggedIn_User) => {
  const patchDocument = [
    {
      path: "/IsTransferPayment",
      op: "replace",
      value: true,
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

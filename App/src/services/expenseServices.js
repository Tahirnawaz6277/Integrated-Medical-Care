import axios from "axios";
import { endPoints } from "../config/endPoints";

export const getExpenses = async (loggedIn_User) => {
  const result = await axios.get(endPoints.Expense.GetExpenses, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });
  return result.data;
};

export const getExpense = async (id, loggedIn_User) => {
  const result = await axios.get(`${endPoints.Expense.GetExpenseById}/${id}`, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });

  return result.data;
};

export const addExpense = async (data, loggedIn_User) => {
  let result = await axios.post(endPoints.Expense.AddExpense, data, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });

  return result.data;
};

export const DeleteExpense = async (id, loggedIn_User) => {
  let result = await axios.delete(`${endPoints.Expense.DeleteExpense}/${id}`, {
    headers: {
      Authorization: `Bearer ${loggedIn_User.token}`,
    },
  });
  return result.data;
};

export const updateExpense = async (id, data, loggedIn_User) => {
  const result = await axios.put(
    `${endPoints.Expense.UpdateExpense}/${id}`,
    data,
    {
      headers: {
        Authorization: `Bearer ${loggedIn_User.token}`,
      },
    }
  );

  return result.data;
};

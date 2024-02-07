import { ROLES } from "./utils/Constants";

export const RouteNames = {
  default: {
    route: "/",
  },
  Auth: {
    Login: {
      route: "/login",
    },
    Register: {
      route: "/signup",
    },
  },
  Admin: {
    ManageAccounts: {
      route: "/accounts",
      role: [ROLES.ADMIN],
    },
  },
};

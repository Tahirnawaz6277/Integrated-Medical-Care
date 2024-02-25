export const RouteNames = {
  Default: {
    route: "/",
  },
  Auth: {
    Login: {
      route: "/login",
    },
    Register: {
      route: "/signup",
    },
    Forgot: {
      route: "/forgot",
    },
  },
  Admin: {
    Dashboard: {
      route: "/dashboard",
    },
    ManageAccount: {
      route: "/dashboard/accounts",
    },
    Orders: {
      route: "/dashboard/orders",
    },
    HealthCareProviders: {
      route: "/dashboard/healthcareproviders",
      AddNewHcp: {
        route: "/dashboard/AddNewHCPScreen",
      },
    },
    Feedbacks: {
      route: "/dashboard/feedbacks",
    },
    Services: {
      route: "/dashboard/services",
      AddNewService: {
        route: "/dashboard/AddNewServiceScreen",
      },
    },
    Promotions: {
      route: "/dashboard/promotions",
    },
    AddNewUser: {
      route: "/dashboard/signup",
    },
  },
};

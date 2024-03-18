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
      AddNewOrder: {
        route: "/dashboard/AddOrderScreen",
      },
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

    CustomerRecord: {
      route: "/dashboard/customerrecord",
    },
    Services: {
      route: "/dashboard/services",
      AddNewService: {
        route: "/dashboard/AddNewServiceScreen",
      },
    },
    Promotions: {
      route: "/dashboard/promotions",

      SendNewPromotion: {
        route: "/dashboard/AddNewPromotionScreen",
      },
    },
    AddNewUser: {
      route: "/dashboard/signup",
    },

    RevenueExpense: {
      route: "/dashboard/RevenueExpense",
    },
    Agreement: {
      route: "/dashboard/agreement",
    },
  },
};

import { ROLES } from "./utils/Constants";

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
      roles: [ROLES.ADMIN],

      CreatUser: {
        route: "/dashboard/createUser",
        roles: [ROLES.ADMIN],
      },
    },
    Orders: {
      route: "/dashboard/orders",
      roles: [ROLES.ADMIN, ROLES.PROVIDER],
      AddNewOrder: {
        route: "/dashboard/AddOrderScreen",
        roles: [ROLES.ADMIN, ROLES.PROVIDER, ROLES.CUSTOMER],
      },
    },
    HealthCareProviders: {
      route: "/dashboard/healthcareproviders",
      roles: [ROLES.ADMIN, ROLES.CUSTOMER, ROLES.PROVIDER],
      AddNewHcp: {
        route: "/dashboard/AddNewHCPScreen",
        roles: [ROLES.ADMIN, ROLES.PROVIDER],
      },
    },
    Feedbacks: {
      route: "/dashboard/feedbacks",
      roles: [ROLES.ADMIN],
    },

    CustomerRecord: {
      route: "/dashboard/customerrecord",
      roles: [ROLES.ADMIN],
    },
    Services: {
      route: "/dashboard/services",
      roles: [ROLES.ADMIN, ROLES.PROVIDER, ROLES.CUSTOMER],
      AddNewService: {
        route: "/dashboard/AddNewServiceScreen",
        roles: [ROLES.ADMIN, ROLES.PROVIDER],
      },
    },
    Promotions: {
      route: "/dashboard/promotions",
      roles: [ROLES.ADMIN],
      SendNewPromotion: {
        route: "/dashboard/AddNewPromotionScreen",
        roles: [ROLES.ADMIN],
      },
    },
    AddNewUser: {
      route: "/dashboard/signup",

      UpdateUser: {
        route: "/dashboard/UpdateUserScreen",
      },
    },

    Revenue: {
      route: "/dashboard/Revenue",
      roles: [ROLES.ADMIN],

      AddRevenue: {
        route: "/dashboard/AddRevenue",
        roles: [ROLES.ADMIN],
      },

      UpdateRevenue: {
        route: "/dashboard/UpdateRevenue",
        roles: [ROLES.ADMIN],
      },
    },

    Expense: {
      route: "/dashboard/expense",
      roles: [ROLES.ADMIN],

      AddExpense: {
        route: "/dashboard/CreateExpense",
        roles: [ROLES.ADMIN],
      },

      EditExpense: {
        route: "/dashboard/UpdateExpense",
        roles: [ROLES.ADMIN],
      },
    },

    Inventory: {
      route: "/dashboard/inventory",
      roles: [ROLES.ADMIN],

      AddInventory: {
        route: "/dashboard/AddInventory",
        roles: [ROLES.ADMIN],
      },

      UpdateInventory: {
        route: "/dashboard/UpdateInventory",
        roles: [ROLES.ADMIN],
      },
    },
    HcpRecord: {
      route: "/dashboard/ManageHcpRecord",
      roles: [ROLES.ADMIN],
    },
  },

  Customer: {
    Services: {
      route: "/dashboard/provider_services",
      roles: [ROLES.ADMIN, ROLES.CUSTOMER],
      ServiceDetail: {
        route: "/dashboard/service_details",
        roles: [ROLES.ADMIN],
      },
    },

    serviceProviders: {
      route: "/dashboard/serviceProviders",
      roles: [ROLES.ADMIN, ROLES.CUSTOMER],
    },

    Feedbacks: {
      route: "/dashboard/Customerfeedback",
      roles: [ROLES.ADMIN, ROLES.CUSTOMER],
    },

    Add_To_Cart: {
      route: "/dashboard/cart",
      roles: [ROLES.ADMIN, ROLES.CUSTOMER],
    },
    checkout: {
      route: "/dashboard/checkout",
      roles: [ROLES.ADMIN, ROLES.CUSTOMER],
    },

    customerFeedback: {
      route: "/dashboard/feedback",
      roles: [ROLES.ADMIN, ROLES.CUSTOMER],
    },
  },

  SProvider: {
    Services: {
      route: "/dashboard/pservices",
      roles: [ROLES.PROVIDER, ROLES.ADMIN],
      CreateNewService: {
        route: "/dashboard/createService",
        roles: [ROLES.PROVIDER],
      },
      UpdateService: {
        route: "/dashboard/updateService",
        roles: [ROLES.PROVIDER, ROLES.ADMIN],
      },
    },
    Order: {
      route: "/dashboard/order",
      roles: [ROLES.PROVIDER],
      // PlaceNewOrder: {
      //   route: "/dashboard/addOrder",
      //   roles: [ROLES.PROVIDER],
      // },
    },
    Payement: {
      route: "/dashboard/Payement",
      roles: [ROLES.PROVIDER],

      TransferPayement: {
        route: "/dashboard/transferPayement",
        roles: [ROLES.PROVIDER],
      },
    },
  },
};

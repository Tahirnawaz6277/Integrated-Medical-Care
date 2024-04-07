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
      roles: [ROLES.ADMIN, ROLES.CUSTOMER],
      AddNewService: {
        route: "/dashboard/AddNewServiceScreen",
        roles: [ROLES.ADMIN, ROLES.CUSTOMER],
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
    },

    RevenueExpense: {
      route: "/dashboard/RevenueExpense",
      roles: [ROLES.ADMIN],
    },
    Agreement: {
      route: "/dashboard/agreement",
      roles: [ROLES.ADMIN],
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
};

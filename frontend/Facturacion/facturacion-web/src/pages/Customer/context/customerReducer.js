import { ActionTypes } from "../../../utils/constants";

export function customerReducer(state, action) {
  const { type, payload } = action;

  switch (type) {
    case ActionTypes.LOADING_SWITCH:
      return {
        ...state,
        loading: payload,
      };
    case ActionTypes.FACTURACION_LOAD:
      return {
        ...state,
        customers: payload,
      };
    case ActionTypes.FACTURACION_CREATE:
      return {
        ...state,
        customers: [...state.customers, payload],
      };
    case ActionTypes.FACTURACION_DELETE:
      return {
        ...state,
        customers: state.customers.filter(
          (customer) => customer.id !== payload
        ),
      };
    case ActionTypes.FACTURACION_UPDATE:
      return {
        ...state,
        customers: state.customers.map((customer) =>
          customer.id === payload.id ? payload : customer
        ),
      };
    case ActionTypes.FACTURACION_FILTER:
      return {
        ...state,
        filteredCustomers: payload,
      };
    default:
      return state;
  }
}

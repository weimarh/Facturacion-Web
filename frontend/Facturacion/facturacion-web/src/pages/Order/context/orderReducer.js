import { ActionTypes } from "../../../utils/constants";

export function orderReducer(state, action) {
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
        orders: payload,
      };

    case ActionTypes.FACTURACION_CREATE:
      return {
        ...state,
        orders: [...state.orders, payload],
      };
    case ActionTypes.FACTURACION_DELETE:
      return {
        ...state,
        orders: state.orders.filter((order) => order.id != payload),
      };

    case ActionTypes.FACTURACION_UPDATE:
      return {
        ...state,
        orders: state.orders.map((order) =>
          order.id == payload.id ? payload : order
        ),
      };

    default:
      return state;
  }
}

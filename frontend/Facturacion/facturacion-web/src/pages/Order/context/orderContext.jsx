/* eslint-disable react/prop-types */
import { useMemo, useReducer } from "react";
import { createContext } from "react";
import { orderReducer } from "./orderReducer";
import ActionFactory from "./OrderActions";

export const OrderContext = createContext();
export const DispatchOrderContext = createContext();

const initialState = {
  orders: [],
  loading: false,
  error: null,
};

export function OrderProvider({ children }) {
  const [orders, dispatch] = useReducer(orderReducer, initialState);

  const actions = useMemo(() => ActionFactory(dispatch), [dispatch]);

  return (
    <OrderContext.Provider value={orders}>
      <DispatchOrderContext.Provider value={actions}>
        {children}
      </DispatchOrderContext.Provider>
    </OrderContext.Provider>
  );
}

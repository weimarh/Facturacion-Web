import { useMemo, useReducer } from "react";
import { createContext } from "react";
import ActionFactory from "./customerActions";
import { customerReducer } from "./customerReducer";

export const CustomerContext = createContext();
export const DispatchCustomerContext = createContext();

const initialState = {
  customers: [],
  loading: false,
  error: null,
};

// eslint-disable-next-line react/prop-types
export function CustomerProvider({ children }) {
  const [customers, dispatch] = useReducer(customerReducer, initialState);

  const actions = useMemo(() => ActionFactory(dispatch), [dispatch]);

  return (
    <CustomerContext.Provider value={customers}>
      <DispatchCustomerContext.Provider value={actions}>
        {children}
      </DispatchCustomerContext.Provider>
    </CustomerContext.Provider>
  );
}

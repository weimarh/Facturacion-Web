/* eslint-disable react/prop-types */
import { useMemo } from "react";
import { createContext, useReducer } from "react";
import { employeeReducer } from "./employeeReducer";
import { ActionFactory } from "../context/employeeActions";

export const EmployeeContext = createContext();
export const DispatchEmployeeContext = createContext();

const initialState = {
  employees: [],
  loading: false,
  error: null,
};

export function EmployeeProvider({ children }) {
  const [employees, dispatch] = useReducer(employeeReducer, initialState);

  const actions = useMemo(() => ActionFactory(dispatch), [dispatch]);

  return (
    <EmployeeContext.Provider value={employees}>
      <DispatchEmployeeContext.Provider value={actions}>
        {children}
      </DispatchEmployeeContext.Provider>
    </EmployeeContext.Provider>
  );
}

import { ActionTypes } from "../../../utils/constants";

export function employeeReducer(state, action) {
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
        employee: payload,
      };

    case ActionTypes.FACTURACION_CREATE:
      return {
        ...state,
        employees: [...state.employees, payload],
      };

    case ActionTypes.FACTURACION_UPDATE:
      return {
        ...state,
        employees: state.employees.map((employee) =>
          employee.id === payload.id ? payload : employee
        ),
      };

    case ActionTypes.FACTURACION_DELETE:
      return {
        ...state,
        employees: state.employees.filter(
          (employee) => employee.id !== payload
        ),
      };
  }
}

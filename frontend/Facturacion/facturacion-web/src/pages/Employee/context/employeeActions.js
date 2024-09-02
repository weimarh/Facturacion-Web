import { ActionTypes } from "../../../utils/constants";

function getEmployees(dispatch) {
  dispatch({ type: ActionTypes.LOADING_SWITCH, payload: true });

  fetch("")
    .then((res) => res.json())
    .then((data) => {
      dispatch({ type: ActionTypes.GET_EMPLOYEES, payload: data });
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    })
    .catch((err) => {
      console.log(err);
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    });
}

function createEmployee(dispatch, employee) {
  dispatch({ type: ActionTypes.LOADING_SWITCH, payload: true });

  fetch("", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(employee),
  })
    .then((res) => res.json())
    .then((data) => {
      dispatch({ type: ActionTypes.CREATE_EMPLOYEE, payload: data });
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    })
    .catch((err) => {
      console.log(err);
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    });
}

function updateEmployee(dispatch, employee) {
  dispatch({ type: ActionTypes.LOADING_SWITCH, payload: true });

  fetch("", {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(employee),
  })
    .then((res) => res.json())
    .then((data) => {
      dispatch({ type: ActionTypes.FACTURACION_UPDATE, payload: data });
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    })
    .catch((err) => {
      console.log(err);
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    });
}

function deleteEmployee(dispatch, id) {
  dispatch({ type: ActionTypes.LOADING_SWITCH, payload: true });

  fetch("", {
    method: "DELETE",
  })
    .then((res) => res.json())
    .then((data) => {
      console.log(data);
      dispatch({ type: ActionTypes.FACTURACION_DELETE, payload: id });
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    })
    .catch((err) => {
      console.log(err);
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    });
}

export default function ActionFactory(dispatch) {
  return {
    getEmployees: () => getEmployees(dispatch),
    createEmployee: (employee) => createEmployee(dispatch, employee),
    updateEmployee: (employee) => updateEmployee(dispatch, employee),
    deleteEmployee: (id) => deleteEmployee(dispatch, id),
  };
}

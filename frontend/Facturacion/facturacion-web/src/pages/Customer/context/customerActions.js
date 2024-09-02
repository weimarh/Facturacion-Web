import { ActionTypes } from "../../../utils/constants";

function getCustomers(dispatch) {
  dispatch({ type: ActionTypes.LOADING_SWITCH, payload: true });

  fetch("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")
    .then((res) => res.json())
    .then((data) => {
      dispatch({ type: ActionTypes.FACTURACION_LOAD, payload: data });
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    })
    .catch((err) => {
      console.log("Error fetching data", err);
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    });
}

function createCustomer(dispatch, customer) {
  dispatch({ type: ActionTypes.LOADING_SWITCH, payload: true });

  fetch("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(customer),
  })
    .then((data) => {
      console.log(data);
      dispatch({ type: ActionTypes.FACTURACION_CREATE, payload: customer });
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    })
    .catch((err) => {
      console.log("Error creating", err);
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    });
}

function updateCustomer(dispatch, customer) {
  dispatch({ type: ActionTypes.LOADING_SWITCH, payload: true });

  fetch(`XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/${customer.id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(customer),
  })
    .then((data) => {
      console.log(data);
      dispatch({ type: ActionTypes.FACTURACION_UPDATE, payload: customer });
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    })
    .catch((err) => {
      console.log("Error updating", err);
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    });
}

function deleteCustomer(dispatch, id) {
  dispatch({ type: ActionTypes.LOADING_SWITCH, payload: true });

  fetch(`XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX/${id}`, {
    method: "DELETE",
  })
    .then((data) => {
      console.log(data);
      dispatch({ type: ActionTypes.FACTURACION_DELETE, payload: id });
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    })
    .catch((err) => {
      console.log("Error deleting", err);
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    });
}

export default function ActionFactory(dispatch) {
  return {
    getCustomers: () => getCustomers(dispatch),
    createCustomer: (customer) => createCustomer(dispatch, customer),
    updatePerson: (customer) => updateCustomer(dispatch, customer),
    deletePerson: (id) => deleteCustomer(dispatch, id),
  };
}

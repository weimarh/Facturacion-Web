import { ActionTypes } from "../../../utils/constants";

function getOrders(dispatch) {
  dispatch({ type: ActionTypes.LOADING_SWITCH, payload: true });

  fetch("")
    .then((res) => res.json())
    .then((data) => {
      dispatch({ type: ActionTypes.FACTURACION_LOAD, payload: data });
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    })
    .catch((err) => {
      console.log("error fetching data", err);
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    });
}

function createOrder(dispatch, order) {
  dispatch({ type: ActionTypes.LOADING_SWITCH, payload: true });

  fetch("", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(order),
  })
    .then((data) => {
      console.log(data);
      dispatch({ type: ActionTypes.FACTURACION_CREATE, payload: order });
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    })
    .catch((err) => {
      console.log("error creating", err);
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    });
}

function deleteOrder(dispatch, id) {
  dispatch({ type: ActionTypes.LOADING_SWITCH, payload: true });

  fetch(``, {
    method: "DELETE",
  })
    .then((data) => {
      console.log(data);
      dispatch({ type: ActionTypes.FACTURACION_DELETE, payload: id });
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    })
    .catch((err) => {
      console.log("error deleting", err);
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    });
}

function updateOrder(dispatch, order) {
  dispatch({ type: ActionTypes.LOADING_SWITCH, payload: true });

  fetch(``, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(order),
  })
    .then((data) => {
      console.log(data);
      dispatch({ type: ActionTypes.FACTURACION_UPDATE, payload: order });
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    })
    .catch((err) => {
      console.log("error updating", err);
      dispatch({ type: ActionTypes.LOADING_SWITCH, payload: false });
    });
}

export default function ActionFactory(dispatch) {
  return {
    getOrders: () => getOrders(dispatch),
    createOrder: (order) => createOrder(dispatch, order),
    deleteOrder: (id) => deleteOrder(dispatch, id),
    updateOrder: (order) => updateOrder(dispatch, order),
  };
}

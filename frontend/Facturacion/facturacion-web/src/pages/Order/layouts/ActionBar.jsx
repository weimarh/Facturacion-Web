import { useContext, useState } from "react";
import ButtonMUI from "../../../components/button/ButtonMUI";
import { DispatchOrderContext } from "../context/orderContext";

export default function ActionBar() {
  const [product, setProduct] = useState("");
  const [quantity, setQuantity] = useState(0);

  const actions = useContext(DispatchOrderContext);

  const handleSubmit = (e) => {
    e.preventDefault();
    const order = {
      product,
      quantity,
    };

    actions.createOrder(order);
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        placeholder="Product"
        onChange={(e) => setProduct(e.target.value)}
      />
      <input
        placeholder="Quantity"
        onChange={(e) => setQuantity(e.target.value)}
      />
      <ButtonMUI>Agregar</ButtonMUI>
    </form>
  );
}

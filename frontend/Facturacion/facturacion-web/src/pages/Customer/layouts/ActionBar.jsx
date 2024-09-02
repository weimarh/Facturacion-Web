import { useContext, useState } from "react";
import ButtonMUI from "../../../components/button/ButtonMUI";
import { DispatchCustomerContext } from "../context/customerContext";

export default function ActionBar() {
  const [identifier, setIdentifier] = useState("");
  const [complement, setComplement] = useState("");
  const [fullName, setFullName] = useState("");
  const [email, setEmail] = useState("");

  const actions = useContext(DispatchCustomerContext);

  const handleSubmit = (e) => {
    e.preventDefault();
    const data = {
      identifier,
      complement,
      fullName,
      email,
    };

    actions.createCustomer(data);
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <input
          placeholder="Nit o carnet"
          onChange={(e) => setIdentifier(e.target.value)}
        />
        <input
          placeholder="Complemento"
          onChange={(e) => setComplement(e.target.value)}
        />
        <input
          placeholder="Nombre completo"
          onChange={(e) => setFullName(e.target.value)}
        />
        <input placeholder="Email" onChange={(e) => setEmail(e.target.value)} />
        <ButtonMUI>Agregar</ButtonMUI>
      </form>
    </div>
  );
}

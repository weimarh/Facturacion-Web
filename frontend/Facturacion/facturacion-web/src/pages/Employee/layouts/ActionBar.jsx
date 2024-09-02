import { useState } from "react";
import { useContext, useEffect } from "react";
import {
  CustomerContext,
  DispatchCustomerContext,
} from "../context/customerContext";
import ButtonMUI from "../../../components/button/ButtonMUI";

export default function ActionBar() {
  const [identifier, setIdentifier] = useState("");
  const [complement, setComplement] = useState("");
  const [fullName, setFullName] = useState("");
  const [rol, setRol] = useState("");

  const { customers } = useContext(CustomerContext);
  const actions = useContext(DispatchCustomerContext);

  useEffect(() => {
    actions.getEmployees();
  }, [actions]);

  const handleSubmit = (e) => {
    e.preventDefault();
    const employee = {
      Id: identifier,
      Complement: complement,
      FullName: fullName,
      Rol: rol,
    };
    actions.createCustomer(employee);
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        placeholder="Nit o CI"
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
      <select onChange={(e) => setRol(e.target.value)}>
        {customers.map((customer) => (
          <option key={customer.id} value={customer.id}>
            {customer.rol}
          </option>
        ))}
      </select>
      <ButtonMUI>Agregar</ButtonMUI>
    </form>
  );
}

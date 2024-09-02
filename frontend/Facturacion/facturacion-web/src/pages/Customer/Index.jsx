import { CustomerProvider } from "./context/customerContext";
import ActionBar from "./layouts/ActionBar";
import CustomerList from "./layouts/CustomerList";

export default function Index() {
  return (
    <CustomerProvider>
      <ActionBar />
      <CustomerList />
    </CustomerProvider>
  );
}

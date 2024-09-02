import { OrderProvider } from "./context/orderContext";
import ActionBar from "./layouts/ActionBar";
import OrderList from "./layouts/OrderList";

export default function Index() {
  return (
    <OrderProvider>
      <ActionBar />
      <OrderList />
    </OrderProvider>
  );
}

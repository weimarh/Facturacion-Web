import { EmployeeProvider } from "./context/employeeContext";
import ActionBar from "./layouts/ActionBar";
import EmployeeList from "./layouts/EmployeeList";

export default function Index() {
  return (
    <EmployeeProvider>
      <ActionBar />
      <EmployeeList />
    </EmployeeProvider>
  );
}

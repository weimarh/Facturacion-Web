import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import { useContext } from "react";
import {
  DispatchEmployeeContext,
  EmployeeContext,
} from "../context/employeeContext";
import ButtomMUI from "../../../components/button/ButtonMUI";

export default function BasicTable() {
  const { employees, loading } = useContext(EmployeeContext);
  const actions = useContext(DispatchEmployeeContext);

  const handleDelete = (id) => {
    actions.deleteEmployee(id);
  };

  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Nit o Carnet</TableCell>
            <TableCell align="right">Complemento</TableCell>
            <TableCell align="right">Full Name</TableCell>
            <TableCell align="right">Rol</TableCell>
            <TableCell align="right">Acciones</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {loading && <h1>Loading...</h1>}
          {employees.map((row) => (
            <TableRow
              key={row.name}
              sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.id}
              </TableCell>
              <TableCell align="right">{row.complement}</TableCell>
              <TableCell align="right">{row.fullName}</TableCell>
              <TableCell align="right">{row.Rol}</TableCell>
              <TableCell align="right">
                <ButtomMUI onClick={() => handleDelete(row.id)}>
                  Delete
                </ButtomMUI>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}

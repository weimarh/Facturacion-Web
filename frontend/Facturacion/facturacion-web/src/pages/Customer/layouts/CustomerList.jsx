import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import { useContext, useEffect } from "react";
import {
  CustomerContext,
  DispatchCustomerContext,
} from "../context/customerContext";
import ButtonMUI from "../../../components/button/ButtonMUI";

export default function BasicTable() {
  const { customers, loading } = useContext(CustomerContext);
  const actions = useContext(DispatchCustomerContext);

  useEffect(() => {
    actions.getCustomers();
  }, [actions]);

  const handleDelete = (id) => {
    actions.deleteCustomer(id);
  };

  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Nit o Carnet</TableCell>
            <TableCell align="right">Complemento</TableCell>
            <TableCell align="right">Nombre completo</TableCell>
            <TableCell align="right">Correo electronico</TableCell>
            <TableCell align="right">Acciones</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {loading && <p>Cargando...</p>}
          {customers.map((row) => (
            <TableRow
              key={row.id}
              sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.name}
              </TableCell>
              <TableCell align="right">{row.id}</TableCell>
              <TableCell align="right">{row.complement}</TableCell>
              <TableCell align="right">{row.fullName}</TableCell>
              <TableCell align="right">{row.email}</TableCell>
              <TableCell align="right">
                <ButtonMUI onClick={() => handleDelete(row.id)}>
                  Borrar
                </ButtonMUI>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}

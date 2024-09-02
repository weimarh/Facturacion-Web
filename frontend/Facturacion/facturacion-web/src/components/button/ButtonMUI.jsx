/* eslint-disable react/prop-types */
import Stack from "@mui/material/Stack";
import Button from "@mui/material/Button";

export default function BasicButtons({ children, onClick }) {
  return (
    <Stack spacing={2} direction="row">
      <Button variant="outlined" onClick={onClick}>
        {children}
      </Button>
    </Stack>
  );
}

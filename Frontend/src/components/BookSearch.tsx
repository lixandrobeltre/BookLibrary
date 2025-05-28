import { useState } from 'react';
import {
  Grid,
  TextField,
  Button,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
} from '@mui/material';

interface Props {
  readonly onSearch: (params: {
    author: string;
    isbn: string;
    ownershipStatus: number | "";
    page: number;
    pageSize: number;
  }) => void;
}

export default function BookSearch({ onSearch }: Props) {
  const [author, setAuthor] = useState('');
  const [isbn, setIsbn] = useState('');
  const [ownershipStatus, setOwnershipStatus] = useState<number | "">("");

  return (
    <Grid container spacing={2} sx={{ mb: 2 }}>
      <Grid item xs={4}>
        <TextField label="Author" fullWidth value={author} onChange={(e) => setAuthor(e.target.value)} />
      </Grid>
      <Grid item xs={4}>
        <TextField label="ISBN" fullWidth value={isbn} onChange={(e) => setIsbn(e.target.value)} />
      </Grid>
      <Grid item xs={4}>
        <FormControl fullWidth>
          <InputLabel id="ownership-status-label">Status</InputLabel>
          <Select
            labelId="ownership-status-label"
            value={ownershipStatus}
            label="Status"
            onChange={(e) => setOwnershipStatus(e.target.value === "" ? "" : Number(e.target.value))}
          >
            <MenuItem value="">None</MenuItem>
            <MenuItem value={1}>Own</MenuItem>
            <MenuItem value={2}>Love</MenuItem>
            <MenuItem value={3}>Want to Read</MenuItem>
          </Select>
        </FormControl>
      </Grid>
      <Grid item xs={12}>
        <Button
          variant="contained"
          onClick={() =>
            onSearch({ author, isbn, ownershipStatus, page: 1, pageSize: 10 })
          }
        >
          Search
        </Button>
      </Grid>
    </Grid>
  );
}

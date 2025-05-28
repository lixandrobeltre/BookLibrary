import {
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
} from '@mui/material';
import type  { Book } from '../models/Book';

interface Props {
  readonly books: readonly Book[];
}

export default function BookList({ books }: Props) {
  return (
    <Table>
      <TableHead>
        <TableRow>
          <TableCell>Title</TableCell>
          <TableCell>Author</TableCell>
          <TableCell>ISBN</TableCell>
          <TableCell>Type</TableCell>
          <TableCell>Category</TableCell>
          <TableCell>Available Copies</TableCell>
          <TableCell>Status</TableCell>
        </TableRow>
      </TableHead>
      <TableBody>
        {books.map((book, i) => (
          <TableRow key={i}>
            <TableCell>{book.title}</TableCell>
            <TableCell> {book.firstName} {book.lastName} </TableCell>
            <TableCell>{book.isbn}</TableCell>
            <TableCell>{book.genderType}</TableCell>
            <TableCell>{book.category}</TableCell>
            <TableCell>{book.availableCopies}</TableCell>
            <TableCell>{book.ownershipStatus}</TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
}


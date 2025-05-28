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

const getStatusLabel = (status: string): string => {
  switch (status) {
    case '1':
      return 'Own';
    case '2':
      return 'Love';
    case '3':
      return 'Want to Read';
    default:
      return 'None';
  }
};

export default function BookList({ books }: Props) {
  return (
    <Table>
      <TableHead>
        <TableRow>
          <TableCell>Title</TableCell>
          <TableCell>Author</TableCell>
          <TableCell>ISBN</TableCell>
          <TableCell>Status</TableCell>
        </TableRow>
      </TableHead>
      <TableBody>
        {books.map((book, i) => (
          <TableRow key={i}>
            <TableCell>{book.title}</TableCell>
            <TableCell>
              {book.firstName} {book.lastName}
            </TableCell>
            <TableCell>{book.isbn}</TableCell>
            <TableCell>{getStatusLabel(book.ownershipStatus)}</TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
}

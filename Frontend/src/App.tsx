import { useState } from 'react'
import './App.css'
import { Container, Typography } from '@mui/material';
import BookSearch from './components/BookSearch';
import BookList from './components/BookList';
import type { Book } from './models/Book';

function App() {
  const [books, setBooks] = useState<Book[]>([]);

   const handleSearch = async (params: any) => {
    const query = new URLSearchParams(params).toString();
    const res = await fetch(`https://localhost:7018/api/books/search?${query}`);
    const data = await res.json();
    setBooks(data.results);
  };

  return (
    <Container maxWidth="md" sx={{ mt: 4 }}>
      <Typography variant="h4" gutterBottom>
        Personal Book Library
      </Typography>
      <BookSearch onSearch={handleSearch} />
      <BookList books={books} />
    </Container>
  )
}

export default App

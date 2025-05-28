import { useState } from 'react'
// import reactLogo from './assets/react.svg'
// import viteLogo from '/vite.svg'
import './App.css'
import { Container, Typography } from '@mui/material';

function App() {
  const [count, setCount] = useState(0)

  return (
    <Container maxWidth="md" sx={{ mt: 4 }}>
      <Typography variant="h4" gutterBottom>
        Personal Book Library
      </Typography>
      {/* TODO: search */}
    </Container>
  )
}

export default App

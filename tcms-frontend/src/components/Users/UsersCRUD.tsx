import React, { useState } from 'react';
import { Button, TextField, Typography, Container, Grid, Paper } from '@mui/material';

interface User {
  id: number;
  name: string;
  email: string;
}

const UserCRUD: React.FC = () => {
  const [users, setUsers] = useState<User[]>([]);
  const [formData, setFormData] = useState<User>({ id: 0, name: '', email: '' });

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleAddUser = () => {
    // Increment the id for each new user
    const newUser: User = { ...formData, id: users.length + 1 };
    setUsers([...users, newUser]);
    setFormData({ id: 0, name: '', email: '' });
  };
  

  return (
    <Container>
      <Typography variant="h4" gutterBottom>
        User Creation/Update
      </Typography>
      <Paper elevation={3} style={{ padding: '16px' }}>
        <Grid container spacing={2}>
          <Grid item xs={12} sm={6}>
            <TextField
              label="Name"
              fullWidth
              variant="outlined"
              name="name"
              value={formData.name}
              onChange={handleInputChange}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              label="Email"
              fullWidth
              variant="outlined"
              name="email"
              value={formData.email}
              onChange={handleInputChange}
            />
          </Grid>
        </Grid>
        <Button
          variant="contained"
          color="primary"
          onClick={handleAddUser}
          style={{ marginTop: '16px' }}
        >
          Add User
        </Button>
      </Paper>
    </Container>
  );
};

export default UserCRUD;

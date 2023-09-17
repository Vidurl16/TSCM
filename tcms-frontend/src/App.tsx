import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { CssBaseline, AppBar, Toolbar, Typography, Container } from '@mui/material';
import Sidebar from './components/Sidebar.tsx'; 
import UserCRUD from './components/UserCRUD.tsx'; 
import UserList from './components/UserList.tsx'; 
import Login from './components/Login.tsx'; 

const App: React.FC = () => {
  const [authenticated, setAuthenticated] = React.useState(false);
  const [currentPage, setCurrentPage] = React.useState('');

  const handleLogin = () => {
    // If authentication is successful, set `authenticated`
    setAuthenticated(true);
  };

  const handleNavigate = (page: string) => {
    setCurrentPage(page);
  };

  return (
    <Router>
      <CssBaseline />
      <AppBar position="fixed">
        <Toolbar>
          <Typography variant="h6" noWrap>
            Your App Name
          </Typography>
        </Toolbar>
      </AppBar>
      {authenticated ? (
        <>
          <Sidebar onNavigate={handleNavigate} />
          <main>
            <Container>
              <Routes>
                <Route path="/userCRUD" element={<UserCRUD />} />
                <Route path="/userList" element={<UserList users={undefined} />} />
              </Routes>
            </Container>
          </main>
        </>
      ) : (
        <Login onLogin={handleLogin} />
      )}
    </Router>
  );
};

export default App;

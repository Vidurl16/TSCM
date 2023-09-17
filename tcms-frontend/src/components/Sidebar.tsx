// Sidebar.tsx
import React from 'react';
import { Drawer, List, ListItem, ListItemText } from '@mui/material';

interface SidebarProps {
  onNavigate: (page: string) => void;
}

const Sidebar: React.FC<SidebarProps> = ({ onNavigate }) => {
  const navigateTo = (page: string) => {
    onNavigate(page);
  };

  return (
    <Drawer variant="permanent">
      <List>
        <ListItem button onClick={() => navigateTo('userCRUD')}>
          <ListItemText primary="User CRUD" />
        </ListItem>
        <ListItem button onClick={() => navigateTo('userList')}>
          <ListItemText primary="User List" />
        </ListItem>
      </List>
    </Drawer>
  );
};

export default Sidebar;

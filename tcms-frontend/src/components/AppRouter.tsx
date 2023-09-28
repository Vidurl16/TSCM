import React from 'react';
import { BrowserRouter as Router, Switch, Route, Redirect } from 'react-router-dom';
import Login from './Login';
import MainPage from './MainPage';

const AppRouter: React.FC = () => {
  return (
    <Router>
      <Switch>
        <Route exact path="/" component={Login} />
        <Route exact path="/main" component={MainPage} />
        <Redirect to="/" />
      </Switch>
    </Router>
  );
};

export default AppRouter;

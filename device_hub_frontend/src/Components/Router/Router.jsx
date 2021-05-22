import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import {
  PATH_LOGIN,
  PATH_HOMEPAGE,
  PATH_CALLS,
  PATH_TRIGGERS,
  PATH_ABOUT,
} from '../../Areas/PagePaths';

import ProtectedRoute from './ProtectedRoute';

import Login from '../../Areas/Login/Login';
import Homepage from '../../Areas/Homepage/Homepage';
import Calls from '../../Areas/Calls/Calls';
import Triggers from '../../Areas/Triggers/Triggers';

import PageNotFound from '../../Areas/PageNotFound/PageNotFound';

import { RouterContainer } from './RouterStyles/RouterStyles';

import DrawerComponent from './DrawerComponent';

const App = () => (
  <div>
    <RouterContainer>
      <BrowserRouter>
        <DrawerComponent />
        <Switch>
          <Route exact path={PATH_LOGIN} component={Login} />

          <ProtectedRoute exact path={PATH_HOMEPAGE} component={Homepage} />
          <ProtectedRoute exact path={PATH_CALLS} component={Calls} />
          <ProtectedRoute exact path={PATH_TRIGGERS} component={Triggers} />
          {/* <ProtectedRoute exact path={PATH_ABOUT} component={About} /> */}
          <Route component={PageNotFound} />
        </Switch>
      </BrowserRouter>
    </RouterContainer>
  </div>
);

export default App;

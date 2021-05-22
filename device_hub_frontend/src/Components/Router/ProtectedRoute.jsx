import React from 'react';
import PropTypes from 'prop-types';
import { Route, Redirect } from 'react-router-dom';
import { isTokenValid } from '../../Resources/API';

const ProtectedRoute = ({ component: Component, path, exact }) => (
  <Route
    exact={exact}
    path={path}
    render={() => (isTokenValid() ? <Component /> : <Redirect to="/" />)}
  />
);
ProtectedRoute.defaultProps = {
  exact: true,
};

ProtectedRoute.propTypes = {
  component: PropTypes.func.isRequired,
  path: PropTypes.string.isRequired,
  exact: PropTypes.bool,
};

export default ProtectedRoute;

import React from 'react';
import { withRouter } from 'react-router-dom';
import LoginForm from '../../Components/Login/LoginForm';

const Login = () => (
  <div>
    <LoginForm />
  </div>
);

export default withRouter(Login);

import React, { useState } from 'react';
import { withRouter } from 'react-router-dom';
import PropTypes from 'prop-types';
import {
  InputAdornment, IconButton,
} from '@material-ui/core';
import { Visibility, VisibilityOff } from '@material-ui/icons';
import { LoginFormContainer, LoginFormField, LoginFormSubmitButton } from './LoginStyles/LoginStyles';
import { PATH_HOMEPAGE } from '../../Areas/PagePaths';

import API, { isTokenValid, setRefreshToken, setToken } from '../../Resources/API';

const LoginForm = (props) => {
  const { history } = props;
  const [values, setValues] = useState({
    username: '',
    email: '',
    password: '',
    showPassword: false,
  });

  const [errors, setErrors] = useState({
    error: '',
  });

  const submit = () => {
    const data = {
      username: values.username,
      password: values.password,
    };

    API.post('/api/login/', data)
      .then((response) => {
        setToken(response.data.access);
        setRefreshToken(response.data.refresh);
        history.push(PATH_HOMEPAGE);
      })
      .catch((error) => {
        if (error.response !== undefined) {
          console.log(error.response.data);
        }
        setErrors(error.response);
      });
  };

  const onEnterPress = (e) => {
    if (e.key === 'Enter') { submit(); }
  };

  const handleChange = (prop) => (event) => {
    setValues({
      ...values,
      [prop]: event.target.value,
    });
  };

  const handleClickShowPassword = () => {
    setValues({
      ...values,
      showPassword: !values.showPassword,
    });
  };

  const handleMouseDownPassword = (event) => {
    event.preventDefault();
  };

  function checkInputFields() {
    return values.username.length > 0 && values.password.length > 0;
  }

  return (
    <LoginFormContainer>
      <div>
        <LoginFormField
          name="username"
          id="username-input"
          label="Username"
          value={values.username}
          onChange={handleChange('username')}
          onKeyDown={onEnterPress}
          fullWidth
        />
      </div>
      <div>
        <LoginFormField
          name="password"
          id="password-input"
          label="Password"
          autoComplete="current-password"
          type={values.showPassword ? 'text' : 'password'}
          value={values.password}
          onChange={handleChange('password')}
          onKeyDown={onEnterPress}
          fullWidth
          InputProps={{
            endAdornment:
  <InputAdornment position="end">
    <IconButton
      aria-label="toggle password visibility"
      onClick={handleClickShowPassword}
      onMouseDown={handleMouseDownPassword}
    >
      {values.showPassword ? <Visibility /> : <VisibilityOff />}
    </IconButton>
  </InputAdornment>,
          }}
        />
      </div>
      <div style={{ display: 'flex' }}>
        <LoginFormSubmitButton
          variant="contained"
          disableElevation
          disabled={!checkInputFields}
          onClick={submit}
        >
          Login
        </LoginFormSubmitButton>
      </div>
    </LoginFormContainer>
  );
};

LoginForm.propTypes = {
  history: PropTypes.shape({
    push: PropTypes.func.isRequired,
  }).isRequired,
};

export default withRouter(LoginForm);

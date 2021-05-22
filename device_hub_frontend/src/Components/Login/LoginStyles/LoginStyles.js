import styled from 'styled-components';
import { Button, Container, TextField } from '@material-ui/core';

export const LoginFormContainer = styled(Container)`
  margin: 0;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);

  background-color: white;
  border-style: solid;
  border-width: 0.25em;
  border-color: #ccc;
  border-radius: 16px;
  transition: 3s;

  && {
      padding-top: 1em;
      padding-right: 2em;
      border-radius: 0.5em;
      width: 25%;
      min-width: 170px;
      max-width: 300px;
  }
`;

export const LoginFormField = styled(TextField)`
  && {
      margin: 0.5em;
  }
`;

export const LoginFormSubmitButton = styled(Button)`
  && {
      width: 50%;
      margin: 1.5em auto 1.5em auto;
  }
`;

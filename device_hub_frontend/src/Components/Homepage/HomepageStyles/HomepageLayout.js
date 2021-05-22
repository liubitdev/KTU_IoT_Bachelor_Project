import styled from 'styled-components';
import { Box, Button } from '@material-ui/core';

export const HomepageLayoutContainer = styled(Box)`
  display: flex;
  margin: 2em 2em 0em 2em;
  `;

export const ConnectedDevicesContainer = styled(Box)`
  width: 30%;
`;

export const RulesListContainer = styled(Box)`
  width: 70%;
  padding-left: 2em;
  display: flex;
  justify-content: space-between;
`;

export const RuleAddButton = styled(Button)`
  && {
      width: 20%;
      padding: 0;
      border: 1px solid black;
      text-transform: unset;
      font-size: 1.5em;
      font-weight: bold;
      font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', 'Roboto', 'Oxygen', 'Ubuntu', 'Cantarell', 'Fira Sans', 'Droid Sans', 'Helvetica Neue', sans-serif;
      -webkit-font-smoothing: antialiased;
    }
`;

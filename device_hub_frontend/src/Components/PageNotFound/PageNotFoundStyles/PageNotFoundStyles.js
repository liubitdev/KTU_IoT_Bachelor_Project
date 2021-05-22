import styled, { keyframes } from 'styled-components';
import { Box, Button } from '@material-ui/core';

export const PageNotFoundContainer = styled(Box)`
  margin: 0;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);

  transition: 3s;

  && {
      border-radius: 0.5em;
      text-align: center;
  }
`;

const rotate = keyframes`
  0% {  
    transform: translateY(0);
    text-shadow: 
        0 0 0 #0c2ffb, 
        0 0 0 #2cfcfd, 
        0 0 0 #fb203b, 
        0 0 0 #fefc4b;
  }

  20% {  
    transform: translateY(-0.25em);
    text-shadow: 
        0 0.065em 0 #0c2ffb, 
        0 0.125em 0 #2cfcfd, 
        0 -0.065em 0 #fb203b, 
        0 -0.125em 0 #fefc4b;
  }

  40% {  
    transform: translateY(0.125em);
    text-shadow: 
        0 -0.03125em 0 #0c2ffb, 
        0 -0.065em 0 #2cfcfd, 
        0 0.03125em 0 #fb203b, 
        0 0.065em 0 #fefc4b;
  }

  60% {
    transform: translateY(-0.0625em);
    text-shadow: 
        0 0.0155em 0 #0c2ffb, 
        0 0.03125em 0 #2cfcfd, 
        0 -0.0155em 0 #fb203b, 
        0 -0.03125em 0 #fefc4b;
  }

  80% {  
    transform: translateY(0);
    text-shadow: 
        0 0 0 #0c2ffb, 
        0 0 0 #2cfcfd, 
        0 0 0 #fb203b, 
        0 0 0 #fefc4b;
  }
`;

export const PageNotFoundHeaderContainer = styled(Box)`
  display: flex;
  justify-content: center;
`;

export const PageNotFoundHeaderLetter = styled.h1`
  font-size: 3em;
  margin: 0;

  animation: ${rotate} 1s linear infinite;
  animation-delay: ${(props) => props.delay}s;
`;

export const PageNotFoundBody = styled.p`
  font-size: 2em;
  margin: 0;
`;

export const PageNotFoundButton = styled(Button)`
  && {
    margin-top: 1em;
    border: 1px solid #ccc;
    font-size: 1.25em;
    text-transform: unset;
  }
`;

import React from 'react';
import { withRouter } from 'react-router-dom';
import PropTypes from 'prop-types';

import {
  PageNotFoundContainer,
  PageNotFoundHeaderContainer,
  PageNotFoundHeaderLetter,
  PageNotFoundBody,
  PageNotFoundButton,
} from './PageNotFoundStyles/PageNotFoundStyles';

import { PATH_HOMEPAGE } from '../../Areas/PagePaths';

const PageNotFound = (props) => {
  const { history } = props;

  const buttonClickHandler = () => {
    history.push(PATH_HOMEPAGE);
  };

  return (
    <PageNotFoundContainer>
      <PageNotFoundHeaderContainer>
        <PageNotFoundHeaderLetter delay="0">
          4
        </PageNotFoundHeaderLetter>
        <PageNotFoundHeaderLetter delay="0.25">
          0
        </PageNotFoundHeaderLetter>
        <PageNotFoundHeaderLetter delay="0.5">
          4
        </PageNotFoundHeaderLetter>
      </PageNotFoundHeaderContainer>
      <PageNotFoundBody>
        Page not found
      </PageNotFoundBody>
      <PageNotFoundBody>
        Your page is in another castle!
      </PageNotFoundBody>
      <PageNotFoundButton onClick={buttonClickHandler}>
        {'>Take me home!<'}
      </PageNotFoundButton>
    </PageNotFoundContainer>
  );
};

PageNotFound.propTypes = {
  history: PropTypes.shape({
    push: PropTypes.func.isRequired,
  }).isRequired,
};

export default withRouter(PageNotFound);

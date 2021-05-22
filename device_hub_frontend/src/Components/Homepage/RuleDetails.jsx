import React from 'react';
import PropTypes from 'prop-types';

import { RuleContainer } from './HomepageStyles/RuleListStyles';

const RuleDetails = (props) => {
  const { id, name, body } = props;

  return (
    <RuleContainer>
      {`ID: ${id}`}
      <br />
      {`Rule name: ${name}`}
      <br />
      {`Rule: ${body}`}
    </RuleContainer>
  );
};

RuleDetails.propTypes = {
  id: PropTypes.number.isRequired,
  name: PropTypes.string.isRequired,
  body: PropTypes.string.isRequired,
};

export default RuleDetails;

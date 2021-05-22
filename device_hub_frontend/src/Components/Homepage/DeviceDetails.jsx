import React from 'react';
import PropTypes from 'prop-types';

import { DeviceDetailsContainer, DeviceTextBold } from './HomepageStyles/DeviceDetailsStyles';

const DeviceDetails = (props) => {
  const { id, name } = props;

  return (
    <DeviceDetailsContainer>
      <DeviceTextBold>ID: </DeviceTextBold>
      {id}
      <br />
      <DeviceTextBold>Device name: </DeviceTextBold>
      {name}
      <br />
      <DeviceTextBold>Device functions: </DeviceTextBold>
      Function 1
      Function 1
    </DeviceDetailsContainer>
  );
};

DeviceDetails.propTypes = {
  id: PropTypes.number.isRequired,
  name: PropTypes.string.isRequired,
};

export default DeviceDetails;

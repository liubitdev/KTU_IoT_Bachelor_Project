import React from 'react';

import { Divider } from '@material-ui/core';

import ConnectedDevices from './ConnectedDevices';
import RuleList from './RuleList';

import {
  HomepageLayoutContainer, ConnectedDevicesContainer, RulesListContainer, RuleAddButton,
} from './HomepageStyles/HomepageLayout';
import { ConnectedDevicesHeader } from './HomepageStyles/ConnectedDevicesStyles';
import { RuleListHeader } from './HomepageStyles/RuleListStyles';

import API from '../../Resources/API';

const HomepageLayout = () => {
  const handleNewBehaviorButtonClick = () => {
    const data = {

    };

    API.post('/api/behavior/', data)
      .then((response) => {
        console.log(response);
      }).catch((error) => {
        console.log(error);
      });
  };

  return (
    <>
      <HomepageLayoutContainer>
        <ConnectedDevicesContainer>
          <ConnectedDevicesHeader>Connected Devices</ConnectedDevicesHeader>
        </ConnectedDevicesContainer>
        <RulesListContainer>
          <RuleListHeader>Behaviors</RuleListHeader>
          <RuleAddButton onClick={handleNewBehaviorButtonClick}>Add behavior</RuleAddButton>
        </RulesListContainer>
      </HomepageLayoutContainer>
      <HomepageLayoutContainer>
        <ConnectedDevicesContainer>
          <ConnectedDevices />
        </ConnectedDevicesContainer>
        <Divider orientation="vertical" flexItem />
        <RulesListContainer>
          <RuleList />
        </RulesListContainer>
      </HomepageLayoutContainer>
    </>
  );
};

export default HomepageLayout;

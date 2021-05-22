import React from 'react';

import DeviceDetails from './DeviceDetails';

import { ConnectedDevicesHeader } from './HomepageStyles/ConnectedDevicesStyles';

const ConnectedDevices = () => {
  const devicesPlaceholder = [
    'android1',
    'android2',
    'android3',
    'android4',
    'android5',
  ];

  return (
    <div>
      { devicesPlaceholder.map((device, index) => (
        <div key={device}>
          <DeviceDetails id={index} name={device} />
        </div>
      )) }

    </div>
  );
};

export default ConnectedDevices;

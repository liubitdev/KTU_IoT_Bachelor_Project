import React from 'react';
import { Divider } from '@material-ui/core';

import RuleDetails from './RuleDetails';

import { RuleContainer } from './HomepageStyles/RuleListStyles';

const RuleList = () => {
  const rules = ['Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam pellentesque lacus ligula, et condimentum massa fringilla quis. Cras ut blandit sapien, et finibus urna. Praesent sit amet dolor porttitor, feugiat sapien ut, aliquam elit. Quisque hendrerit metus ligula, a ornare nisi pulvinar at. Proin ac dui ac urna sodales vulputate ut laoreet diam. Integer et imperdiet turpis, et gravida velit. Etiam tristique tortor ut porta viverra. Mauris ullamcorper ligula mauris. Aliquam ac augue eget ex scelerisque maximus at vitae dolor. Praesent orci velit, tristique non feugiat quis, suscipit at felis. Maecenas nulla arcu, pharetra eget risus vel, condimentum elementum ligula. Pellentesque imperdiet tristique erat ac mattis. In ex urna, ultricies sed mollis vel, consequat sit amet turpis. Curabitur et nisl diam.',
    'Pellentesque ac laoreet diam, ut euismod ligula. Quisque consequat at nulla a scelerisque. Integer interdum interdum orci, sed convallis sem scelerisque ornare. Suspendisse ultricies rhoncus commodo. Pellentesque facilisis lectus nibh, ac lobortis lorem fringilla vitae. Cras quis massa sed odio luctus luctus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Cras interdum vel quam a commodo. Sed lacus dolor, ultrices ut rhoncus id, faucibus sit amet tellus. Aliquam posuere leo et feugiat pulvinar. Aenean ut arcu egestas, feugiat libero rhoncus, accumsan diam. Pellentesque id turpis maximus, pretium ligula eget, vulputate erat. Vestibulum efficitur eleifend leo, et volutpat diam malesuada sollicitudin.',
    'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam pellentesque lacus ligula, et condimentum massa fringilla quis. Cras ut blandit sapien, et finibus urna. Praesent sit amet dolor porttitor, feugiat sapien ut, aliquam elit. Quisque hendrerit metus ligula, a ornare nisi pulvinar at. Proin ac dui ac urna sodales vulputate ut laoreet diam. Integer et imperdiet turpis, et gravida velit. Etiam tristique tortor ut porta viverra. Mauris ullamcorper ligula mauris. Aliquam ac augue eget ex scelerisque maximus at vitae dolor. Praesent orci velit, tristique non feugiat quis, suscipit at felis. Maecenas nulla arcu, pharetra eget risus vel, condimentum elementum ligula. Pellentesque imperdiet tristique erat ac mattis. In ex urna, ultricies sed mollis vel, consequat sit amet turpis. Curabitur et nisl diam.'];

  return (
    <div>
      {rules.map((rule, index) => (
        <div>
          <RuleDetails id={index} name={`rule-${index}`} body={rule} />
          <Divider />
        </div>
      ))}
    </div>
  );
};

export default RuleList;

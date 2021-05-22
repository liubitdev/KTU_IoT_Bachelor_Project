import React, { useState } from 'react';
import { withRouter } from 'react-router-dom';
import PropTypes from 'prop-types';

import {
  ClickAwayListener, Drawer, List, Divider, IconButton, ListItem, ListItemIcon, ListItemText,
} from '@material-ui/core';

import {
  Menu, ChevronLeft, ChevronRight,
  AllOut, CallMissed, Receipt, Info, MeetingRoom,
} from '@material-ui/icons';

import {
  PATH_LOGIN, PATH_HOMEPAGE, PATH_CALLS, PATH_TRIGGERS, PATH_ABOUT,
} from '../../Areas/PagePaths';

import { removeToken, isTokenValid } from '../../Resources/API';

const DrawerComponent = (props) => {
  const { history } = props;
  const [open, setOpen] = useState(false);

  const onClickHandler = (name) => {
    history.push(name);
  };

  const handleDrawerOpen = () => {
    setOpen(true);
  };

  const handleDrawerClose = () => {
    setOpen(false);
  };

  const logout = () => {
    setOpen(false);
    removeToken();
    history.push(PATH_LOGIN);
  };

  return (
    <>
      {isTokenValid() ? (
        <ClickAwayListener onClickAway={handleDrawerClose}>
          <div>
            <div style={{
              position: 'fixed',
              top: '0',
              display: open ? 'none' : 'block',
            }}
            >
              <IconButton
                color="inherit"
                aria-label="open drawer"
                onClick={handleDrawerOpen}
              >
                <Menu />
              </IconButton>
            </div>

            <div style={{ position: 'fixed' }}>
              <Drawer
                variant="persistent"
                anchor="left"
                open={open}
                classes={{
                }}
              >
                <div>
                  <IconButton onClick={handleDrawerClose}>
                    {open ? <ChevronLeft /> : <ChevronRight />}
                  </IconButton>
                </div>
                <Divider />
                <List>
                  <ListItem button key="Behaviors" onClick={() => onClickHandler(PATH_HOMEPAGE)}>
                    <ListItemIcon><Receipt /></ListItemIcon>
                    <ListItemText primary="Behaviors" />
                  </ListItem>
                  <ListItem button key="Calls" onClick={() => onClickHandler(PATH_CALLS)}>
                    <ListItemIcon><CallMissed /></ListItemIcon>
                    <ListItemText primary="Calls" />
                  </ListItem>
                  <ListItem button key="Triggers" onClick={() => onClickHandler(PATH_TRIGGERS)}>
                    <ListItemIcon><AllOut /></ListItemIcon>
                    <ListItemText primary="Triggers" />
                  </ListItem>
                </List>
                <Divider />
                <List>
                  <ListItem button key="About" onClick={() => onClickHandler(PATH_ABOUT)}>
                    <ListItemIcon><Info /></ListItemIcon>
                    <ListItemText primary="About" />
                  </ListItem>
                  <ListItem button key="Logout" onClick={logout}>
                    <ListItemIcon><MeetingRoom /></ListItemIcon>
                    <ListItemText primary="Logout" />
                  </ListItem>
                </List>
              </Drawer>
            </div>
          </div>
        </ClickAwayListener>
      ) : null}
    </>
  );
};

DrawerComponent.propTypes = {
  history: PropTypes.shape({
    push: PropTypes.func.isRequired,
  }).isRequired,
};

export default withRouter(DrawerComponent);

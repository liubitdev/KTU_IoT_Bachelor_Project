using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Device_Emulator_App.Models.Enums;

namespace Device_Emulator_App.ViewModels
{
    class BaseDevice : BaseViewModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        private EDeviceNetworkState state;
        public EDeviceNetworkState State
        {
            get { return state; }
            set { SetProperty(ref state, value); }
        }

    }
}

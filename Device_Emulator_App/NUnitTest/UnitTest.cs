using System;
using System.Threading;
using System.Threading.Tasks;
using Device_Emulator_App.Models;
using NUnit.Framework;

namespace NUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        //[Test]
        //public void CreateDeviceTest()
        //{
        //    DeviceModel.Configure("testDevice",
        //        Device_Emulator_App.Models.Enums.EDeviceType.CONTROLLER,
        //        Device_Emulator_App.Models.Enums.EDeviceGroup.BUTTON);

        //    Assert.AreEqual("testDevice", DeviceModel.Name);
        //    Assert.AreEqual(Device_Emulator_App.Models.Enums.EDeviceNetworkState.OFFLINE, DeviceModel.NetworkState);
        //    Assert.AreEqual(Device_Emulator_App.Models.Enums.EDeviceType.CONTROLLER, DeviceModel.Type);
        //    Assert.AreEqual(Device_Emulator_App.Models.Enums.EDeviceGroup.BUTTON, DeviceModel.Group);
        //    DeviceModel.Disconnect();
        //    Assert.AreEqual(Device_Emulator_App.Models.Enums.EDeviceNetworkState.OFFLINE, DeviceModel.NetworkState);
        //    Assert.Pass();
        //}

        //[Test]
        //public async Task ReceiveMessageFromServerTest()
        //{
        //    bool asserted = false;

        //    DeviceModel.Configure(
        //        new Uri("ws://127.0.0.1:8000/"),
        //        "testDevice",
        //        Device_Emulator_App.Models.Enums.EDeviceType.CONTROLLER,
        //        Device_Emulator_App.Models.Enums.EDeviceGroup.BUTTON);
        //    await DeviceModel.Create();

        //    DeviceModel.StatesChanged += (sender, data) =>
        //    {
        //        Assert.AreEqual("testDevice", DeviceModel.Name);
        //        Assert.AreEqual(Device_Emulator_App.Models.Enums.EDeviceNetworkState.ONLINE, DeviceModel.NetworkState);
        //        Assert.AreEqual(Device_Emulator_App.Models.Enums.EDeviceType.CONTROLLER, DeviceModel.Type);
        //        Assert.AreEqual(Device_Emulator_App.Models.Enums.EDeviceGroup.BUTTON, DeviceModel.Group);
        //        asserted = true;
        //    };

        //    for (int i = 0; i < 10; i++)
        //    {
        //        if (asserted) break;
        //        // Wait for the message from server
        //        Thread.Sleep(1000);
        //    }

        //    DeviceModel.Disconnect();
        //    Assert.AreEqual(Device_Emulator_App.Models.Enums.EDeviceNetworkState.OFFLINE, DeviceModel.NetworkState);

        //    if (asserted) Assert.Pass("Message received from server");
        //    else Assert.Fail("No message received from server");
        //}


        //[Test]
        //public async Task SendMessageToServerTest()
        //{
        //    bool asserted = false;

        //    DeviceModel.Configure(
        //        new Uri("ws://127.0.0.1:8000/"),
        //        "testDevice",
        //        Device_Emulator_App.Models.Enums.EDeviceType.CONTROLLER,
        //        Device_Emulator_App.Models.Enums.EDeviceGroup.BUTTON);
        //    await DeviceModel.Create();

        //    DeviceModel.Update(this, "{\"message\":\"Hello World!\"}");

        //    DeviceModel.StatesChanged += (sender, data) =>
        //    {
        //        if(data != null)
        //            asserted = true;
        //    };

        //    for (int i = 0; i < 10; i++)
        //    {
        //        if (asserted) break;
        //        // Wait for the message from server
        //        Thread.Sleep(1000);
        //    }

        //    DeviceModel.Disconnect();
        //    Assert.AreEqual(Device_Emulator_App.Models.Enums.EDeviceNetworkState.OFFLINE, DeviceModel.NetworkState);

        //    if (asserted) Assert.Pass("Message received from server");
        //    else Assert.Fail("No message received from server");
        //}

    }
}
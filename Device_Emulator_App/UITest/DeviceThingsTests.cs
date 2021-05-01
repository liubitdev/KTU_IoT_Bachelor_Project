using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class DeviceThingsTests
    {
        IApp app;
        Platform platform;

        public DeviceThingsTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp.Android
            .ApkFile(@"C:\Users\Admin\Desktop\KTU_IoT_Bachelor_Project\Device_Emulator_App\Device_Emulator_App.Android\bin\Debug\com.companyname.device_emulator_app.apk")
            .PreferIdeSettings()
            .EnableLocalScreenshots()
            .StartApp();
            //app.Repl();
        }

        [Test]
        public void CreateDoorThingTest()
        {
            //app.Repl();
            app.WaitForElement(c => c.Marked("ThingsPicker"));
            app.Tap(c => c.Marked("ThingsPicker"));
            app.Tap(c => c.Text("Door"));
            app.WaitForElement(c => c.Text("Connect"));
            app.Tap(c => c.Text("Connect"));

            app.WaitForElement(c => c.Text("Door is Closed and Locked!"));
            app.Tap(c => c.Text("Unlock"));
            app.WaitForElement(c => c.Text("Door is Closed and Unlocked!"));
            app.Tap(c => c.Text("Open"));
            app.WaitForElement(c => c.Text("Door is open!"));
            app.Tap(c => c.Text("Close"));
            app.WaitForElement(c => c.Text("Door is Closed and Unlocked!"));
            app.Tap(c => c.Text("Lock"));
            app.WaitForElement(c => c.Text("Door is Closed and Locked!"));

            app.Back();
            app.WaitForElement(c => c.Text("Do you really want to exit?"));
            app.Tap(c => c.Text("Yes"));

            AppResult[] appResults = app.WaitForElement(c => c.Marked("ThingsPicker"));
            Assert.IsTrue(appResults.Any());
        }

        [Test]
        public void CreateLightThingTest()
        {
            //app.Repl();
            app.WaitForElement(c => c.Marked("ThingsPicker"));
            app.Tap(c => c.Marked("ThingsPicker"));
            app.Tap(c => c.Text("Light"));
            app.WaitForElement(c => c.Text("Connect"));
            app.Tap(c => c.Text("Connect"));

            app.WaitForElement(c => c.Text("Light is turned OFF!"));
            app.Tap(c => c.Text("On"));
            app.WaitForElement(c => c.Text("Light is turned ON!"));
            app.Tap(c => c.Text("Off"));
            app.WaitForElement(c => c.Text("Light is turned OFF!"));

            app.Back();
            app.WaitForElement(c => c.Text("Do you really want to exit?"));
            app.Tap(c => c.Text("Yes"));

            AppResult[] appResults = app.WaitForElement(c => c.Marked("ThingsPicker"));
            Assert.IsTrue(appResults.Any());
        }

        [Test]
        public void CreateMessageReceiverThingTest()
        {
            //app.Repl();
            app.WaitForElement(c => c.Marked("ThingsPicker"));
            app.Tap(c => c.Marked("ThingsPicker"));
            app.Tap(c => c.Text("Message Receiver"));
            app.WaitForElement(c => c.Text("Connect"));
            app.Tap(c => c.Text("Connect"));

            app.WaitForElement(c => c.Text("Clear Log"));
            app.WaitForElement(c => c.Marked("MessageListView").Child());
            app.Tap(c => c.Text("Clear Log"));
            bool result = app.Query(c => c.Marked("MessageListView").Child()).Any();
            Assert.IsTrue(!result);

            app.Back();
            app.WaitForElement(c => c.Text("Do you really want to exit?"));
            app.Tap(c => c.Text("Yes"));

            AppResult[] appResults = app.WaitForElement(c => c.Marked("ThingsPicker"));
            Assert.IsTrue(appResults.Any());
        }

        [Test]
        public void CreateTvThingTest()
        {
            //app.Repl();
            app.WaitForElement(c => c.Marked("ThingsPicker"));
            app.Tap(c => c.Marked("ThingsPicker"));
            app.Tap(c => c.Text("TV"));
            app.WaitForElement(c => c.Text("Connect"));
            app.Tap(c => c.Text("Connect"));

            app.WaitForElement(c => c.Text("TV is turned OFF!"));
            app.Tap(c => c.Text("ON"));
            app.WaitForElement(c => c.Text("TV is turned ON!"));
            app.Tap(c => c.Text("Switch Channel"));
            app.Tap(c => c.Text("OFF"));
            app.WaitForElement(c => c.Text("TV is turned OFF!"));

            app.Back();
            app.WaitForElement(c => c.Text("Do you really want to exit?"));
            app.Tap(c => c.Text("Yes"));

            AppResult[] appResults = app.WaitForElement(c => c.Marked("ThingsPicker"));
            Assert.IsTrue(appResults.Any());
        }

        [Test]
        public void CreateWindowThingTest()
        {
            //app.Repl();
            app.WaitForElement(c => c.Marked("ThingsPicker"));
            app.Tap(c => c.Marked("ThingsPicker"));
            app.Tap(c => c.Text("Window"));
            app.WaitForElement(c => c.Text("Connect"));
            app.Tap(c => c.Text("Connect"));

            app.WaitForElement(c => c.Text("Window is Closed!"));
            app.Tap(c => c.Text("Open"));
            app.WaitForElement(c => c.Text("Window is Open!"));
            app.Tap(c => c.Text("Close"));
            app.WaitForElement(c => c.Text("Window is Closed!"));
            app.Tap(c => c.Text("Break"));
            app.WaitForElement(c => c.Text("Window is Broken!"));

            app.Back();
            app.WaitForElement(c => c.Text("Do you really want to exit?"));
            app.Tap(c => c.Text("Yes"));

            AppResult[] appResults = app.WaitForElement(c => c.Marked("ThingsPicker"));
            Assert.IsTrue(appResults.Any());
        }

    }
}

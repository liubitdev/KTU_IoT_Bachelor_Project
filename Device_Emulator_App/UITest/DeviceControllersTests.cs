using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    class DeviceControllersTests
    {
        IApp app;
        Platform platform;

        public DeviceControllersTests(Platform platform)
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
        public void CreateButtonControllerTest()
        {
            //app.Repl();
            app.Tap(c => c.Text("Controllers"));
            app.WaitForElement(c => c.Marked("ControllersPicker"));
            app.Tap(c => c.Marked("ControllersPicker"));
            app.Tap(c => c.Text("Button"));
            app.WaitForElement(c => c.Text("Connect"));
            app.Tap(c => c.Text("Connect"));

            app.WaitForElement(c => c.Text("Activate"));
            app.Tap(c => c.Text("Activate"));

            app.Back();
            app.WaitForElement(c => c.Text("Do you really want to exit?"));
            app.Tap(c => c.Text("Yes"));

            AppResult[] appResults = app.WaitForElement(c => c.Marked("ControllersPicker"));
            Assert.IsTrue(appResults.Any());
        }

        [Test]
        public void CreateFingerScannerControllerTest()
        {
            //app.Repl();
            app.Tap(c => c.Text("Controllers"));
            app.WaitForElement(c => c.Marked("ControllersPicker"));
            app.Tap(c => c.Marked("ControllersPicker"));
            app.Tap(c => c.Text("Finger Scanner"));
            app.WaitForElement(c => c.Text("Connect"));
            app.Tap(c => c.Text("Connect"));

            app.WaitForElement(c => c.Text("Authorize"));

            app.Back();
            app.WaitForElement(c => c.Text("Do you really want to exit?"));
            app.Tap(c => c.Text("Yes"));

            AppResult[] appResults = app.WaitForElement(c => c.Marked("ControllersPicker"));
            Assert.IsTrue(appResults.Any());
        }

        [Test]
        public void CreateMailboxControllerTest()
        {
            //app.Repl();
            app.Tap(c => c.Text("Controllers"));
            app.WaitForElement(c => c.Marked("ControllersPicker"));
            app.Tap(c => c.Marked("ControllersPicker"));
            app.Tap(c => c.Text("Mailbox"));
            app.WaitForElement(c => c.Text("Connect"));
            app.Tap(c => c.Text("Connect"));

            app.WaitForElement(c => c.Text("Mailbox is Empty!"));
            app.Tap(c => c.Text("Fill with Parcel"));
            app.WaitForElement(c => c.Text("Mailbox is Filled!"));

            app.Back();
            app.WaitForElement(c => c.Text("Do you really want to exit?"));
            app.Tap(c => c.Text("Yes"));

            AppResult[] appResults = app.WaitForElement(c => c.Marked("ControllersPicker"));
            Assert.IsTrue(appResults.Any());
        }

        [Test]
        public void CreatePinCodeControllerTest()
        {
            app.Repl();
            app.Tap(c => c.Text("Controllers"));
            app.WaitForElement(c => c.Marked("ControllersPicker"));
            app.Tap(c => c.Marked("ControllersPicker"));
            app.Tap(c => c.Text("Pin Code"));
            app.WaitForElement(c => c.Text("Connect"));
            app.Tap(c => c.Text("Connect"));

            app.WaitForElement(c => c.Text("Del"));
            app.Tap(c => c.Text("1"));
            app.Tap(c => c.Text("9"));
            app.Tap(c => c.Text("4"));
            app.Tap(c => c.Text("7"));
            app.WaitForElement(c => c.Text("1947"));
            app.Tap(c => c.Text("Del"));
            app.Tap(c => c.Text("Del"));
            app.Tap(c => c.Text("Del"));
            app.Tap(c => c.Text("Del"));
            app.Tap(c => c.Text("6"));
            app.Tap(c => c.Text("2"));
            app.Tap(c => c.Text("8"));
            app.Tap(c => c.Text("0"));
            app.WaitForElement(c => c.Text("6280"));

            app.Tap(c => c.Text("Submit"));

            app.Back();
            app.WaitForElement(c => c.Text("Do you really want to exit?"));
            app.Tap(c => c.Text("Yes"));

            AppResult[] appResults = app.WaitForElement(c => c.Marked("ControllersPicker"));
            Assert.IsTrue(appResults.Any());
        }

        [Test]
        public void CreateSunDetectorControllerTest()
        {
            //app.Repl();
            app.Tap(c => c.Text("Controllers"));
            app.WaitForElement(c => c.Marked("ControllersPicker"));
            app.Tap(c => c.Marked("ControllersPicker"));
            app.Tap(c => c.Text("Sun Detector"));
            app.WaitForElement(c => c.Text("Connect"));
            app.Tap(c => c.Text("Connect"));

            app.WaitForElement(c => c.Text("0"));
            app.TapCoordinates(1050, 200);
            app.WaitForElement(c => c.Text("1"));

            app.Back();
            app.WaitForElement(c => c.Text("Do you really want to exit?"));
            app.Tap(c => c.Text("Yes"));

            AppResult[] appResults = app.WaitForElement(c => c.Marked("ControllersPicker"));
            Assert.IsTrue(appResults.Any());
        }

        [Test]
        public void CreateSwitchControllerTest()
        {
            app.Repl();
            app.Tap(c => c.Text("Controllers"));
            app.WaitForElement(c => c.Marked("ControllersPicker"));
            app.Tap(c => c.Marked("ControllersPicker"));
            app.Tap(c => c.Text("Switch"));
            app.WaitForElement(c => c.Text("Connect"));
            app.Tap(c => c.Text("Connect"));

            app.WaitForElement(c => c.Marked("SwitchController"));
            app.Tap(c => c.Marked("SwitchController"));
            app.WaitForElement(c => c.Switch("SwitchController"));


            app.Back();
            app.WaitForElement(c => c.Text("Do you really want to exit?"));
            app.Tap(c => c.Text("Yes"));

            AppResult[] appResults = app.WaitForElement(c => c.Marked("ControllersPicker"));
            Assert.IsTrue(appResults.Any());
        }


    }
}

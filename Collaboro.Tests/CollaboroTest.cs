using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace Collaboro.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class CollaboroTest
    {
        IApp app;
        Platform platform;

        public CollaboroTest(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }

        // All data entries are correct
        [Test]
        public void TestSignUp()
        {
            // enter first name
            app.Tap("firstNameEntry");
            app.EnterText("Jason");
            app.Back();
            // enter last name
            app.Tap("surnameEntry");
            app.EnterText("Doe");
            app.Back();
            // enter email address
            app.Tap("emailAddressEntry");
            app.EnterText("jason@gmail.com");
            app.Back();
            // enter double-check email address
            app.Tap("confirmEmailAdressEntry");
            app.EnterText("jason@gmail.com");
            app.Back();
            // enter password
            app.Tap("passwordEntry");
            app.EnterText("222222");
            app.Back();
            // enter double-check password
            app.Tap("confirmPasswordEntry");
            app.EnterText("222222");
            app.Back();
            // select university
            app.Tap("universityPicker");
            app.Tap("QUT");
            // set switch to "accept"
            app.Tap("acceptTC");

            // check if the page went to the next page

            //app.WaitForElement(x => x.Marked("ResultLabel").Text("8"));
            Assert.Pass("Your first passing test");
        }   // end of TestSignUp()


        // name is left blank
        [Test]
        public void TestSignUpNameBlank()
        {
            // enter last name
            app.Tap("surnameEntry");
            app.EnterText("Doe");
            app.Back();
            // enter email address
            app.Tap("emailAddressEntry");
            app.EnterText("jason@gmail.com");
            app.Back();
            // enter double-check email address
            app.Tap("confirmEmailAdressEntry");
            app.EnterText("jason@gmail.com");
            app.Back();
            // enter password
            app.Tap("passwordEntry");
            app.EnterText("222222");
            app.Back();
            // enter double-check password
            app.Tap("confirmPasswordEntry");
            app.EnterText("222222");
            app.Back();
            // select university
            app.Tap("universityPicker");
            app.Tap("QUT");
            // set switch to "accept"
            app.Tap("acceptTC");

            // check if the page went to the next page
            // (or if it gave the user a message like it was supposed to)

            Assert.Pass("Your first passing test");
        }   // end of TestSignUpNameBlank()


        // name is left blank
        [Test]
        public void TestSignUpSurnameBlank()
        {
            // enter first name
            app.Tap("firstNameEntry");
            app.EnterText("Jason");
            app.Back();
            // enter email address
            app.Tap("emailAddressEntry");
            app.EnterText("jason@gmail.com");
            app.Back();
            // enter double-check email address
            app.Tap("confirmEmailAdressEntry");
            app.EnterText("jason@gmail.com");
            app.Back();
            // enter password
            app.Tap("passwordEntry");
            app.EnterText("222222");
            app.Back();
            // enter double-check password
            app.Tap("confirmPasswordEntry");
            app.EnterText("222222");
            app.Back();
            // select university
            app.Tap("universityPicker");
            app.Tap("QUT");
            // set switch to "accept"
            app.Tap("acceptTC");

            // check if the page went to the next page
            // (or if it gave the user a message like it was supposed to)

            Assert.Pass("Your first passing test");
        }   // end of TestSignUpSurnameBlank()

    }
}

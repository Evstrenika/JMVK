using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Collaboro
{
    public partial class App : Application
    {

        // Initialise Variables
        private ContentPage homePage;

        public App()
        {
            InitializeComponent();

            //MainPage = new Collaboro.MainPage();

            // To be implemented properly once login is sorted
            
            string user = "Tony";       // Temporary- for testing only
            
            if (user == null)
            {
                MainPage = new Collaboro.MainPage();
            }
            else
            {
                homePage = new Collaboro.HomePage();
                MainPage = new NavigationPage(homePage);
                PageNavigationManager.Instance.Navigation = MainPage.Navigation;
            }
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

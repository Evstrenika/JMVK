using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Collaboro
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // To be implemented properly once login is sorted
            
            string user = null;       // Temporary- for testing only
            
            if (user == null)
            {
                MainPage = new NavigationPage(new MainPage());
                PageNavigationManager.Instance.Navigation = MainPage.Navigation;
            }
            else
            {
                MainPage = new NavigationPage(new HomePage());
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

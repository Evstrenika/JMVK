using Collaboro.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Collaboro
{
    public partial class App : Application
    {
        static Database database;

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

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return database;
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

//using Collaboro.Data;
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
using Collaboro.Data;
using Collaboro.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Collaboro
{
    public partial class App : Application
    {
        public static DBManager DatabaseManager { get; private set; }

        public App()
        {
            InitializeComponent();
            DatabaseManager = new DBManager(new DBService(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3")));

            StaticDatabasePrototyping();

            MainPage = new NavigationPage(new MainPage());
            PageNavigationManager.Instance.Navigation = MainPage.Navigation;

        }

        
        private async void StaticDatabasePrototyping()
        {
            try
            {
                Student jason = new Student();
                jason.Email = "j@g.com";
                jason.FirstName = "Jason";
                jason.Surname = "Smith";
                jason.University = "QUT";
                jason.Password = "222222";
                await App.DatabaseManager.RecordStudentAsync(jason);
            }
            catch
            {
                // Above already added
            }
        }
        
        /*public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return database;
            }
        }*/

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

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
        public static string AccountEmail { get; set; }

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
            if (await DatabaseManager.ReturnNumStudents() == 0)
            {
                Student jason = new Student();
                jason.Email = "j@g.com";
                jason.FirstName = "Jason";
                jason.Surname = "Smith";
                jason.University = "QUT";
                jason.Password = "222222";
                await DatabaseManager.RecordStudentAsync(jason);

                Student frank = new Student();
                frank.Email = "frank@gmail.com";
                frank.FirstName = "Frank";
                frank.Surname = "Martin";
                frank.University = "QUT";
                frank.Password = "333333";
                await DatabaseManager.RecordStudentAsync(frank);
            }

            if (await DatabaseManager.GetGroupAsync(1) == null)
            {
                Group team = new Group();
                team.SubjectCode = "IAB330";
                team.NumberMembers = 2;
                await DatabaseManager.AddGroupAsync(team);

                Member frankOwner = new Member();
                frankOwner.MemberEmail = "frank@gmail.com";
                frankOwner.GroupID = 1;
                frankOwner.Displayed = true;
                frankOwner.Confirmed = true;
                await DatabaseManager.AddMemberAsync(frankOwner);

                Member jasonMember = new Member();
                jasonMember.MemberEmail = "j@g.com";
                jasonMember.GroupID = 1;
                jasonMember.Displayed = false;
                jasonMember.Confirmed = false;
                await DatabaseManager.AddMemberAsync(jasonMember);
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

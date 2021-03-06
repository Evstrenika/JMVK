﻿using System;
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


        /// <summary>
        /// Initialises the app when first loaded
        /// </summary>
        public App()
        {
            InitializeComponent();
            DatabaseManager = new DBManager(new DBService(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3")));

            StaticDatabasePrototyping();

            MainPage = new NavigationPage(new MainPage());
            //MainPage = new NavigationPage(new HomePage("jason@gmail.com"));       // Used to speed up testing
            PageNavigationManager.Instance.Navigation = MainPage.Navigation;

        }

        
        /// <summary>
        /// These commands are run to simulate a cloud database and to allow for testing to occur as a
        /// local database is used for this iteration.
        /// Note that both Jason and Frank have a CAB403 class at the same time so this can be used to check 
        /// that FindMeeting works correctly.
        /// Login details for both users:
        /// Frank: frank@gmail.com  333333
        /// Jason: jason@gmail.com  222222
        /// </summary>
        private async void StaticDatabasePrototyping()
        {
            if (await DatabaseManager.ReturnNumStudentsAsync() == 0)
            {
                Student jason = new Student();
                jason.Email = "jason@gmail.com";
                jason.FirstName = "Jason";
                jason.Surname = "Smith";
                jason.University = "QUT";
                jason.Password = "222222";
                await DatabaseManager.RecordStudentAsync(jason);

                UserAvailability busy = new UserAvailability();
                #region Availability assigning
                busy.Email = jason.Email;
                busy.Activity = "Busy";
                busy.Day = "Monday";
                busy.Time = "12am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "1am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "2am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "3am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "4am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "5am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "6am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "7am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "9pm";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "10pm";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "11pm";
                await DatabaseManager.AddAvailabilityAsync(busy);

                busy.Day = "Tuesday";
                busy.Time = "12am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "1am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "2am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "3am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "4am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "5am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "6am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "7am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "9pm";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "10pm";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "11pm";
                await DatabaseManager.AddAvailabilityAsync(busy);

                busy.Day = "Wednesday";
                busy.Time = "12am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "1am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "2am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "3am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "4am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "5am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "6am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "7am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "9pm";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "10pm";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "11pm";
                await DatabaseManager.AddAvailabilityAsync(busy);

                busy.Day = "Thursday";
                busy.Time = "12am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "1am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "2am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "3am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "4am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "5am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "6am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "7am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "9pm";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "10pm";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "11pm";
                await DatabaseManager.AddAvailabilityAsync(busy);

                busy.Day = "Friday";
                busy.Time = "12am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "1am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "2am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "3am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "4am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "5am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "6am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "7am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "9pm";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "10pm";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "11pm";
                await DatabaseManager.AddAvailabilityAsync(busy);

                busy.Day = "Saturday";
                busy.Time = "12am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "1am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "2am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "3am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "4am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "5am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "6am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "7am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "11pm";
                await DatabaseManager.AddAvailabilityAsync(busy);

                busy.Day = "Sunday";
                busy.Time = "12am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "1am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "2am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "3am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "4am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "5am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "6am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "7am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "11pm";
                await DatabaseManager.AddAvailabilityAsync(busy);

                // Classes
                busy.Day = "Tuesday";
                busy.Activity = "IAB330";
                busy.Time = "11am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "12pm";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Day = "Thursday";
                busy.Activity = "CAB403";
                busy.Time = "11am";
                await DatabaseManager.AddAvailabilityAsync(busy);
                busy.Time = "12pm";
                await DatabaseManager.AddAvailabilityAsync(busy);
                #endregion


                Student frank = new Student();
                frank.Email = "frank@gmail.com";
                frank.FirstName = "Frank";
                frank.Surname = "Martin";
                frank.University = "QUT";
                frank.Password = "333333";
                await DatabaseManager.RecordStudentAsync(frank);

                UserAvailability booked = new UserAvailability();
                #region Availability assigning 2
                booked.Email = frank.Email;
                booked.Activity = "Busy";
                booked.Day = "Monday";
                booked.Time = "8am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "9am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "10am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "3pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "4pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "5pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "6pm";
                await DatabaseManager.AddAvailabilityAsync(booked);

                booked.Day = "Tuesday";
                booked.Time = "8am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "9am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "10am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "3pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "6pm";
                await DatabaseManager.AddAvailabilityAsync(booked);

                booked.Day = "Wednesday";
                booked.Time = "8am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "9am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "10am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "3pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "4pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "5pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "6pm";
                await DatabaseManager.AddAvailabilityAsync(booked);

                booked.Day = "Thursday";
                booked.Time = "8am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "9am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "10am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "3pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "4pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "5pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "6pm";
                await DatabaseManager.AddAvailabilityAsync(booked);

                booked.Day = "Friday";
                booked.Time = "8am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "9am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "10am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "3pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "4pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "5pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "6pm";
                await DatabaseManager.AddAvailabilityAsync(booked);

                booked.Day = "Saturday";
                booked.Time = "8am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "9am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "10am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "3pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "4pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "5pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "6pm";
                await DatabaseManager.AddAvailabilityAsync(booked);

                booked.Day = "Sunday";
                booked.Time = "8am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "9am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "10am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "3pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "4pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "5pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "6pm";
                await DatabaseManager.AddAvailabilityAsync(booked);

                // Classes
                booked.Day = "Tuesday";
                booked.Activity = "IAB330";
                booked.Time = "11am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "12pm";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Day = "Thursday";
                booked.Activity = "CAB403";
                booked.Time = "11am";
                await DatabaseManager.AddAvailabilityAsync(booked);
                booked.Time = "12pm";
                await DatabaseManager.AddAvailabilityAsync(booked);

                #endregion

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
                jasonMember.MemberEmail = "jason@gmail.com";
                jasonMember.GroupID = 1;
                jasonMember.Displayed = false;
                jasonMember.Confirmed = false;
                await DatabaseManager.AddMemberAsync(jasonMember);
            }
        }
       

        /// <summary>
        /// Runs when the app is started. No content required here at this time.
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
            
        }

        /// <summary>
        /// Runs when the app is put to sleep. No content required here at this time.
        /// </summary>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// Runs when the app is resumed. No content required here at this time.
        /// </summary>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

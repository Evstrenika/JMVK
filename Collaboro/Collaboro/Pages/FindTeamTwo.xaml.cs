using Collaboro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Collaboro.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindTeamTwo : ContentPage
    {
        // Variables
        string code;
        string day;
        string time;
        int members;
        int groupID;

        /// <summary>
        /// Create FindTeamTwo page and assign parameters to private variables
        /// </summary>
        /// <param name="code"></param>
        /// <param name="day"></param>
        /// <param name="time"></param>
        /// <param name="members"></param>
        public FindTeamTwo(string code, string day, string time, int members)
        {
            InitializeComponent();
            this.code = code;
            this.day = day;
            this.time = time;
            this.members = members;

            CreateNewTeam();
        }

        /// <summary>
        /// Generates a new team with the parameters entered in FindTeam
        /// </summary>
        private async void CreateNewTeam()
        {
            var newGroup = new Group();
            newGroup.SubjectCode = code;
            newGroup.NumberMembers = members;
            await App.DatabaseManager.AddGroupAsync(newGroup);
            groupID = newGroup.ID;

            var newMember = new Member();
            newMember.GroupID = groupID;
            newMember.Confirmed = true;
            newMember.Displayed = true;
            newMember.MemberEmail = App.AccountEmail;
            await App.DatabaseManager.AddMemberAsync(newMember);
        }

        /// <summary>
        /// Fills the ListView when page shown
        /// </summary>
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            // Check number team members, send to home if already at max            ** TO DO
            memberList.ItemsSource = await GetPotentialTeammates();
        }

        /// <summary>
        /// Finds the potential teammates for the user to be entered in the ListView
        /// </summary>
        /// <returns></returns>
        private async Task<List<Student>> GetPotentialTeammates()
        {
            List<Student> potentialTeammates = new List<Student>();
            List<UserAvailability> items = await App.DatabaseManager.GetPotentialMembersAsync(code, day, time);

            foreach (UserAvailability mate in items)
            {
                if (mate.Email != App.AccountEmail)
                {
                    potentialTeammates.Add(await App.DatabaseManager.ReturnStudentAsync(mate.Email));
                }
            }
            return potentialTeammates;
        }

        /// <summary>
        /// Takes the user to the selected student's page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedStudent = e.SelectedItem as Student;
            Navigation.PushAsync(new FindTeamThree(selectedStudent, groupID));
        }
    }
}
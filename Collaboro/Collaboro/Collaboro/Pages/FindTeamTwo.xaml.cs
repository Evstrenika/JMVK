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

        public FindTeamTwo(string code, string day, string time, int members, string[] skills)
        {
            InitializeComponent();
            this.code = code;
            this.day = day;
            this.time = time;
            this.members = members;


            var newGroup = new Group();
            newGroup.SubjectCode = code;
            newGroup.NumberMembers = members;
            App.DatabaseManager.AddGroupAsync(newGroup);
            groupID = newGroup.ID;

            var newMember = new Member();
            newMember.GroupID = groupID;
            newMember.Confirmed = true;
            newMember.Displayed = true;
            //newMember.MemberEmail = TO DO     ** WHEN WE SAVE CURRENT USER DETAILS SOMEWHERE
            App.DatabaseManager.AddMemberAsync(newMember);
            members--;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // This next line probably needs to go back in eventually
            //var items = await App.DatabaseManager.GetPotentialMembersAsync(code, day, time);
            //listView.ItemsSource = items;
        }

        // When user is clicked
        // private async void CommandName()
        // await Navigation.PushAsync(new FindTeamThree(userEmail, groupID));

        // When findTeamThree is popped (this page is resumed)
        // check # members

    }
}
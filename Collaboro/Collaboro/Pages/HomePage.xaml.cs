using Collaboro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Collaboro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage(string user)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "Back");
            App.AccountEmail = user;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            
            // -- Show Notifications --
            // People have accepted request
            List<Member> memberOf = await App.DatabaseManager.GetStudentMemberships(App.AccountEmail);
            foreach (Member group in memberOf)
            {
                Group team = await App.DatabaseManager.GetGroupAsync(group.GroupID);

                List<Member> undisplayedMembers = await App.DatabaseManager.GetUndisplayedMembersAsync(group);
                foreach (Member undisplayedMember in undisplayedMembers)
                {
                    Student teammate = await App.DatabaseManager.ReturnStudentAsync(undisplayedMember.MemberEmail);
                    await DisplayAlert("Accepted Request", teammate.FirstName + " " 
                        + teammate.Surname + " accepted your request to join your " + team.SubjectCode + " team!", "OK");
                    await App.DatabaseManager.MemberDisplayed(undisplayedMember);
                }
            }

            // Offers to join a group
            List<Member> offered = await App.DatabaseManager.GetPendingStudentMemberships(App.AccountEmail);
            foreach (Member offer in offered)
            {
                Group team = await App.DatabaseManager.GetGroupAsync(offer.GroupID);
                Student founder = await App.DatabaseManager.GetTeamFounder(team);

                var answer = await DisplayAlert(team.SubjectCode, 
                    "Group Offer for " + team.SubjectCode + " from " + founder.FirstName + " " + founder.Surname, "Accept", "Deny");
                if (answer == true) // Accept
                {
                    await App.DatabaseManager.AcceptMembership(offer);
                }
                else // Deny
                {
                    await App.DatabaseManager.RemoveMemberAsync(offer);
                }
            }
        }
    }
}
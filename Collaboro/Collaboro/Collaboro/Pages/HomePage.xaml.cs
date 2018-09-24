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
        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "Back");
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // TEMPORARY UNTIL LOGGED IN DETAILS SAVED **
            string email = "hithere@hotmail.com";

            // -- Show Notifications --

            // People have accepted request
            List<Member> memberOf = await App.DatabaseManager.GetStudentMemberships(email);
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
            List<Member> offered = await App.DatabaseManager.GetPendingStudentMemberships(email);
            foreach (Member offer in offered)
            {
                Group team = await App.DatabaseManager.GetGroupAsync(offer.GroupID);

                var answer = await DisplayAlert(team.SubjectCode, "Group Offer for " + team.SubjectCode, "Accept", "Deny");
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
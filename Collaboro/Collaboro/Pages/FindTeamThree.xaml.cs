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
    public partial class FindTeamThree : ContentPage
    {
        // Variables
        Student student;
        int groupID;

        /// <summary>
        /// Creates the FindTeamThree page and assigns inputs to private variables
        /// </summary>
        /// <param name="email">Email of potential teammate</param>
        /// <param name="groupID">Group in progress ID</param>
        public FindTeamThree(Student selectedStudent, int groupID)
        {
            InitializeComponent();
            student = selectedStudent;
            this.groupID = groupID;
        }

        /// <summary>
        /// When the page is shown, present information relevant to the selected student
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Title = student.FirstName + " " + student.Surname;
        }

        /// <summary>
        /// If the submit button is clicked, the selected user is added to the team.
        /// The submit button then becomes an undo button.
        /// If the button is clicked in the undo state, it will remove the invitation to add the team member and
        /// change back to the invite state
        /// </summary>
        private async void OnSubmit()
        {
            Member member = new Member();
            member.GroupID = groupID;
            member.MemberEmail = student.Email;
            member.Confirmed = false;
            member.Displayed = false;

            if (SubmitBtn.Text == "Invite to Team")
            {
                SubmitBtn.Text = "Undo Invitation";
                FinishedBtn.IsVisible = true;
                await App.DatabaseManager.AddMemberAsync(member);
            }
            else
            {
                SubmitBtn.Text = "Invite to Team";
                await App.DatabaseManager.RemoveMemberAsync(await App.DatabaseManager.GetMember(member.MemberEmail, member.GroupID));
            }
        }
    }
}
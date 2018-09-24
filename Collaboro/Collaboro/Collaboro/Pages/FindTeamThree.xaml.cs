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
        string email;
        Student student;
        int groupID;

        public FindTeamThree(string email, int groupID)
        {
            InitializeComponent();
            this.email = email;
            this.groupID = groupID;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            student = await App.DatabaseManager.ReturnStudentAsync(email);
            Title = student.FirstName + " " + student.Surname;
        }

        private async void OnSubmit()
        {
            Member member = new Member();
            member.GroupID = groupID;
            member.MemberEmail = email;
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
                await App.DatabaseManager.RemoveMemberAsync(member);
            }
        }
    }
}
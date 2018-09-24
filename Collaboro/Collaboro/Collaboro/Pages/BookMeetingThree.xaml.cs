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
    public partial class BookMeetingThree : ContentPage
    {
        public BookMeetingThree(double length, string minTime, string maxTime)
        {
            InitializeComponent();
        }

        // TO DO ONCE DATABASE FOR MEETINGS SET UP **
        /*
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            List<Member> memberships = await App.DatabaseManager.GetStudentMemberships(email);
            List<Group> groups = new List<Group>();
            foreach (Member member in memberships)
            {
                groups.Add(await App.DatabaseManager.GetGroupAsync(member.GroupID));
            }

            groupsList.ItemsSource = groups;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var selectedGroup = e.SelectedItem as Group;
            //Navigation.PushAsync(new BookMeetingFour(selectedGroup));
        }*/
    }
}
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
    public partial class BookMeeting : ContentPage
    {
        public BookMeeting()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            groupsList.ItemsSource = await GetGroupList();
        }

        private async Task<List<Group>> GetGroupList()
        {
            List<Member> memberships = await App.DatabaseManager.GetStudentMemberships(App.AccountEmail);
            List<Group> groups = new List<Group>();
            foreach (Member member in memberships)
            {
                groups.Add(await App.DatabaseManager.GetGroupAsync(member.GroupID));
            }
            return groups;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedGroup = e.SelectedItem as Group;
            Navigation.PushAsync(new BookMeetingTwo(selectedGroup));
        }
    }
}
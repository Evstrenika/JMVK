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
        /// <summary>
        /// Creates the BookMeeting page
        /// </summary>
        public BookMeeting()
        {
            InitializeComponent();

        }

        /// <summary>
        /// When the page appears, load the available groups into the ListView
        /// </summary>
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            groupsList.ItemsSource = await GetGroupList();
        }

        /// <summary>
        /// Collects the groups the user is included in
        /// This will be sent to the ViewList
        /// </summary>
        /// <returns>A list of groups</returns>
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

        /// <summary>
        /// When an item is selected, continue to the next step in the Book Meeting process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedGroup = e.SelectedItem as Group;
            Navigation.PushAsync(new BookMeetingTwo(selectedGroup));
        }
    }
}
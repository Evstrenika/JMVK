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
        private Group team;
        private string minTime;
        private string maxTime;
        private double length;

        /// <summary>
        /// Creates a BookMeetingThree page and stores given parameters in private variables
        /// </summary>
        /// <param name="selected"></param>
        /// <param name="length"></param>
        /// <param name="minTime"></param>
        /// <param name="maxTime"></param>
        public BookMeetingThree(Group selected, double length, string minTime, string maxTime)
        {
            InitializeComponent();
            team = selected;
            this.minTime = minTime;
            this.maxTime = maxTime;
            this.length = length;
        }

        /// <summary>
        /// Fills the ListView when the page appears
        /// </summary>
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            availabilitiesList.ItemsSource = await FindMutualAvailability();
        }

        /// <summary>
        /// Finds the times all team members are available and returns them as a list to be
        /// inserted into the ListView
        /// </summary>
        /// <returns>A list of mututally available times</returns>
        private async Task<List<UserAvailability>> FindMutualAvailability()
        {
            string[] days = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string[] times = new string[] {"12am", "1am", "2am", "3am", "4am", "5am", "6am", "7am", "8am", "9am", "10am", "11am",
                                            "12pm", "1pm", "2pm", "3pm", "4pm", "5pm", "6pm", "7pm", "8pm", "9pm", "10pm", "11pm"};

            List<UserAvailability> mutualTimes = new List<UserAvailability>();
            List<Member> memberships = await App.DatabaseManager.GetTeamMembers(team);

            foreach (string day in days)
            {
                foreach (string time in times)
                {
                    // Check time is inside min/max
                    if ((Array.IndexOf(times, minTime) <= Array.IndexOf(times, time)) && (Array.IndexOf(times, maxTime) >= Array.IndexOf(times, time)))
                    {
                        // Check if anyone is busy
                        bool busy = false;
                        foreach (Member member in memberships)
                        {
                            for (int timeSpent = 0; timeSpent < length; timeSpent++)
                            {
                                string currentTime = times[(Array.IndexOf(times, time) + timeSpent) % 24];
                                List<UserAvailability> isAvailable = await App.DatabaseManager.AvailabilityExists(member.MemberEmail, day, currentTime);
                                if (isAvailable.Count() > 0)
                                {
                                    busy = true;
                                }
                            }
                        }

                        // Add availability if free for everyone
                        if (!busy)
                        {
                            UserAvailability freeTime = new UserAvailability();
                            freeTime.Activity = "Meeting";
                            freeTime.Time = time;
                            freeTime.Day = day;
                            mutualTimes.Add(freeTime);
                        }
                    }
                }
            }

            return mutualTimes;
        }

        /// <summary>
        /// Takes the user to the confirmation page with the selected day and time sent as parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedAvail = e.SelectedItem as UserAvailability;
            Navigation.PushAsync(new BookMeetingFour(team, selectedAvail, length));
        }
    }
}
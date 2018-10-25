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

        public BookMeetingThree(Group selected, double length, string minTime, string maxTime)
        {
            InitializeComponent();
            team = selected;
            this.minTime = minTime;
            this.maxTime = maxTime;
            this.length = length;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            availabilitiesList.ItemsSource = await FindMutualAvailability();
        }

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
                            List<UserAvailability> isAvailable = await App.DatabaseManager.AvailabilityExists(member.MemberEmail, day, time);
                            if (isAvailable.Count() > 0)
                            {
                                busy = true;
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

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedAvail = e.SelectedItem as UserAvailability;
            Navigation.PushAsync(new BookMeetingFour(team, selectedAvail, length));
        }
    }
}
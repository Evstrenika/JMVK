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
    public partial class BookMeetingFour : ContentPage
    {
        private Group team;
        private UserAvailability booking;

        public BookMeetingFour(Group team, UserAvailability time, double length)
        {
            InitializeComponent();
            this.team = team;
            booking = time;

            string[] times = new string[] {"12am", "1am", "2am", "3am", "4am", "5am", "6am", "7am", "8am", "9am", "10am", "11am",
                                            "12pm", "1pm", "2pm", "3pm", "4pm", "5pm", "6pm", "7pm", "8pm", "9pm", "10pm", "11pm"};

            string endTime = times[(Array.IndexOf(times, time.Time) + (int)length)%24];
            Chosen.Text = time.Day + " " + time.Time + " to " + endTime;
        }

        private async void Confirmation()
        {
            // Add meeting to members' availability
            List<Member> memberships = await App.DatabaseManager.GetTeamMembers(team);
            foreach (Member member in memberships)
            {
                booking.Email = member.MemberEmail;
                await App.DatabaseManager.AddAvailabilityAsync(booking);
            }

            // Add Meeting
            Meeting meeting = new Meeting();
            meeting.GroupID = team.ID;
            meeting.Day = booking.Day;
            meeting.Time = booking.Time;
            if (locationEntry.Text != "")
            {
                meeting.Location = locationEntry.Text;
            }
            await App.DatabaseManager.AddMeetingAsync(meeting);

            await Navigation.PushAsync(new HomePage(App.AccountEmail));
        }
    }
}
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
        private int length;
        private string[] times = new string[] {"12am", "1am", "2am", "3am", "4am", "5am", "6am", "7am", "8am", "9am", "10am", "11am",
                                            "12pm", "1pm", "2pm", "3pm", "4pm", "5pm", "6pm", "7pm", "8pm", "9pm", "10pm", "11pm"};

        /// <summary>
        /// Creates the BookMeetingFour page and assigns given paramters to private variables
        /// </summary>
        /// <param name="team">The team the meeting is for</param>
        /// <param name="time">The day and time of the meeting</param>
        /// <param name="length">The length of the meeting</param>
        public BookMeetingFour(Group team, UserAvailability time, double length)
        {
            InitializeComponent();
            this.team = team;
            booking = time;
            this.length = (int)length;

            string endTime = times[(Array.IndexOf(times, time.Time) + (int)length)%24];
            Chosen.Text = time.Day + " " + time.Time + " to " + endTime;
        }

        /// <summary>
        /// Confirms the meeting, creating an availability for each team member and a meeting in the database
        /// Takes the user back to the home page on completion
        /// </summary>
        private async void Confirmation()
        {
            // Add meeting to members' availability
            List<Member> memberships = await App.DatabaseManager.GetTeamMembers(team);
            for (int increase = 0; increase < length; increase++)
            {
                foreach (Member member in memberships)
                {
                    booking.Email = member.MemberEmail;
                    await App.DatabaseManager.AddAvailabilityAsync(booking);
                }
                booking.Time = times[(Array.IndexOf(times, booking.Time) + 1) % 24];
            }

            // Add Meeting
            Meeting meeting = new Meeting();
            meeting.GroupID = team.ID;
            meeting.Day = booking.Day;
            meeting.Time = booking.Time;
            meeting.Length = length;
            if (locationEntry.Text != "")
            {
                meeting.Location = locationEntry.Text;
            }
            await App.DatabaseManager.AddMeetingAsync(meeting);

            await Navigation.PushAsync(new HomePage(App.AccountEmail));
        }
    }
}
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
    public class AvailabilityFunctions
    {

        public static async Task<List<TimeSlot>> InitialiseAvailability(List<TimeSlot> dayList, string dayName)
        {
            string[] times = new string[] {"12am", "1am", "2am", "3am", "4am", "5am", "6am", "7am", "8am", "9am", "10am", "11am",
                                            "12pm", "1pm", "2pm", "3pm", "4pm", "5pm", "6pm", "7pm", "8pm", "9pm", "10pm", "11pm"};

            for (int hour = 0; hour < 24; hour++)
            {
                List<UserAvailability> hourSlot = await App.DatabaseManager.AvailabilityExists(App.AccountEmail, dayName, times[hour]);
                if (hourSlot.Count() > 0 && hourSlot[0].Activity != null && (hourSlot[0].Activity == "Busy" || hourSlot[0].Activity == "Meeting"))
                {
                    dayList[hour].OtherwiseBusy = true;
                    dayList[hour].ClassBusyEnabled = false;
                }
                else if (hourSlot.Count() > 0)
                {
                    dayList[hour].ClassAtThisTime = true;
                    dayList[hour].OtherBusyEnabled = false;
                }
            }

            return dayList;
        }

        public static List<TimeSlot> InitialiseDayList(List<TimeSlot> dayList, string day)
        {
            // Creates all the TimeSlots and places them into cells which become the source for ThursdayList
            for (int i = 0; i < 23; i++)
            {
                dayList.Add(new TimeSlot(i, i + 1, day));
            }
            dayList.Add(new TimeSlot(23, 0, day));
            return dayList;
        }

        public static List<TimeSlot> ClearButton(List<TimeSlot> dayList)
        {
            foreach (TimeSlot day in dayList)
            {
                day.ClassAtThisTime = false;
                day.OtherwiseBusy = false;
                day.ClassBusyEnabled = true;
                day.OtherBusyEnabled = true;
            }
            return dayList;
        }

        public static async Task<List<TimeSlot>> UpdateButton(List<TimeSlot> dayList, string dayName)
        {
            UserAvailability availabilitySlot = new UserAvailability
            {
                Email = App.AccountEmail,
                Day = dayName
            };

            foreach (TimeSlot day in dayList)
            {
                //  Set the time
                string[] times = new string[] {"12am", "1am", "2am", "3am", "4am", "5am", "6am", "7am", "8am", "9am", "10am", "11am",
                                            "12pm", "1pm", "2pm", "3pm", "4pm", "5pm", "6pm", "7pm", "8pm", "9pm", "10pm", "11pm"};
                availabilitySlot.Time = times[dayList.IndexOf(day)];

                // Check if entry exists
                List<UserAvailability> userAvailibilitiesList = await App.DatabaseManager.AvailabilityExists(availabilitySlot.Email, availabilitySlot.Day, availabilitySlot.Time);
                bool listEmpty = userAvailibilitiesList.Count() <= 0;

                // Find out what type of activity it is
                if (day.ClassAtThisTime)
                {
                    availabilitySlot.Activity = day.subjectCode;
                    if (!listEmpty && userAvailibilitiesList[0].Activity != availabilitySlot.Activity)
                    {
                        // Replace entry
                        await App.DatabaseManager.AlterActivityAsync(availabilitySlot, userAvailibilitiesList[0]);
                    }
                    else if (listEmpty)
                    {
                        // Add Entry
                        await App.DatabaseManager.AddAvailabilityAsync(availabilitySlot);
                    }
                }
                else if (day.OtherwiseBusy)
                {
                    availabilitySlot.Activity = "Busy";
                    if (!listEmpty && userAvailibilitiesList[0].Activity != availabilitySlot.Activity)
                    {
                        // Replace entry
                        await App.DatabaseManager.AlterActivityAsync(availabilitySlot, userAvailibilitiesList[0]);
                    }
                    else if (listEmpty)
                    {
                        // Add Entry
                        await App.DatabaseManager.AddAvailabilityAsync(availabilitySlot);
                    }
                }
                else
                {
                    // No activity
                    if (!listEmpty)
                    {
                        // Remove Entry
                        await App.DatabaseManager.RemoveAvailabilityAsync(userAvailibilitiesList[0]);
                    }
                }
            }

            return dayList;
        }
    }
}

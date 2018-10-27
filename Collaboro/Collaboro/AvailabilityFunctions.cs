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
        private static string[] times = new string[] {"12am", "1am", "2am", "3am", "4am", "5am", "6am", "7am", "8am", "9am", "10am", "11am",
                                            "12pm", "1pm", "2pm", "3pm", "4pm", "5pm", "6pm", "7pm", "8pm", "9pm", "10pm", "11pm"};


        /// <summary>
        /// Initialises the sliders in the ListView based on data from the database.
        /// </summary>
        /// <param name="dayList">Source of ListView</param>
        /// <param name="dayName">Selected page</param>
        /// <returns></returns>
        public static async Task<List<TimeSlot>> InitialiseAvailability(List<TimeSlot> dayList, string dayName)
        {
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


        /// <summary>
        /// Creates the source for the ListView
        /// </summary>
        /// <param name="dayList">Source of ListView</param>
        /// <param name="day">Selected page</param>
        /// <returns></returns>
        public static List<TimeSlot> InitialiseDayList(List<TimeSlot> dayList, string day)
        {
            // Creates all the TimeSlots and places them into cells which become the source for the ListView
            for (int i = 0; i < 23; i++)
            {
                dayList.Add(new TimeSlot(i, i + 1, day));
            }
            dayList.Add(new TimeSlot(23, 0, day));
            return dayList;
        }


        /// <summary>
        /// Clears the sliders and database of all entries
        /// Occurs once the clear button is clicked
        /// </summary>
        /// <param name="dayList">Source of ListView</param>
        /// <param name="dayName">Selected page</param>
        /// <returns></returns>
        public async static Task<List<TimeSlot>> ClearButton(List<TimeSlot> dayList, string dayName)
        {
            foreach (TimeSlot day in dayList)
            {
                // Update ListView
                day.ClassAtThisTime = false;
                day.OtherwiseBusy = false;
                day.ClassBusyEnabled = true;
                day.OtherBusyEnabled = true;

                // Update Database
                List<UserAvailability> userAvailibilitiesList = await App.DatabaseManager.AvailabilityExists(App.AccountEmail, dayName, times[dayList.IndexOf(day)]);
                if (userAvailibilitiesList.Count() > 0)
                {
                    foreach (UserAvailability slot in userAvailibilitiesList)
                    {
                        await App.DatabaseManager.RemoveAvailabilityAsync(slot);
                    }
                }
            }
            return dayList;
        }


        /// <summary>
        /// Updates the database based on the sliders currently selected/deselected
        /// </summary>
        /// <param name="dayList">Source of ListView</param>
        /// <param name="dayName">Selected page</param>
        /// <returns></returns>
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

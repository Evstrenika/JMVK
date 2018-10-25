﻿using Collaboro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Collaboro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Monday : ContentPage
    {
        // new List rList to hold all the values of TimeSlot
        public List<TimeSlot> mList = new List<TimeSlot> { };
        private int maxNumInstantiated = 0; // will count how many TimeSlot cells are available

        public Monday()
        {
            InitializeComponent();

            for (int i = 0; i < 23; i++)
            {
                mList.Add(new TimeSlot(i, i + 1, "Monday"));
            }
            mList.Add(new TimeSlot(23, 0, "Monday"));
            MondayList.ItemsSource = mList;

            InitialiseAvailability();

        }

        private async void InitialiseAvailability()
        {
            string[] times = new string[] {"12am", "1am", "2am", "3am", "4am", "5am", "6am", "7am", "8am", "9am", "10am", "11am",
                                            "12pm", "1pm", "2pm", "3pm", "4pm", "5pm", "6pm", "7pm", "8pm", "9pm", "10pm", "11pm"};

            for (int hour = 0; hour < 24; hour++)
            {
                List<UserAvailability> hourSlot = await App.DatabaseManager.AvailabilityExists(App.AccountEmail, "Monday", times[hour]);
                if (hourSlot.Count() > 0 && hourSlot[0].Activity != null && (hourSlot[0].Activity == "Busy" || hourSlot[0].Activity == "Meeting"))
                {
                    mList[hour].OtherBusyEnabled = true;
                    mList[hour].ClassBusyEnabled = false;
                } 
                else if (hourSlot.Count() > 0)
                {
                    mList[hour].OtherBusyEnabled = false;
                    mList[hour].ClassBusyEnabled = true;
                }
            }
        }

        /// <summary>
        /// If the ClassSwitch (the left one) is toggled, this method is called
        /// Pre: Class Switch is toggled
        /// Post: Disables the other switch if ClassSwitch is toggled to be true,
        ///         if ClassSwitch is toggled to be false, re-enables the other
        ///         switch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            ViewCell cell = (sender as Switch).Parent.Parent as ViewCell;

            // find the model through Binding Context
            TimeSlot model = cell.BindingContext as TimeSlot;

            // thus, we know what the listview item index is
            // the TimeSlot in that position is:  rList[model.index]

            if (e.Value == true) // if the class switch is true, disable the other switch
            {
                mList[model.index].OtherBusyEnabled = false;
            }
            else // if we go into the else statement, we know that e.Value is false, so we enable the other switch
            {
                mList[model.index].OtherBusyEnabled = true;
            }

            // update the maxNumInstantiated
            // if the new index is greater than the current one, replace maxNumInstantiated with
            // the current index
            if (model.index > maxNumInstantiated)
            {
                maxNumInstantiated = model.index;
            }

            // re-enable this if you want a pop-up, in order to see what the values of the toggled
            // switch and listview cell are
            /*
            // then the toggles can be known for this specific one
            if (model != null)
            {
                DisplayAlert("Time chosen: ", "index: " + model.index + ", value of toggle: " + e.Value + ", value of other: " + rList[model.index].OtherBusyEnabled, "OK");
            }
            */

        }

        private void OtherSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            ViewCell cell = (sender as Switch).Parent.Parent as ViewCell;

            // find the model through Binding Context
            TimeSlot model = cell.BindingContext as TimeSlot;

            if (e.Value == true) // if the otherwiseBusy switch is true, disable the class switch
            {
                mList[model.index].ClassBusyEnabled = false;
            }
            else // if we go into the else statement, we know that e.Value is false, so we enable the other switch
            {
                mList[model.index].ClassBusyEnabled = true;
            }

            // update the maxNumInstantiated
            // if the new index is greater than the current one, replace maxNumInstantiated with
            // the current index
            if (model.index > maxNumInstantiated)
            {
                maxNumInstantiated = model.index;
            }


        }

        private async void btnClear_isClicked()
        {
            bool clearAll = await DisplayAlert("Clear", "Are you sure you wish to clear all times?", "Yes, please!", "No, don't do it!");
            // iterate through the list and reset all buttons and values
            for (int i = 0; i <= maxNumInstantiated; i++)
            {
                if (clearAll)
                {
                    // yes, they want to clear everything
                    mList[i].ClassAtThisTime = false;
                    mList[i].OtherwiseBusy = false;
                    mList[i].ClassBusyEnabled = true;
                    mList[i].OtherBusyEnabled = true;
                }
                else
                {
                    // no, they don't want to clear stuff
                }


            }
        }

        // ****************************************************************************************************

        /// <summary>
        /// takes care of the case in which the update button is clicked
        /// updates the database
        /// if the timeslot already exists, it updates it or deletes it as necessary
        /// if it doesn't already exist, it adds it if necessary
        /// </summary>
        private async void btnUpdate_isClicked()
        {
            UserAvailability availabilitySlot = new UserAvailability();
            availabilitySlot.Email = App.AccountEmail;
            availabilitySlot.Day = "Friday";

            for (int i = 0; i <= maxNumInstantiated; i++)
            {
                //  add the time to it
                availabilitySlot.Time = mList[i].StartTime; // gives the start time as a string

                // find out what type of activity it was, if it was neither, call it ""
                if (mList[i].ClassAtThisTime)
                {
                    // eventually, we can find out what this class is, but for now, just say
                    availabilitySlot.Activity = "class";
                }
                else if (mList[i].OtherwiseBusy)
                {
                    // call it busy
                    availabilitySlot.Activity = "busy";
                }
                else
                {
                    // we know that there's no activity
                    availabilitySlot.Activity = "";
                }

                // check if it exists (and create a list)
                List<UserAvailability> userAvailibilitiesList = await App.DatabaseManager.AvailabilityExists(availabilitySlot.Email, availabilitySlot.Day, availabilitySlot.Time);

                // if there is no existing availability slot like that, make one
                if (userAvailibilitiesList.Count == 0)
                {
                    // check if the availabilitySlot's activity is empty.. if it is, we don't need
                    // to bother adding availabilitySlot to the database
                    if (availabilitySlot.Activity != "")
                    {
                        // and then update the database with this availability slot
                        await App.DatabaseManager.AddAvailabilityAsync(availabilitySlot);
                    }
                }
                else
                {
                    // we know it already exists, so we just update it with the first thing in the list, which
                    // should be the only thing in the list
                    // although, if the new activity is "", we should just get it over with and delete
                    // the slot from the database
                    if (availabilitySlot.Activity == "")
                    {
                        await App.DatabaseManager.RemoveAvailabilityAsync(userAvailibilitiesList[0]);
                    }
                    else
                    {
                        await App.DatabaseManager.AlterActivityAsync(availabilitySlot, userAvailibilitiesList[0]);
                    }
                }
            }
        }

    }
}
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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Friday : ContentPage
    {
        // new List fList to hold all the values of TimeSlot
        public List<TimeSlot> fList = new List<TimeSlot> { };
        private int maxNumInstantiated = 0; // will count how many TimeSlot cells are available

        public Friday()
        {
            InitializeComponent();

            // creates all the TimeSlots and places them into cells which become the source for FridayList
            for (int i = 0; i < 23; i++)
            {
                fList.Add(new TimeSlot(i, i + 1, "Friday"));
            }
            fList.Add(new TimeSlot(23, 0, "Friday"));
            FridayList.ItemsSource = fList;

            InitialiseAvailability();
        }

        private async void InitialiseAvailability()
        {
            string[] times = new string[] {"12am", "1am", "2am", "3am", "4am", "5am", "6am", "7am", "8am", "9am", "10am", "11am",
                                            "12pm", "1pm", "2pm", "3pm", "4pm", "5pm", "6pm", "7pm", "8pm", "9pm", "10pm", "11pm"};

            for (int hour = 0; hour < 24; hour++)
            {
                List<UserAvailability> hourSlot = await App.DatabaseManager.AvailabilityExists(App.AccountEmail, "Friday", times[hour]);
                if (hourSlot.Count() > 0 && hourSlot[0].Activity != null && (hourSlot[0].Activity == "Busy" || hourSlot[0].Activity == "Meeting"))
                {
                    fList[hour].OtherwiseBusy = true;
                    fList[hour].ClassBusyEnabled = false;
                }
                else if (hourSlot.Count() > 0)
                {
                    fList[hour].OtherBusyEnabled = false;
                    fList[hour].ClassAtThisTime = true;
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
                fList[model.index].OtherBusyEnabled = false;
            }
            else // if we go into the else statement, we know that e.Value is false, so we enable the other switch
            {
                fList[model.index].OtherBusyEnabled = true;
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
                fList[model.index].ClassBusyEnabled = false;
            }
            else // if we go into the else statement, we know that e.Value is false, so we enable the other switch
            {
                fList[model.index].ClassBusyEnabled = true;
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
                    fList[i].ClassAtThisTime = false;
                    fList[i].OtherwiseBusy = false;
                    fList[i].ClassBusyEnabled = true;
                    fList[i].OtherBusyEnabled = true;
                }

            }
        }

        // if update button is clicked, update the database with the time, date
        
        private async void btnUpdate_isClicked()
        {

           UserAvailability availabilitySlot = new UserAvailability();
            availabilitySlot.Email = App.AccountEmail;
            availabilitySlot.Day = "Friday";
            
            availabilitySlot.Activity = "";
            int length = 0;
            
            for (int i = 0; i <= maxNumInstantiated; i++)
            {
                //  add the time to it
                availabilitySlot.Time = fList[i].StartTime; // gives the start time as a string

                // find out what type of activity it was, if it was neither, call it ""
                if (fList[i].ClassAtThisTime)
                {
                    // eventually, we can find out what this class is, but for now, just say
                    availabilitySlot.Activity = "class";
                }
                else if (fList[i].OtherwiseBusy)
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
                List<UserAvailability> userAvailibilitiesList= await App.DatabaseManager.AvailabilityExists(availabilitySlot.Email, availabilitySlot.Day, availabilitySlot.Time);
                //List<UserAvailability> testing;

                length = userAvailibilitiesList.Count();

                // if there is no existing availability slot like that, make one
                if (userAvailibilitiesList.Count == 0)
                {
                    // check if the availabilitySlot's activity is empty.. if it is, we don't need
                    // to bother adding availabilitySlot to the database
                    if(availabilitySlot.Activity != "")
                    {
                        // and then update the database with this availability slot
                        await App.DatabaseManager.AddAvailabilityAsync(availabilitySlot);
                        // for testing purposes

                        //testing = await App.DatabaseManager.AvailabilityExists(availabilitySlot.Email, availabilitySlot.Day, availabilitySlot.Time);
                        //await DisplayAlert("Mwahaha", "i just added an availability slot... I think" + testing[0].Activity, "No, don't do it!");
                    }
                }
                else
                {
                    // we know it already exists, so we just update it with the first thing in the list, which
                    // should be the only thing in the list
                    // although, if the new activity is "", we should just get it over with and delete
                    // the slot from the database
                    if(availabilitySlot.Activity == "")
                    {
                        
                        //await DisplayAlert("Mwahaha", "removing availability" , "No, don't do it!");
                        await App.DatabaseManager.RemoveAvailabilityAsync(userAvailibilitiesList[0]);
                    }
                    else
                    {
                        await App.DatabaseManager.AlterActivityAsync(availabilitySlot, userAvailibilitiesList[0]);
                        //testing = await App.DatabaseManager.AvailabilityExists(availabilitySlot.Email, availabilitySlot.Day, availabilitySlot.Time);
                        //await DisplayAlert("Mwahaha", "i just added an availability slot... I think" + testing[0].Activity, "No, don't do it!");
                    }
                }
                
            }

            
        }
        
    }
}
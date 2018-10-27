using Collaboro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;

namespace Collaboro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Saturday : ContentPage
    {
        public List<TimeSlot> dayList = new List<TimeSlot>();   // Holds TimeSlots for each hour
        private string dayName = "Saturday";
        private int pendingSubjectIndex;

        /// <summary>
        /// Day constructor which generates the page and initialises relevant variables
        /// </summary>
        public Saturday()
        {
            InitializeComponent();

            OnStart();
        }

        /// <summary>
        /// Sets up the ListView with options, and changes options to match existing data
        /// Run inside the constructor only
        /// </summary>
        private async void OnStart()
        {
            SaturdayList.ItemsSource = AvailabilityFunctions.InitialiseDayList(dayList, dayName);

            await AvailabilityFunctions.InitialiseAvailability(dayList, dayName);
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
        private async void ClassSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            ViewCell cell = (sender as Switch).Parent.Parent as ViewCell;

            // Find the model through Binding Context
            TimeSlot model = cell.BindingContext as TimeSlot;

            // Thus, we know what the listview item index is
            // the TimeSlot in that position is:  dayList[model.index]

            if (e.Value == true) // If the class switch is true, disable the other switch
            {
                if (await NotExistingClass(model))
                {
                    dayList[model.index].OtherBusyEnabled = false;
                    pendingSubjectIndex = model.index;
                    popupSubject.IsVisible = true;
                }
            }
            else // If we go into the else statement, we know that e.Value is false, so we enable the other switch
            {
                dayList[model.index].OtherBusyEnabled = true;
            }
        }

        /// <summary>
        /// Checks to see whether a class already exists for a given time.
        /// Used to check if a slider was changed by code or by the user.
        /// </summary>
        /// <returns></returns>
        private async Task<bool> NotExistingClass(TimeSlot model)
        {
            string[] times = new string[] {"12am", "1am", "2am", "3am", "4am", "5am", "6am", "7am", "8am", "9am", "10am", "11am",
                                            "12pm", "1pm", "2pm", "3pm", "4pm", "5pm", "6pm", "7pm", "8pm", "9pm", "10pm", "11pm"};
            string selectedTime = times[dayList.IndexOf(model)];

            List<UserAvailability> hourSlot = await App.DatabaseManager.AvailabilityExists(App.AccountEmail, dayName, selectedTime);
            if (hourSlot.Count() > 0 && hourSlot[0].Activity != null && !(hourSlot[0].Activity == "Busy" || hourSlot[0].Activity == "Meeting"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// If the OtherSwitch (the right one) is toggled, this method is called
        /// Pre: OtherSwitch is toggled
        /// Post: Disables the class switch if OtherSwitch is toggled to be true,
        ///         if OtherSwitch is toggled to be false, re-enables the other
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OtherSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            ViewCell cell = (sender as Switch).Parent.Parent as ViewCell;

            // Find the model through Binding Context
            TimeSlot model = cell.BindingContext as TimeSlot;

            if (e.Value == true) // If the otherwiseBusy switch is true, disable the class switch
            {
                dayList[model.index].ClassBusyEnabled = false;
            }
            else // If we go into the else statement, we know that e.Value is false, so we enable the other switch
            {
                dayList[model.index].ClassBusyEnabled = true;
            }
        }

        /// <summary>
        /// Clears the TimeSlots, toggles and database entries for the day
        /// </summary>
        private async void btnClear_isClicked()
        {
            bool clearAll = await DisplayAlert("Clear", "Are you sure you wish to clear all times?", "Yes, please!", "No, don't do it!");

            if (clearAll)
            {
                dayList = await AvailabilityFunctions.ClearButton(dayList, dayName);
            }
        }

        /// <summary>
        /// Takes care of the case in which the update button is clicked
        /// updates the database
        /// if the timeslot already exists, it updates it or deletes it as necessary
        /// if it doesn't already exist, it adds it if necessary
        /// </summary>
        private async void btnUpdate_isClicked()
        {
            dayList = await AvailabilityFunctions.UpdateButton(dayList, dayName);
        }

        /// <summary>
        /// Submits the subject code entered into the text entry
        /// Changes the label requesting a valid input if provided input is invalid
        /// </summary>
        private void SubjectSubmitBtn_Clicked()
        {
            Regex subjectCode = new Regex(@"^[A-Z]{3}[0-9]{3}$");

            if (SubjectEntry.Text != null && subjectCode.IsMatch(SubjectEntry.Text))
            {
                dayList[pendingSubjectIndex].subjectCode = SubjectEntry.Text;
                popupSubject.IsVisible = false;
            }
            else
            {
                SubjectLabel.Text = "Please enter a valid subject code.";
            }
        }

        /// <summary>
        /// Exits the enter subject text input box and unselects the slider chosen
        /// </summary>
        private void SubjectCancelBtn_Clicked()
        {
            dayList[pendingSubjectIndex].ClassAtThisTime = false;
            dayList[pendingSubjectIndex].OtherBusyEnabled = true;
            popupSubject.IsVisible = false;
        }
    }
}
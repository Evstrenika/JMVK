﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Collaboro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tuesday : ContentPage
    {
        // new List rList to hold all the values of TimeSlot
        public List<TimeSlot> tList = new List<TimeSlot> { };
        private int maxNumInstantiated = 0; // will count how many TimeSlot cells are available

        public Tuesday()
        {
            InitializeComponent();

            // creates all the TimeSlots and places them into cells which become the source for ThursdayList
            for (int i = 0; i < 23; i++)
            {
                tList.Add(new TimeSlot(i, i + 1));
            }
            tList.Add(new TimeSlot(23, 0));
            TuesdayList.ItemsSource = tList;
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
                tList[model.index].OtherBusyEnabled = false;
            }
            else // if we go into the else statement, we know that e.Value is false, so we enable the other switch
            {
                tList[model.index].OtherBusyEnabled = true;
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
                tList[model.index].ClassBusyEnabled = false;
            }
            else // if we go into the else statement, we know that e.Value is false, so we enable the other switch
            {
                tList[model.index].ClassBusyEnabled = true;
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
                    tList[i].ClassAtThisTime = false;
                    tList[i].OtherwiseBusy = false;
                    tList[i].ClassBusyEnabled = true;
                    tList[i].OtherBusyEnabled = true;
                }


            }
        }
    }
}

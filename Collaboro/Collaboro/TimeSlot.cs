using Collaboro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Collaboro
{
    public class TimeSlot : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private string startTime { get; set; }
        public string StartTime { get; set; }

        public string endTime { get; set; }
        public string startAndEnd { get; set; }
        public string color { get; set; }
        public int index { get; set; }

        public string subjectCode { get; set; }

        /// <summary>
        /// used to tell if the classBusy switch is true or not
        /// </summary>
        private bool classAtThisTime { get; set; }
        public bool ClassAtThisTime
        {
            get
            {
                return classAtThisTime;
            }
            set
            {
                classAtThisTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ClassAtThisTime"));
            }
        }


        /// <summary>
        /// used to tell if the otherwiseBusy switch is true or not
        /// </summary>
        private bool otherwiseBusy;
        public bool OtherwiseBusy
        {
            get
            {
                return otherwiseBusy;
            }
            set
            {
                otherwiseBusy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OtherwiseBusy"));
            }
        }

        /// <summary>
        /// used to tell if the class switch is enabled
        /// </summary>
        private bool classBusyEnabled;
        public bool ClassBusyEnabled
        {
            get
            {
                return classBusyEnabled;
            }
            set
            {
                classBusyEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ClassBusyEnabled"));
            }
        }

        /// <summary>
        /// used to tell if the otherwiseBusy switch should be enabled or not
        /// </summary>
        private bool otherBusyEnabled;
        public bool OtherBusyEnabled
        {
            get
            {
                return otherBusyEnabled;
            }
            set
            {
                otherBusyEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OtherBusyEnabled"));
            }
        }

        /// <summary>
        /// Constructor for TimeSlot that takes in a start and end time
        /// and turns them into an actual sentence and also stores them
        /// in this object of TimeSlot
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public TimeSlot(int start, int end, string day)
        {
            // check if the start time has am or pm behind it and assign it appropriately
            // if you don't want am or pm, just use the following and comment the rest out
            // startTime = start;
            startTime = amOrPmWithTime(start);

            // endTime - the same as for startTime
            // endTime = end;
            endTime = amOrPmWithTime(end);
            startAndEnd = "From " + startTime + " to " + endTime;
            color = "LightBlue";
            index = start;
            classAtThisTime = false;
            otherwiseBusy = false;
            otherBusyEnabled = true;
            classBusyEnabled = true;

            // check if this time slot already exists, and do fix the buttons appropriately
            ExistsInDB(day);
        }   // end of TimeSlot constructor

        /// <summary>
        /// Should not be called, but is there just in case
        /// </summary>
        public TimeSlot()
        {
            startTime = amOrPmWithTime(0);
            endTime = amOrPmWithTime(0);
            startAndEnd = "From " + startTime + " to " + endTime;
            color = "LightBlue";
        }   // end TimeSlot constructor

        private string amOrPmWithTime(int time)
        {
            string correctTime = "";
            if (time > 12)
            {
                correctTime = (time - 12) + "pm";
            }
            else if (time == 0)
            {
                correctTime = "12am";
            }
            else if (time == 12)
            {
                correctTime = "12pm";
            }
            else
            {
                correctTime = time + "am";
            }
            return correctTime;
        }   // end amOrPmWithTime


        // figure out the database thingy
        private async void ExistsInDB(string day)
        {
            List<UserAvailability> hourSlot = await App.DatabaseManager.AvailabilityExists(App.AccountEmail, day, StartTime);
            if (hourSlot.Count > 0 && hourSlot[0].Activity != null && (hourSlot[0].Activity == "Busy" || hourSlot[0].Activity == "Meeting"))
            {
                OtherBusyEnabled = true;
                ClassBusyEnabled = false;
            }
            else if (hourSlot.Count > 0)
            {
                OtherBusyEnabled = false;
                ClassBusyEnabled = true;
            }
        }
    }


}   // end class TimeSlot
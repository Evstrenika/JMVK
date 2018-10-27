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
    public partial class BookMeetingTwo : ContentPage
    {
        private Group selected;

        /// <summary>
        /// Creates a BookMeetingTwo page and assigns the group to a private variable
        /// </summary>
        /// <param name="group"></param>
        public BookMeetingTwo(Group group)
        {
            InitializeComponent();
            selected = group;
        }

        /// <summary>
        /// Takes the user to the next part of the booking process with the inputs provided as parameters
        /// </summary>
        private async void OnSubmit()
        {
            string MinimumTime = (MinTime.SelectedIndex == -1) ? "12am" : MinTime.SelectedItem.ToString();
            string MaximumTime = (MaxTime.SelectedIndex == -1) ? "11pm" : MaxTime.SelectedItem.ToString();

            await Navigation.PushAsync(new BookMeetingThree(selected, stepper.Value, MinimumTime, MaximumTime));
        }
    }
}
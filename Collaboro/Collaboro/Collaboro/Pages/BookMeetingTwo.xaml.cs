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
        public BookMeetingTwo(Group group)
        {
            InitializeComponent();
        }

        private async void OnSubmit()
        {
            string MinimumTime = (MinTime.SelectedIndex == -1) ? "8am" : MinTime.SelectedItem.ToString();
            string MaximumTime = (MaxTime.SelectedIndex == -1) ? "9pm" : MaxTime.SelectedItem.ToString();

            await Navigation.PushAsync(new BookMeetingThree(stepper.Value, MinimumTime, MaximumTime));
        }
    }
}
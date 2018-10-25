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

        public BookMeetingTwo(Group group)
        {
            InitializeComponent();
            selected = group;
        }

        private async void OnSubmit()
        {
            string MinimumTime = (MinTime.SelectedIndex == -1) ? "12am" : MinTime.SelectedItem.ToString();
            string MaximumTime = (MaxTime.SelectedIndex == -1) ? "11pm" : MaxTime.SelectedItem.ToString();

            await Navigation.PushAsync(new BookMeetingThree(selected, stepper.Value, MinimumTime, MaximumTime));
        }
    }
}
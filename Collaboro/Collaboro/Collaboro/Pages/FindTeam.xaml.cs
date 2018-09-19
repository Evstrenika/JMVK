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
    public partial class FindTeam : ContentPage
    {
        public FindTeam()
        {
            InitializeComponent();
        }

        private async void OnSubmit()
        {
            string code = Code.Text;
            bool tuteDay = Day.SelectedIndex != -1;
            bool tuteTime = Time.SelectedIndex != -1;
            if (tuteDay && tuteTime)
            {
                await Navigation.PushAsync(new HomePage()); // To Replace
            }
        }
    }
}
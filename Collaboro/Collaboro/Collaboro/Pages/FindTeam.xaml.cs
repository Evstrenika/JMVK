using Collaboro.Pages;
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
                List<string> skillStringList = new List<string>();
                // TO DO: CONVERT LINES OF TEXT ENTRY TO ENTRIES IN LIST
                await Navigation.PushAsync(new FindTeamTwo(Code.Text, Day.SelectedItem.ToString(), Time.SelectedItem.ToString(), (int)stepper.Value, skillStringList));
            }
        }
    }
}
using Collaboro.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
            Regex subjectCode = new Regex(@"^[A-Z]{3}[0-9]{3}$");
            Regex skillsList = new Regex(@"^(([A-Za-z]+\s?)+(\n|\r|\r\n)?)+$", RegexOptions.IgnoreCase);

            bool code = Code.Text != null && subjectCode.IsMatch(Code.Text);
            bool tuteDay = Day.SelectedIndex != -1;
            bool tuteTime = Time.SelectedIndex != -1;
            bool skillList = Skills.Text == null || skillsList.IsMatch(Skills.Text);

            // Check all of the fields have been entered and are in the correct format
            if (code && tuteDay && tuteTime && skillList)
            {
                string[] list = Regex.Split(Skills.Text, "\r\n");
                await Navigation.PushAsync(new FindTeamTwo(Code.Text, Day.SelectedItem.ToString(), Time.SelectedItem.ToString(), (int)stepper.Value, list));
            }
            else
            {
                // Show an error message
                Error.IsVisible = true;
                if (!code)
                {
                    Error.Text = "Please enter a subject code with 3 uppercase letters and 3 numbers";
                }
                else if (!tuteDay)
                {
                    Error.Text = "Please select a tutorial day";
                }
                else if (!tuteTime)
                {
                    Error.Text = "Please select a tutorial time";
                }
                else if (!skillList)
                {
                    Error.Text = "Please enter skills in text only and seperate different skills with Enter";
                }
            }
        }
    }
}
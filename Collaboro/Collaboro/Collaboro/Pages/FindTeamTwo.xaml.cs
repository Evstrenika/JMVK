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
    public partial class FindTeamTwo : ContentPage
    {
        public FindTeamTwo(string code, string day, string time, int members, string[] skills)
        {
            InitializeComponent();
            // A suggestion for the scrolling options
            // https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.listview?view=xamarin-forms
        }

        // When user is clicked
        // private async void CommandName()
        // await Navigation.PushAsync(new FindTeamThree(userID));
    }
}
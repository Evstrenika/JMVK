using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Collaboro {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage {
        public LogInPage()
        {
            InitializeComponent();
        }

        private async void logInButton_Clicked()
        {
            string email = emailAddressEntry.Text;
            string pass = passwordEntry.Text;
            if (emailIsValid(email) && passIsValid(pass))
            {
                await Navigation.PushAsync(new HomePage()); // To Replace
            }
            else
            {
                await Navigation.PushAsync(new LogInPage());    // to replace
            }
        }

        // returns true if the email fed to it is valid
        // still needs some work
        public bool emailIsValid(string email)
        {
            if(email != null && email.Contains("@"))
            {
                return true;
            }
            return false;
        }

        // returns true if the password fed to it is valid
        // still needs some work
        public bool passIsValid(string pass)
        {
            if(pass != null)
            {
                return true;
            }
            return false;
        }
    }
}
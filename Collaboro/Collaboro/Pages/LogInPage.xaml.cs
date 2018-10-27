using Collaboro.Models;
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

        /// <summary>
        /// Create the LoginPage
        /// </summary>
        public LogInPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Validates the inputs provided. Displays an error if they are invalid
        /// and logs the user in if they are valid.
        /// </summary>
        private async void logInButton_Clicked()
        {
            string email = emailAddressEntry.Text;
            string pass = passwordEntry.Text;
            if (emailIsValid(email) && passIsValid(pass))
            {
                Student student = await App.DatabaseManager.CheckCredentialsStudentAsync(email, pass);
                if (student == null)
                {
                    await DisplayAlert("Incorrect Login", "The email or password is incorrect. Please try again.", "OK");
                }
                else
                {
                    await Navigation.PushAsync(new HomePage(email));
                }
            }
            else
            {
                await DisplayAlert("Incorrect Login", "The email or password is incorrect. Please try again.", "OK");
            }
        }

        /// <summary>
        /// Checks if the email provided is valid
        /// </summary>
        /// <param name="email">Entered email</param>
        /// <returns>True if email is valid</returns>
        public bool emailIsValid(string email)
        {
            if(email != null && email.Contains("@"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the password provided is valid
        /// </summary>
        /// <param name="pass">Entered password</param>
        /// <returns>True if password is valid</returns>
        public bool passIsValid(string pass)
        {
            if (pass != null && pass.Length > 4)
            {
                return true;
            }
            return false;
        }
    }
}
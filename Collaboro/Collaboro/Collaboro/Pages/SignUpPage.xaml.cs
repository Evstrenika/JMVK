using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Collaboro {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void signUpButton_Clicked()
        {
            // fields and entries
            
            if (IsValid())
            {
                // keep going to the next page
                // save the information in the DB
            }
            else
            {
                // something is not valid, so respond to the validation
            }
            await Navigation.PushAsync(new LogInPage());    // to replace
        }

        // checks if everything is valid and returns true if it is
        public bool IsValid()
        {
            string firstName = firstNameEntry.Text;
            string surname = surnameEntry.Text;
            string email = emailAddressEntry.Text;
            string confirmEmail = confirmEmailAdressEntry.Text;
            string pass = passwordEntry.Text;
            string confirmPass = confirmPasswordEntry.Text;
            int uni = universityPicker.SelectedIndex;
            bool tc = acceptTC.IsToggled;

            if (firstNameValid(firstName) && surnameValid(surname) && emailValid(email, confirmEmail)
                && passwordValid(pass, confirmPass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // needs some work
        // checks if the first name is valid
        public bool firstNameValid(string firstName)
        {
            if(firstName != null)
            {
                return true;
            }
            return false;
        }

        // needs some work
        // checks if the surname name is valid
        public bool surnameValid(string surname)
        {
            if (surname != null)
            {
                return true;
            }
            return false;
        }

        // needs some work
        // checks if the email & confirmation email are valid
        public bool emailValid(string email, string confirmEmail)
        {
            if (email != null && email == confirmEmail)
            {
                return true;
            }
            return false;
        }

        // needs some work
        // checks if the surname name is valid
        public bool passwordValid(string pass, string confirmPass)
        {
            if (pass != null && pass == confirmPass)
            {
                return true;
            }
            return false;
        }

    }
}
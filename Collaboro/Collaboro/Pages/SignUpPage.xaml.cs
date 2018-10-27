using Collaboro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Collaboro {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage {

        /// <summary>
        /// Creates the SignUpPage
        /// </summary>
        public SignUpPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// If the sign up button is clicked, inputs are validated
        /// If inputs are valid, account is created and user is taken to home screen
        /// If inputs are valid but email is already in use, user is taken to the login screen
        /// </summary>
        private async void signUpButton_Clicked()
        {
            var student = (Student)BindingContext;

            if (IsValid())
            {
                // If email already signed up, take to Login page
                if (App.DatabaseManager.ReturnStudentAsync(emailAddressEntry.Text) != null)
                {
                    await DisplayAlert("Existing Account", "This email is already registered. Taking you to the login page...", "OK");
                    await Navigation.PushAsync(new LogInPage());
                }
                else
                {
                    await App.DatabaseManager.RecordStudentAsync(student);
                    await Navigation.PushAsync(new HomePage(emailAddressEntry.Text));
                }
            }
        }

        /// <summary>
        /// Checks the provided inputs are valid
        /// Provides a relevant error message if they are not.
        /// </summary>
        /// <returns>True if all inputs are valid</returns>
        public bool IsValid()
        {
            Regex firstNameRegex = new Regex(@"^([A-Z][a-z]+)(-[A-Z][a-z]+)?$");
            Regex surnameRegex = new Regex(@"^([A-Z][A-Za-z]+)(-[A-Z][A-Za-z]+)?$");
            Regex emailRegex = new Regex(@"^[A-Za-z0-9!#$%^&*]+[@][A-Za-z]+[.][A-Za-z.]+$");

            if (firstNameEntry.Text == null || !firstNameRegex.IsMatch(firstNameEntry.Text))
            {
                Error.Text = "Please enter your name using correct punctuation.";
                Error.IsVisible = true;
                return false;
            }
            else if (surnameEntry.Text == null || !surnameRegex.IsMatch(surnameEntry.Text))
            {
                Error.Text = "Please enter your surname using correct punctuation.";
                Error.IsVisible = true;
                return false;
            }
            else if (emailAddressEntry.Text == null || confirmEmailAdressEntry.Text == null || 
                        emailAddressEntry.Text != confirmEmailAdressEntry.Text || !emailRegex.IsMatch(emailAddressEntry.Text))
            {
                Error.IsVisible = true;
                if (emailAddressEntry.Text != confirmEmailAdressEntry.Text)
                {
                    Error.Text = "Emails do not match.";
                }
                else
                {
                    Error.Text = "Please enter a valid email address.";
                }
                return false;
            }
            else if (passwordEntry.Text == null || confirmPasswordEntry.Text == null ||
                passwordEntry.Text != confirmPasswordEntry.Text || passwordEntry.Text.Length < 5)
            {
                Error.IsVisible = true;
                if (passwordEntry.Text != confirmPasswordEntry.Text)
                {
                    Error.Text = "Passwords do not match.";
                }
                else
                {
                    Error.Text = "Password must be at least 5 characters long.";
                }
                return false;
            }
            else if (universityPicker.SelectedIndex == -1)
            {
                Error.Text = "Please select a university from the drop down.";
                Error.IsVisible = true;
                return false;
            }
            else if (acceptTC.IsToggled == false)
            {
                Error.Text = "Please accept the terms and conditions to continue.";
                Error.IsVisible = true;
                return false;
            }

            return true;
        }
    }
}
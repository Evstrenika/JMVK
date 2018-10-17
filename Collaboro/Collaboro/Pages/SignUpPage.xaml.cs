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
    public partial class SignUpPage : ContentPage {
        public SignUpPage()
        {
            InitializeComponent();
        }

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
                    await Navigation.PushAsync(new HomePage());
                }
            }
            else
            {
                // something is not valid, so respond to the validation
            }
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

        private void submitButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}
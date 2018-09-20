using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Collaboro
{
    public class ViewModel
    {
        // Initialise Variables
        private PageNavigationManager navManager;

        public ICommand FindTeamButtonClick { protected set; get; }
        public ICommand BookMeetingClick { protected set; get; }
        public ICommand AvailabilityClick { protected set; get; }
        public ICommand ProfileClick { protected set; get; }

        public ICommand SignUpButtonClicked { protected set; get; }
        public ICommand LogInButtonClicked { protected set; get; }
        public ICommand SubmitToHome { protected set; get; }

        public ViewModel()
        {
            // Home Page Commands

            navManager = PageNavigationManager.Instance;

            FindTeamButtonClick = new Command(() =>
            {
                navManager.ShowFindTeamPage();
            });

            BookMeetingClick = new Command(() =>
            {
                navManager.ShowFindTeamPage();  // Needs updating
            });

            AvailabilityClick = new Command(() =>
            {
                navManager.ShowFindTeamPage();  // Needs updating
            });

            ProfileClick = new Command(() =>
            {
                navManager.ShowFindTeamPage();  // Needs updating
            });


            // Log In and Sign Up Commands

            SignUpButtonClicked = new Command(() => 
            {
                navManager.ShowSignUpPage();  
            });

            LogInButtonClicked = new Command(() => 
            {
                navManager.ShowLogInPage();  
            });

            SubmitToHome = new Command(() => {
                navManager.ShowHomePage();
            });
        }

    }

}

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
        public ICommand SignUpButtonClicked { protected set; get; }
        public ICommand LogInButtonClicked { protected set; get; }
        public ICommand SubmitSignUpButtonClicked { protected set; get; }
        public ICommand SubmitLogInButtonClicked { protected set;  get; }

        public ViewModel()
        {
            navManager = PageNavigationManager.Instance;

            FindTeamButtonClick = new Command(() =>
            {
                navManager.ShowFindTeamPage();
            });

            BookMeetingClick = new Command(() =>
            {
                navManager.ShowFindTeamPage();  // Needs updating
            });

            SignUpButtonClicked = new Command(() => 
            {
                navManager.ShowSignUpPage();  
            });

            
            LogInButtonClicked = new Command(() => 
            {
                navManager.ShowLogInPage();  
            });

            SubmitSignUpButtonClicked = new Command(() => {
                navManager.ShowHomePage();
            });

            SubmitLogInButtonClicked = new Command(() => {
                navManager.ShowHomePage();
            });
        }

    }

}

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
        public ICommand SignUpButton_Clicked { protected set; get; }
        public ICommand SubmitSignUpButton_Clicked { protected set; get; }
        public Command SubmitLogInButton_Clicked { protected set;  get; }

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

            SignUpButton_Clicked = new Command(() => 
            {
                navManager.ShowSignUpPage();  
            });

            SubmitSignUpButton_Clicked = new Command(() => 
            {
                navManager.ShowLogInPage();  
            });

            SubmitSignUpButton_Clicked = new Command(() => {
                navManager.ShowHomePage();
            });

            SubmitLogInButton_Clicked = new Command(() => {
                navManager.ShowHomePage();
            });
        }

    }

}

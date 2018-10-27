using Collaboro.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Collaboro
{
    public class PageNavigationManager
    {
        // Initialise Variables
        private static PageNavigationManager instance;
        private PageNavigationManager() { }
        private INavigation navigation;


        /// <summary>
        /// Creates an instance of the PageNavigationManager if one does not already exist
        /// </summary>
        public static PageNavigationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PageNavigationManager();
                }
                return instance;
            }
        }

        public INavigation Navigation
        {
            set { navigation = value; }
        }

        /// <summary>
        /// Shows FindTeam.Xaml
        /// </summary>
        public void ShowFindTeamPage()
        {
            navigation.PushAsync(new FindTeam());
        }

        /// <summary>
        /// Shows BookMeeting.Xaml
        /// </summary>
        public void ShowBookMeetingPage()
        {
            navigation.PushAsync(new BookMeeting());
        }

        /// <summary>
        /// Shows SignUpPage.Xaml
        /// </summary>
        public void ShowSignUpPage() {
            navigation.PushAsync(new SignUpPage());
        }

        /// <summary>
        /// Shows LogInPage.Xaml
        /// </summary>
        public void ShowLogInPage() {
            navigation.PushAsync(new LogInPage());
        }

        /// <summary>
        /// Shows AvailabilityPage.Xaml
        /// </summary>
        public void ShowAvailabilityPage()
        {
            navigation.PushAsync(new AvailabilityPage());
        }

        /// <summary>
        /// Sends the user back to the home page
        /// </summary>
        /// <param name="email"></param>
        public void SubmitToHome(string email)
        {
            navigation.PushAsync(new HomePage(email));
        }
    }
}

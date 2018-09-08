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

        public ViewModel()
        {
            navManager = PageNavigationManager.Instance;

            FindTeamButtonClick = new Command(() =>
            {
                navManager.ShowFindTeamPage();
            });
        }

    }
}

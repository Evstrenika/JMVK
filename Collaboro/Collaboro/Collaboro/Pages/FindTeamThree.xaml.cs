using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Collaboro.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindTeamThree : ContentPage
    {
        public FindTeamThree()
        {
            InitializeComponent();
            // Set title based on user's name
        }

        private void OnSubmit()
        {
            if (SubmitBtn.Text == "Invite to Team")
            {
                SubmitBtn.Text = "Undo Invitation";
                FinishedBtn.IsVisible = true;
                // TO DO: ADD TO DATABASE
            }
            else
            {
                SubmitBtn.Text = "Invite to Team";
                // TO DO: REMOVE FROM DATABASE
            }
        }
    }
}
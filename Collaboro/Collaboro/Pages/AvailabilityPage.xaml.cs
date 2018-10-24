using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Collaboro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AvailabilityPage : TabbedPage
    {
        public AvailabilityPage()
        {
            InitializeComponent();
        }

       // addToTable(currentlySelectedTimes)
    }
}
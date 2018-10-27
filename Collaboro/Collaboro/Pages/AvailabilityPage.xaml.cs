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
        /// <summary>
        /// Creates an availability page, including loading in the tabs located in the Weekdays folder
        /// </summary>
        public AvailabilityPage()
        {
            InitializeComponent();
        }

    }
}
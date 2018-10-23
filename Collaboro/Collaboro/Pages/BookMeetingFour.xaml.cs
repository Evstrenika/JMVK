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
    public partial class BookMeetingFour : ContentPage
    {
        public BookMeetingFour(string day, double length, string startTime)
        {
            InitializeComponent();
        }
    }
}
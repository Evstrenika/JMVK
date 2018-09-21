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
    public partial class BookMeeting : ContentPage
    {
        public BookMeeting()
        {
            InitializeComponent();
        }

        /*
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var items = await App.TodoManager.GetTasksAsync();
            groupsList.ItemsSource = items;
            App.TodoManager.CurrentItems = items;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var todoItem = e.SelectedItem as TodoItem;
            var MeetingTwo = new BookMeetingTwo(int ID);  // Get ID?
            todoPage.BindingContext = todoItem;
            Navigation.PushAsync(MeetingTwo);
        }*/
    }
}
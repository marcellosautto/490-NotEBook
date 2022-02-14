using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotEBookDesktop
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Calendar : Window
    {
        public Calendar()
        {
            InitializeComponent();
        }

        private void EnterEvent_Click(object sender, RoutedEventArgs e)
        {
            //Check if EventDate and EventTextBox is empty, if so throw an error to user
            if(EventDate.SelectedDate == null)
            {
                MessageBox.Show("No date has been picked", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(String.IsNullOrEmpty(EventTextBox.Text))
            {
                MessageBox.Show("No Event added in Textbox", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            //If both have entrys then push to EventView and clear entrys
            else
            {
                //add events
                EventItem E = new EventItem();
                E.Date = EventDate.SelectedDate.Value.ToString("MM/dd/yyyy");
                E.Event = EventTextBox.Text.ToString();

                //push event to listview
                EventList.Items.Add(E);
                //clear entrys form EventDate and EventTextBox
                EventDate.SelectedDate = null;
                EventTextBox.Text = String.Empty;
            }
        }

        private void RemoveEvent_Click(object sender, RoutedEventArgs e)
        {
            //Get a copy of list of selected items, otherwise we are iterating through a modified list and program will throw an error and crash and die and thats bad
            ListView EventListCopy = new ListView();
            foreach (EventItem eachItem in EventList.SelectedItems)
            {
                EventListCopy.Items.Add(eachItem);
            }
            //Using the copy, remove the selected items
            foreach (EventItem eachItem in EventListCopy.Items)
            {
                EventList.Items.Remove(eachItem);
            }
        }
    }
}

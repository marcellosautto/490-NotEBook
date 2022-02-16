using System;
using System.Windows;

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
            if (EventDate.SelectedDate == null)
            {
                MessageBox.Show("No date has been picked", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (String.IsNullOrEmpty(EventTextBox.Text))
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
            //See which Index is slecected to be removed
            if (EventList.SelectedIndex == -1)
            {
                //do nothing
            }
            else
            {
                //EventList.Items.Remove(EventList.SelectedIndex); DOSEN'T WORK



                //remove selected index THIS CAUSES A CRASH TO DESKTOP
                //foreach (ListViewItem eachItem in EventList.SelectedItems)
                //{
                //    EventList.Items.Remove(eachItem);
                //}
            }
        }
    }
}

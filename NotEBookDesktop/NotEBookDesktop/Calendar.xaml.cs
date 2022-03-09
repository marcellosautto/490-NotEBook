using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
//using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using Path = System.IO.Path;

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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //Save File Locally
            //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //Save List Locally onto machine, maybe push into DB if needed
            //using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Events")))
            using (StreamWriter outputFile = new StreamWriter("Events.ev"))
            {
                foreach (EventItem eachItem in EventList.Items)
                {
                    //write to file
                    outputFile.WriteLine(eachItem.Date + "\t" + eachItem.Event);
                }
            }
            MessageBox.Show("File Saved Successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            //Pull list from Local file, maybe pull from DB if needed
            //while we are not at the end of file, fill data and insert into 

            StringBuilder Date = new StringBuilder("");
            StringBuilder Event = new StringBuilder("");
            char c;
            bool isDate = true;
            
            //Clear EventList
            EventList.Items.Clear();
            try
            {
                //using (var sr = new StreamReader(Path.Combine(docPath, "Events")))
                using (var sr = new StreamReader("Events.ev"))
                {
                    while (sr.Peek() >= 0)// 0 is the EOF
                    {
                        c = (char)sr.Read();
                        //Read the stream, and write the string to EventList, first read until \t is found to push to Date Colounm, then read til \n to push to Event Colounm, repeat until EOF
                        if (c != '\t' && isDate)// Read date until we hit a \t char
                        {
                            Date.Append(c);
                        }
                        if (c == '\t' && isDate)// Set isDate to false and continue to Event
                        {
                            isDate = false;
                        }
                        if (c != '\n' && c != '\r' && !isDate)// Read Event until we hit \n char, the \r char ruins the formatting and adds unwanted whitespace, so we have to remove them from the string
                        {
                            Event.Append(c);
                        }
                        if (c == '\n' && !isDate)//Reset everything to prepare for the next line
                        {
                            EventItem E = new EventItem();
                            E.Date = Date.ToString();
                            E.Event = Event.ToString();
                            EventList.Items.Add(E);
                            isDate = true;
                            Date.Clear();
                            Event.Clear();
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Unable to load file: " + ex.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void LeftCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            //Filters events that have the selected dates
            //LeftCalendar.SelectedDates.Add();

        }
    }
}

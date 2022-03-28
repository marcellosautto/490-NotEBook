using Microsoft.Win32;
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
//using Path = System.IO.Path;
using System.ComponentModel;

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
            //lvwColumnSorter = new ListViewColumnSorter();

            //Sorting Items in EventView
            CollectionView EventView = (CollectionView)CollectionViewSource.GetDefaultView(EventList.Items);
            EventView.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Ascending));
            EventView.Refresh();
            //view.Filter = DateFilter;


            //Calendar Date Filtering
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(EventList.Items);
            view.Filter = DateFilter;
            //EventList.Items.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Ascending));
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }
        private void EnterEvent_Click(object sender, RoutedEventArgs e)
        {
            //Check if EventDate and EventTextBox is empty, if so throw an error to user
            if (EventDate.SelectedDate == null)
            {
                MessageBox.Show("No date has been picked", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (String.IsNullOrEmpty(EventTextBox.Text))
            {
                MessageBox.Show("No Event added in Textbox", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
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
            CollectionView EventView = (CollectionView)CollectionViewSource.GetDefaultView(EventList.Items);
            EventView.Refresh();
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
            CollectionView EventView = (CollectionView)CollectionViewSource.GetDefaultView(EventList.Items);
            EventView.Refresh();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //Save File Locally
            //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //Save List Locally onto machine, maybe push into DB if needed
            //using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Events")))

            if (EventList.Items.Count > 0)// Only save if we have a collection to save
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter= "NotEBook Events (*.ev)|*.ev";
                if (sf.ShowDialog() == true)
                {
                    using (StreamWriter outputFile = new StreamWriter(sf.FileName))
                    {
                        foreach (EventItem eachItem in EventList.Items)
                        {
                            //write to file
                            outputFile.WriteLine(eachItem.Date + "\t" + eachItem.Event);
                        }
                    }
                    MessageBox.Show("File Saved Successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
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
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "NotEBook Events(*.ev)| *.ev";
            if (od.ShowDialog() == true)
            {
                try
                {
                    //using (var sr = new StreamReader(Path.Combine(docPath, "Events")))
                    using (var sr = new StreamReader(od.FileName))
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
                        CollectionView EventView = (CollectionView)CollectionViewSource.GetDefaultView(EventList.Items);
                        EventView.Refresh();
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Unable to load file: " + ex.Message, "Couldn't Find File", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void LeftCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            //Filters events that have the selected dates
            //LeftCalendar.SelectedDates.Add();
            CollectionViewSource.GetDefaultView(EventList.Items).Refresh();
        }

        private void Calendar_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private bool DateFilter(object item)
        {
            if (LeftCalendar.SelectedDate == null) // no items selected
            {
                return true;
            }
            else
                return (item as EventItem).Date.Equals(LeftCalendar.SelectedDate.Value.ToString("MM/dd/yyyy"));
            
        }
    }
}

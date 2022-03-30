using Microsoft.Win32;
using System;
//Added
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Markup;


namespace NotEBookDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Controls.Image image;
        public MainWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            //SaveImg();
        }

        //function that allows you to drag the window around
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        //Escape closes the window
        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        // Set the EditingMode to ink input.
        private void Ink(object sender, RoutedEventArgs e)
        {
            theInkCanvas.EditingMode = InkCanvasEditingMode.Ink;

            // Set the DefaultDrawingAttributes for a red pen.
            theInkCanvas.DefaultDrawingAttributes.Color = Colors.Black;
            theInkCanvas.DefaultDrawingAttributes.IsHighlighter = false;
            theInkCanvas.DefaultDrawingAttributes.Height = 2;
        }

        // Set the EditingMode to highlighter input.
        private void Highlight(object sender, RoutedEventArgs e)
        {
            theInkCanvas.EditingMode = InkCanvasEditingMode.Ink;

            // Set the DefaultDrawingAttributes for a highlighter pen.
            theInkCanvas.DefaultDrawingAttributes.Color = Colors.Yellow;
            theInkCanvas.DefaultDrawingAttributes.IsHighlighter = true;
            theInkCanvas.DefaultDrawingAttributes.Height = 25;
        }

        // Set the EditingMode to erase by stroke.
        private void EraseStroke(object sender, RoutedEventArgs e)
        {
            theInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
        }

        // Set the EditingMode to selection.
        private void Select(object sender, RoutedEventArgs e)
        {
            theInkCanvas.EditingMode = InkCanvasEditingMode.Select;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Xaml files (*.Xaml)|*.Xaml";

            if (saveFileDialog1.ShowDialog() == true)
            {
                string save = XamlWriter.Save(theInkCanvas);
                File.WriteAllText(saveFileDialog1.FileName, save);
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XAML Files (*.xaml)|*.xaml";
            if (openFileDialog1.ShowDialog() == true)
            {
                theInkCanvas.Children.Clear();
                theInkCanvas.Strokes.Clear();

                var stream = File.OpenRead(openFileDialog1.FileName);
                InkCanvas tempCanvas = XamlReader.Load(stream) as InkCanvas;
                theInkCanvas.Strokes = tempCanvas.Strokes;

                while (tempCanvas.Children.Count > 0)
                {
                    UIElement element = tempCanvas.Children[0];
                    tempCanvas.Children.RemoveAt(0);
                    theInkCanvas.Children.Add(element);
                }
            }
        }
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter =
                "Image Files (*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if ((bool)dialog.ShowDialog())
            {
                image = new System.Windows.Controls.Image
                {
                    Source = new BitmapImage(new Uri(dialog.FileName)),
                    Width = 100
                };
                InkCanvas.SetLeft(image, 0);
                InkCanvas.SetTop(image, 0);
                theInkCanvas.Children.Add(image);
            }
        }

        private void OpenCalendar(object sender, RoutedEventArgs e)
        {
            Calendar cal = new Calendar();
            cal.Show();
        }

        private void OpenCalculator(object sender, RoutedEventArgs e)
        {
            Calculator Calc = new Calculator();
            Calc.Show();
        }

        private void Calculator_Click(object sender, RoutedEventArgs e)
        {
            // CODE HERE 
            Calculator calc = new Calculator();
            calc.Show();
        }
    }

}

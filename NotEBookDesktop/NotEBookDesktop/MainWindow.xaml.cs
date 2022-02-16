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
            // theInkCanvas.EditingMode = InkCanvasEditingMode.Select;
            theInkCanvas.EditingMode = InkCanvasEditingMode.None;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "isf files (*.isf)|*.isf";

            if (saveFileDialog1.ShowDialog() == true)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName,
                                               FileMode.Create);
                theInkCanvas.Strokes.Save(fs);

                string save = XamlWriter.Save(image);

                File.WriteAllText("test.Xaml", save);
                fs.Close();
            }


        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            //Outdated Load
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "isf files (*.isf)|*.isf";

            //if (openFileDialog1.ShowDialog() == true)
            //{
            //    FileStream fs = new FileStream(openFileDialog1.FileName,
            //                                   FileMode.Open);
            //    theInkCanvas.Strokes = new StrokeCollection(fs);
            //    fs.Close();
            //}
            //  OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //   openFileDialog1.Filter = "xaml files (*.xaml)|*.xaml";

            //FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);

            var stream = File.OpenRead("test.Xaml");
            image = XamlReader.Load(stream) as System.Windows.Controls.Image;
            theInkCanvas.Children.Add(image);

        }
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter =
                "Image Files (*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if ((bool)dialog.ShowDialog())
            {
                image = new System.Windows.Controls.Image
                {
                Source = new BitmapImage(new Uri(dialog.FileName))

                };
                InkCanvas.SetLeft(image, 0);
                InkCanvas.SetTop(image, 0);
                theInkCanvas.Children.Add(image);
            }
        }

        private System.Windows.Controls.Image draggedImage;
        private Point mousePosition;

        private void CanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var image = e.Source as System.Windows.Controls.Image;

            if (image != null && theInkCanvas.CaptureMouse())
            {
                mousePosition = e.GetPosition(theInkCanvas);
                draggedImage = image;
                System.Windows.Controls.Panel.SetZIndex(draggedImage, 1); // in case of multiple images
            }
        }

        private void CanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (draggedImage != null)
            {
                theInkCanvas.ReleaseMouseCapture();
                System.Windows.Controls.Panel.SetZIndex(draggedImage, 0);
                draggedImage = null;
            }
        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (draggedImage != null)
            {
                var position = e.GetPosition(theInkCanvas);
                position.X = (position.X + 300) * -1;
                var offset = position - mousePosition;
                mousePosition = position;
                InkCanvas.SetLeft(draggedImage, InkCanvas.GetLeft(draggedImage) + offset.X);
             //   InkCanvas.SetTop(draggedImage, InkCanvas.GetTop(draggedImage) + offset.Y);
            }
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
               // imgPhoto.Source = new BitmapImage(new Uri(op.FileName));

                image = new System.Windows.Controls.Image
                {
                    Source = new BitmapImage(new Uri(op.FileName))
                };
                theInkCanvas.Children.Add(image);
            }
        }
    }

}

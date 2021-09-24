using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
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
//Added
using System.IO;
using Microsoft.Win32;
using System.Windows.Ink;


namespace NotEBookDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
            saveFileDialog1.Filter = "isf files (*.isf)|*.isf";

            if (saveFileDialog1.ShowDialog() == true)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName,
                                               FileMode.Create);
                theInkCanvas.Strokes.Save(fs);
                fs.Close();
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "isf files (*.isf)|*.isf";

            if (openFileDialog1.ShowDialog() == true)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName,
                                               FileMode.Open);
                theInkCanvas.Strokes = new StrokeCollection(fs);
                fs.Close();
            }
        }
    }
 
}

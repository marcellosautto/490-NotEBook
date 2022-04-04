using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NotEBookDesktop
{
    /// <summary>
    /// Interaction logic for TextEditor.xmal
    /// </summary>
    public partial class TextEditor : Window
    {
        public TextEditor()
        {
            InitializeComponent();
        }

        private void Strikethrough(object sender, RoutedEventArgs e)
        {
            //Needed to add this function manually, as there is not EditingProperty for strikethrough as there is for Bold, Italics, and Underline
            if(mainRTB != null && mainRTB.Selection != null)
            {

                TextRange textRange = new TextRange(mainRTB.Selection.Start, mainRTB.Selection.End);
                var currentTextDecoration = textRange.GetPropertyValue(Inline.TextDecorationsProperty);

                TextDecorationCollection newTextDecoration;

                if (currentTextDecoration != DependencyProperty.UnsetValue) // not all values have strikethrough/
                {
                    newTextDecoration = ((TextDecorationCollection)currentTextDecoration == TextDecorations.Strikethrough) ? new TextDecorationCollection() : TextDecorations.Strikethrough;
                }
                else if (currentTextDecoration == TextDecorations.Strikethrough)//remove striekthough
                {
                    newTextDecoration = new TextDecorationCollection();
                }

                else
                {
                    newTextDecoration = TextDecorations.Strikethrough;
                }

                textRange.ApplyPropertyValue(Inline.TextDecorationsProperty, newTextDecoration);
            }


        }
        
    }
}

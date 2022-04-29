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
using Microsoft.Win32;

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
            //Sets the comboboxes to the defaults of mainRTB
            FontHeight.SelectedItem = mainRTB.FontSize.ToString();
            FontType.SelectedItem = mainRTB.FontFamily.ToString();
        }

        private void Strikethrough(object sender, RoutedEventArgs e)
        {
            //Needed to add this function manually, as there is not EditingProperty for strikethrough as there is for Bold, Italics, and Underline
            if(mainRTB != null && mainRTB.Selection != null)
            {

                TextRange textRange = new TextRange(mainRTB.Selection.Start, mainRTB.Selection.End);
                var currentTextDecoration = textRange.GetPropertyValue(Inline.TextDecorationsProperty);

                TextDecorationCollection newTextDecoration;

                if (currentTextDecoration != DependencyProperty.UnsetValue) // not all values have strikethrough
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

        private void FontHeight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mainRTB == null)
                return;

            // Make sure we have a selection. Should have one even if there is no text selected.
            if (mainRTB.Selection != null)
            {
                // Check whether there is text selected or just sitting at cursor
                if (mainRTB.Selection.IsEmpty)
                {
                    // Check to see if we are at the start of the textbox and nothing has been added yet
                    if (mainRTB.Selection.Start.Paragraph == null)
                    {
                        // Add a new paragraph object to the richtextbox with the fontsize
                        Paragraph p = new Paragraph();
                        p.FontSize = Convert.ToDouble(FontHeight.SelectedItem);
                        mainRTB.Document.Blocks.Add(p);
                    }
                    else
                    {
                        // Get current position of cursor
                        TextPointer curCaret = mainRTB.CaretPosition;
                        // Get the current block object that the cursor is in
                        Block curBlock = mainRTB.Document.Blocks.Where
                            (x => x.ContentStart.CompareTo(curCaret) == -1 && x.ContentEnd.CompareTo(curCaret) == 1).FirstOrDefault();
                        if (curBlock != null)
                        {
                            Paragraph curParagraph = curBlock as Paragraph;
                            // Create a new run object with the fontsize, and add it to the current block
                            Run newRun = new Run();
                            newRun.FontSize = Convert.ToDouble(FontHeight.SelectedItem);
                            newRun.FontFamily = curParagraph.FontFamily;
                            curParagraph.Inlines.Add(newRun);
                            // Reset the cursor into the new block. 
                            // If we don't do this, the font size will default again when you start typing.
                            mainRTB.CaretPosition = newRun.ElementStart;
                        }
                    }
                }
                else // There is selected text, so change the fontsize of the selection
                {
                    TextRange selectionTextRange = new TextRange(mainRTB.Selection.Start, mainRTB.Selection.End);
                    selectionTextRange.ApplyPropertyValue(TextElement.FontSizeProperty, FontHeight.SelectedItem);
                }
            }
            // Reset the focus onto the richtextbox after selecting the font in a toolbar etc
            mainRTB.Focus();

        }

        private void FontType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Make sure we have a richtextbox.
            if (mainRTB== null)
                return;

            // Make sure we have a selection. Should have one even if there is no text selected.
            if (mainRTB.Selection != null)
            {
                // Check whether there is text selected or just sitting at cursor
                if (mainRTB.Selection.IsEmpty)
                {
                    // Check to see if we are at the start of the textbox and nothing has been added yet
                    if (mainRTB.Selection.Start.Paragraph == null)
                    {
                        // Add a new paragraph object to the richtextbox with the fontfamily
                        Paragraph p = new Paragraph();
                        p.FontFamily = new System.Windows.Media.FontFamily(FontType.SelectedItem.ToString());
                        mainRTB.Document.Blocks.Add(p);
                    }
                    else
                    {
                        // Get current position of cursor
                        TextPointer curCaret = mainRTB.CaretPosition;
                        // Get the current block object that the cursor is in
                        Block curBlock = mainRTB.Document.Blocks.Where
                            (x => x.ContentStart.CompareTo(curCaret) == -1 && x.ContentEnd.CompareTo(curCaret) == 1).FirstOrDefault();
                        if (curBlock != null)
                        {
                            Paragraph curParagraph = curBlock as Paragraph;
                            // Create a new run object with the fontfamily, and add it to the current block
                            Run newRun = new Run();
                            newRun.FontSize = curParagraph.FontSize;
                            newRun.FontFamily = new System.Windows.Media.FontFamily(FontType.SelectedItem.ToString());
                            curParagraph.Inlines.Add(newRun);
                            // Reset the cursor into the new block. 
                            // If we don't do this, the font size will default again when you start typing.
                            mainRTB.CaretPosition = newRun.ElementStart;
                        }
                    }
                }
                else // There is selected text, so change the fontType of the selection
                {
                    TextRange selectionTextRange = new TextRange(mainRTB.Selection.Start, mainRTB.Selection.End);
                    selectionTextRange.ApplyPropertyValue(TextElement.FontFamilyProperty, FontType.SelectedItem);
                }
            }
            // Reset the focus onto the richtextbox after selecting the font in a toolbar etc
            mainRTB.Focus();
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            //Save contents of mainRTB to file
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "RichText File(*.rtf)| *.rtf";
            //sf.Filter = "XAML files| *.xaml";
            if (sf.ShowDialog() == true)
            {
                System.IO.FileStream FileStream= (System.IO.FileStream)sf.OpenFile();
                TextRange FileContents = new TextRange(mainRTB.Document.ContentStart,mainRTB.Document.ContentEnd);
                FileContents.Save(FileStream, System.Windows.DataFormats.Rtf);
            }
        }

        private void Open_Btm_Click(object sender, RoutedEventArgs e)
        {
            //Open from file to mainRTB
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "RichText File(*.rtf)| *.rtf";
            //of.Filter = "XAML files| *.xaml";
            if (of.ShowDialog() == true)
            {
                System.IO.FileStream FileStream = (System.IO.FileStream)of.OpenFile();
                TextRange FileContents = new TextRange(mainRTB.Document.ContentStart, mainRTB.Document.ContentEnd);
                FileContents.Load(FileStream, System.Windows.DataFormats.Rtf);
            }
        }

        private void IncreaseFontSize_Click(object sender, RoutedEventArgs e)
        {
            //Adds extra functionality to button, increment fontsize in combobox, max is 1638 THIS SHIT DONT WORK
            double result = mainRTB.FontSize + 1;
            if (result > 1638)
            {
                result = 1638;
            }

            FontHeight.SelectedItem = result.ToString();
        }

        private void ShrinkFontSize_Btn_Click(object sender, RoutedEventArgs e)
        {
            //Adds extra functionality to button, increment fontsize in combobox min is 1
            double result = mainRTB.FontSize - 1;
            if (result < 1)
            {
                result = 1;
            }
            FontHeight.SelectedItem = result.ToString();
        }
    }
}
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
using FontFamily = System.Windows.Media.FontFamily;
using System.Windows.Controls.Primitives;
using Image = System.Drawing.Image;

namespace NotEBookDesktop
{
    /// <summary>
    /// Interaction logic for TextEditor.xmal
    /// </summary>
    public partial class TextEditor : Window
    {
        System.Windows.Controls.Image image;
        public TextEditor()
        {
            InitializeComponent();
            //Sets the comboboxes to the defaults of mainRTB
            FontHeight.SelectedItem = mainRTB.FontSize;
            FontType.SelectedItem = mainRTB.FontFamily;
            
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        private void Strikethrough(object sender, RoutedEventArgs e)
        {
            //Needed to add this function manually, as there is not EditingProperty for strikethrough as there is for Bold, Italics, and Underline
            //if (mainRTB != null && mainRTB.Selection != null)
            //{

            //TextRange textRange = new TextRange(mainRTB.Selection.Start, mainRTB.Selection.End);
            //var currentTextDecoration = textRange.GetPropertyValue(Inline.TextDecorationsProperty);
            var currentTextDecoration = mainRTB.Selection.GetPropertyValue(Inline.TextDecorationsProperty);

                TextDecorationCollection newTextDecoration;

                if (currentTextDecoration != DependencyProperty.UnsetValue/*TextDecorations.Strikethrough && currentTextDecoration != TextDecorations.Underline*/) // not all values have strikethrough, but if we have underline, return the underlined text if present
                {
                    newTextDecoration = ((TextDecorationCollection)currentTextDecoration == TextDecorations.Strikethrough) ? new TextDecorationCollection() : TextDecorations.Strikethrough;
                    //newTextDecoration = ((TextDecorationCollection)currentTextDecoration == TextDecorations.Strikethrough) ? (((TextDecorationCollection)currentTextDecoration == TextDecorations.Underline) ? new TextDecorationCollection(TextDecorations.Underline): new TextDecorationCollection()) : TextDecorations.Strikethrough;
                    //newTextDecoration = TextDecorations.Strikethrough;
                }
                else if (currentTextDecoration == TextDecorations.Strikethrough && currentTextDecoration != TextDecorations.Underline)//remove striekthough, no underline
                {
                    newTextDecoration = new TextDecorationCollection();
                }
                else if(currentTextDecoration == TextDecorations.Strikethrough && currentTextDecoration == TextDecorations.Underline)// remove strikethrough, keep underline
                {
                    newTextDecoration = TextDecorations.Underline;
                }
                else
                {
                    newTextDecoration = TextDecorations.Strikethrough;
                }

            //textRange.ApplyPropertyValue(Inline.TextDecorationsProperty, newTextDecoration);
            mainRTB.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, newTextDecoration);
            //}


        }

        private void FontHeight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ApplyPropertyValueToSelectedText(TextElement.FontSizeProperty, e.AddedItems[0]);
                mainRTB.Focus();
            }
            catch(IndexOutOfRangeException ex) 
            {
                //Do nothing, this try catch block is need to prevent an out of range exception when selecting text with diffrent fonts
            }
            //ChangeFontProperties(false);
            //mainRTB.Selection.ApplyPropertyValue(FontSizeProperty, FontHeight.SelectedItem);

        }

        private void FontType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FontFamily editValue = (FontFamily)e.AddedItems[0];
            ApplyPropertyValueToSelectedText(TextElement.FontFamilyProperty, editValue);
            mainRTB.Focus();
            //ChangeFontProperties(true);
            //mainRTB.Selection.ApplyPropertyValue(FontFamilyProperty, FontType.SelectedItem);
        }
        private void ChangeFontProperties(bool isChangingFontFamily)
        {
            // Make sure we have a richtextbox.
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
                        // Add a new paragraph object to the richtextbox with the fontfamily
                        Paragraph p = new Paragraph();
                        if(isChangingFontFamily)
                        {
                            p.FontFamily = new System.Windows.Media.FontFamily(FontType.SelectedItem.ToString());
                        }
                        else
                        {
                            p.FontSize = Convert.ToDouble(FontHeight.SelectedItem);
                        }
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
                            if(isChangingFontFamily)
                            {
                                newRun.FontSize = curParagraph.FontSize;
                                newRun.FontFamily = new System.Windows.Media.FontFamily(FontType.SelectedItem.ToString());
                            }
                            else
                            {
                                newRun.FontSize = Convert.ToDouble(FontHeight.SelectedItem.ToString());
                                newRun.FontFamily = new System.Windows.Media.FontFamily(curParagraph.FontFamily.ToString());
                            }
                            newRun.TextDecorations = new TextDecorationCollection();
                            newRun.TextDecorations = curParagraph.TextDecorations;
                            newRun.FontWeight = new FontWeight();
                            newRun.FontWeight = curParagraph.FontWeight;
                            newRun.FontStyle = new System.Windows.FontStyle();
                            newRun.FontStyle = curParagraph.FontStyle;
                            curParagraph.Inlines.Add(newRun);
                            // Reset the cursor into the new block. 
                            // If we don't do this, the font size will default again when you start typing.
                            mainRTB.CaretPosition = newRun.ElementStart;
                        }
                        //else//No blocks to refrence, create a new one with desired effects
                        //{
                        //    //Section newSection = new Section();
                        //    //Run newRun = new Run();
                        //    if (isChangingFontFamily)
                        //    {
                        //        mainRTB.FontFamily = new System.Windows.Media.FontFamily(FontType.SelectedItem.ToString());
                        //    }
                        //    else
                        //    {
                        //        mainRTB.FontSize = Convert.ToDouble(FontHeight.SelectedItem.ToString());
                        //    }
                        //    //Paragraph newPar = new Paragraph();
                        //    //newPar.Inlines.Add(newRun);
                        //    ////newSection.Blocks.Add(newPar);
                        //    //Span spanx = new Span();
                        //    ////spanx.Inlines.Add(newRun);
                        //    //mainRTB.Document.Blocks.Add(newSection);

                        //}
                    }
                }
                else // There is selected text, so change the fontType of the selection
                {
                    if (isChangingFontFamily)
                    {
                        TextRange selectionTextRange = new TextRange(mainRTB.Selection.Start, mainRTB.Selection.End);
                        selectionTextRange.ApplyPropertyValue(TextElement.FontFamilyProperty, FontType.SelectedItem);
                    }
                    else
                    {
                        TextRange selectionTextRange = new TextRange(mainRTB.Selection.Start, mainRTB.Selection.End);
                        selectionTextRange.ApplyPropertyValue(TextElement.FontSizeProperty, FontHeight.SelectedItem);
                    }
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
                System.IO.FileStream FileStream = (System.IO.FileStream)sf.OpenFile();
                TextRange FileContents = new TextRange(mainRTB.Document.ContentStart, mainRTB.Document.ContentEnd);
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
            IncreaseShrinkFontSize();
        }

        private void ShrinkFontSize_Btn_Click(object sender, RoutedEventArgs e)
        {
            IncreaseShrinkFontSize();
        }
        private void IncreaseShrinkFontSize()
        {
            if (mainRTB.Selection != null)
            {
                if (mainRTB.Selection.IsEmpty)
                {
                    TextPointer curCaret = mainRTB.CaretPosition;
                    Block curBlock = mainRTB.Document.Blocks.Where
                                    (x => x.ContentStart.CompareTo(curCaret) == -1 && x.ContentEnd.CompareTo(curCaret) == 1).FirstOrDefault();
                    if (curBlock != null)
                    {
                        Paragraph curParagraph = curBlock as Paragraph;
                        double result = curParagraph.FontSize;

                        FontHeight.SelectedItem = result;
                    }
                }
            }
        }

        private void mainRTB_SelectionChanged(object sender, RoutedEventArgs e)
        {
            UpdateToggleButtonState();
            UpdateSelectionListType();
            UpdateSelectedFontFamily();
            UpdateSelectedFontSize();

            var inline = this.mainRTB.CaretPosition.GetAdjacentElement(LogicalDirection.Forward) as Inline;
            if (inline != null)
            {
                this.AddAdorner(inline.NextInline as InlineUIContainer);
                this.AddAdorner(inline.PreviousInline as InlineUIContainer);
            }

        }
       private void ApplyPropertyValueToSelectedText(DependencyProperty formattingProperty, object value)
        {
            if (value == null)
                return;

            mainRTB.Selection.ApplyPropertyValue(formattingProperty, value);
        }
        private void UpdateToggleButtonState()
        {
            UpdateItemCheckedState(Bold_Btn, TextElement.FontWeightProperty, FontWeights.Bold);
            UpdateItemCheckedState(Italics_Btn, TextElement.FontStyleProperty, FontStyles.Italic);
            UpdateItemCheckedState(Underline_Btn, Inline.TextDecorationsProperty, TextDecorations.Underline);
            UpdateItemCheckedState(Strikethough_Btn, Inline.TextDecorationsProperty, TextDecorations.Strikethrough);

            UpdateItemCheckedState(Superscript_Btn, Inline.BaselineAlignmentProperty, BaselineAlignment.Superscript);
            UpdateItemCheckedState(Subscript_Btn, Inline.BaselineAlignmentProperty, BaselineAlignment.Subscript);

            //UpdateItemCheckedState(AlignLeft_Btn, Paragraph.TextAlignmentProperty, TextAlignment.Left);
            //UpdateItemCheckedState(AlignCenter_Btn, Paragraph.TextAlignmentProperty, TextAlignment.Center);
            //UpdateItemCheckedState(AlignRight_Btn, Paragraph.TextAlignmentProperty, TextAlignment.Right);
            //UpdateItemCheckedState(AlignJustify_Btn, Paragraph.TextAlignmentProperty, TextAlignment.Right);
        }
        private void UpdateSelectionListType()
        {
            Paragraph startParagraph = mainRTB.Selection.Start.Paragraph;
            Paragraph endParagraph = mainRTB.Selection.End.Paragraph;
            if (startParagraph != null && endParagraph != null && (startParagraph.Parent is ListItem) && (endParagraph.Parent is ListItem) && object.ReferenceEquals(((ListItem)startParagraph.Parent).List, ((ListItem)endParagraph.Parent).List))
            {
                TextMarkerStyle markerStyle = ((ListItem)startParagraph.Parent).List.MarkerStyle;
                if (markerStyle == TextMarkerStyle.Disc) //bullets
                {
                    Bullet_Btn.IsChecked = true;
                }
                else if (markerStyle == TextMarkerStyle.Decimal) //numbers
                {
                    Numbering_Btn.IsChecked = true;
                }
            }
            else
            {
                Bullet_Btn.IsChecked = false;
                Numbering_Btn.IsChecked = false;
            }
        }
        void UpdateItemCheckedState(ToggleButton button, DependencyProperty formattingProperty, object expectedValue)
        {
            object currentValue = mainRTB.Selection.GetPropertyValue(formattingProperty);
            button.IsChecked = (currentValue == DependencyProperty.UnsetValue) ? false : currentValue != null && currentValue.Equals(expectedValue);
        }
        private void UpdateSelectedFontFamily()
        {
            //if (!mainRTB.Selection.IsEmpty)
            //{
                object value = mainRTB.Selection.GetPropertyValue(TextElement.FontFamilyProperty);
                FontFamily currentFontFamily = (FontFamily)((value == DependencyProperty.UnsetValue) ? null : value);
                if (currentFontFamily != null)
                {
                    FontType.SelectedItem = currentFontFamily;
                }
            //}
        }

        private void UpdateSelectedFontSize()
        {
            //if (!mainRTB.Selection.IsEmpty)
            //{
                object value = mainRTB.Selection.GetPropertyValue(TextElement.FontSizeProperty);
                FontHeight.SelectedValue = (value == DependencyProperty.UnsetValue) ? null : value;
            //}
        }

        private void OpenImage_Btn_Click(object sender, RoutedEventArgs e)
        {
            //Depricated, any resizeing isnt saved, requires rewrite to saving function
            object orgClipboardItem = Clipboard.GetDataObject();
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";

            if (of.ShowDialog() == true)
            {
                image = new System.Windows.Controls.Image
                {
                    Source = new BitmapImage(new Uri(of.FileName)),
                    Width = 100
                };
                image.Stretch = Stretch.Fill;

                BlockUIContainer container = new BlockUIContainer(image);
                mainRTB.Document.Blocks.Add(container);
                image.Loaded += delegate
                {
                    AdornerLayer al = AdornerLayer.GetAdornerLayer(image);
                    if (al != null)
                    {
                        al.Add(new ResizingAdorner(image));
                    }
                };
                //Clipboard.SetDataObject(image);
                //mainRTB.Paste();
                //Image Img = Image.FromFile(of.FileName);
                //Clipboard.SetDataObject(Img);

                //mainRTB.Paste();

            }
            Clipboard.SetDataObject(orgClipboardItem);
            mainRTB.Focus();


        }
        private void AddAdorner(InlineUIContainer container)
        {
            if (container != null)
            {
                var image = container.Child;
                if (image != null)
                {
                    var al = AdornerLayer.GetAdornerLayer(image);
                    if (al != null)
                    {
                        var currentAdorners = al.GetAdorners(image);
                        if (currentAdorners != null)
                        {
                            foreach (var adorner in currentAdorners)
                            {
                                al.Remove(adorner);
                            }
                        }

                        al.Add(new ResizingAdorner(image));
                    }
                }
            }
        }

        private void SuperScript_Btn_Click(object sender, RoutedEventArgs e)
        {
            var currentAlignment = mainRTB.Selection.GetPropertyValue(Inline.BaselineAlignmentProperty);
            BaselineAlignment newAlignment = ((BaselineAlignment)currentAlignment == BaselineAlignment.Superscript) ? BaselineAlignment.Baseline : BaselineAlignment.Superscript;
            mainRTB.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, newAlignment);
        }

        private void Subscipt_Btn_Click(object sender, RoutedEventArgs e)
        {
            var currentAlignment = mainRTB.Selection.GetPropertyValue(Inline.BaselineAlignmentProperty);

            BaselineAlignment newAlignment = ((BaselineAlignment)currentAlignment == BaselineAlignment.Subscript) ? BaselineAlignment.Baseline : BaselineAlignment.Subscript;
            mainRTB.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, newAlignment);
        }
    }

}
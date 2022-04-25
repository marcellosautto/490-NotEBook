using System;
using System.Collections.ObjectModel;
using System.Windows.Media;



//Gets the lists of Fonts installed on user's computer
namespace NotEBookDesktop
{
    class FontList : ObservableCollection<string>
    {
        public FontList()
        {
            foreach (FontFamily f in Fonts.SystemFontFamilies)
            {
                this.Add(f.ToString());
            }
        }
    }
}


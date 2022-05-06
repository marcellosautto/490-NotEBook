using System;
using System.Collections.ObjectModel;
using System.Windows.Media;



//Gets the lists of Fonts installed on user's computer
namespace NotEBookDesktop
{
    class FontList : ObservableCollection<FontFamily>
    {
        public FontList()
        {
            foreach (FontFamily f in Fonts.SystemFontFamilies)
            {
                this.Add(f);
            }
        }
    }
}


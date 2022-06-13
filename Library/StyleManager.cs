using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace AdminTool.Library
{
    class StyleManager
    {
        public static TextDecorationCollection CreateUnderline()
        {
            TextDecorationCollection myCollection = new TextDecorationCollection();
            TextDecoration textDecoration = new TextDecoration();
            textDecoration.Pen = new Pen(Brushes.Transparent, 2);
            textDecoration.Location = TextDecorationLocation.Underline;

            myCollection.Add(textDecoration);

            return myCollection;
        }
    }
}

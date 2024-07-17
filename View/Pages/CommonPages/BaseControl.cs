using Libraries.Modell;
using Libraries.View.Pages.Library;
using System.Windows.Controls;

namespace Libraries.View.Pages.CommonPages
{
    public class BaseControl : UserControl, IItem
    {
        public BaseModell Modell { get; set; }
    }
}

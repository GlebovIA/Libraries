using Libraries.Classes;
using Libraries.Contexts;
using Libraries.Modell;
using Libraries.View.Pages.CommonPages;
using System.Windows.Controls;

namespace Libraries.ViewModell
{
    public class VMItem
    {
        public BaseModell Modell { get; set; }
        public UserControl Item { get; set; }
        public VMItem(UserControl item)
        {
            Item = item;
            Modell = (Item as BaseControl).Modell;
        }
        public RelayCommand Edit()
        {
            return new RelayCommand(obj =>
            {
                BaseContext.Edit(Modell);
            });
        }
    }
}

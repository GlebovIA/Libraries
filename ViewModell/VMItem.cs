using Libraries.Classes;
using Libraries.Contexts;
using Libraries.Modell;
using System.Windows.Controls;

namespace Libraries.ViewModell
{
    public class VMItem
    {
        public UserControl Item { get; set; }
        public BaseModell Modell { get; set; }
        public BaseContext Context { get; set; }
        public VMItem(UserControl item, BaseModell modell, BaseContext context)
        {
            Item = item;
            Modell = modell;
            Context = context;
        }
        public RelayCommand Edit
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    ItemsModell.Edit(Modell);
                });
            }
        }
        public RelayCommand Delete
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    BaseContext.Delete(Modell, Context);
                });
            }
        }
    }
}

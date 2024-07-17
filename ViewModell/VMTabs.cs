using Libraries.Classes;
using Libraries.Modell;
using Libraries.View.Pages.CommonPages;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Libraries.ViewModell
{
    public class VMTabs
    {
        public TabsModell Modell { get; set; }
        public TabElement Element { get; set; }
        public RelayCommand GetEntityElements { get; set; }
        public static List<UserControl> CurrentEntityItems { get; set; }
        public static TabElement CurrentElement { get; set; }
        public VMTabs(TabsModell modell, TabElement element)
        {
            Modell = modell;
            Element = element;
        }
        public RelayCommand GetElements
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    TabsModell.MP.ItemsList.ItemsSource = LibrariesModell.CreateItems(Element);
                });
            }
        }
    }
}

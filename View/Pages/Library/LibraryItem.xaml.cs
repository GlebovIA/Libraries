using Libraries.Modell;
using Libraries.ViewModell;
using System.Windows.Controls;

namespace Libraries.View.Pages.Library
{
    /// <summary>
    /// Логика взаимодействия для LibraryItem.xaml
    /// </summary>
    public partial class LibraryItem : UserControl, IItem
    {
        public BaseModell Modell { get; set; }
        public LibraryItem(LibrariesModell modell)
        {
            InitializeComponent();
            Modell = modell;
            DataContext = new VMItem(this);
        }
    }
}

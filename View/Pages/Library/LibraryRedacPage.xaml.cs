using Libraries.Modell;
using System.Windows.Controls;

namespace Libraries.View.Pages.Library
{
    /// <summary>
    /// Логика взаимодействия для LibraryRedacPage.xaml
    /// </summary>
    public partial class LibraryRedacPage : Page
    {
        public LibrariesModell Modell { get; set; }
        public LibraryRedacPage(LibrariesModell modell)
        {
            InitializeComponent();
            Modell = modell;
        }
    }
}

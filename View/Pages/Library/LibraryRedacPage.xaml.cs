using Libraries.Contexts;
using Libraries.Modell;
using Libraries.ViewModell;
using System.Linq;
using System.Windows.Controls;

namespace Libraries.View.Pages.Library
{
    /// <summary>
    /// Логика взаимодействия для LibraryRedacPage.xaml
    /// </summary>
    public partial class LibraryRedacPage : Page
    {
        public LibrariesModell Modell { get; set; }
        public LibraryRedacPage(LibrariesContext context, LibrariesModell modell = null)
        {
            InitializeComponent();
            if (modell != null)
            {
                Modell = context.Libraries.Where(x => x.Id_library == modell.Id_library).FirstOrDefault();
                AddRedacBtn.Content = "Изменить";
                HeaderTBck.Text = "Редактирование библиотеки";
                DataContext = new VMRedac(Modell, context, false);
            }
            else
            {
                AddRedacBtn.Content = "Добавить";
                HeaderTBck.Text = "Добавление библиотеки";
                DataContext = new VMRedac(new LibrariesModell(), new LibrariesContext());
            }
        }
    }
}

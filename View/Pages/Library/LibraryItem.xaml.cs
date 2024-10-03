using Libraries.Contexts;
using Libraries.Modell;
using Libraries.ViewModell;
using System.Windows;
using System.Windows.Controls;

namespace Libraries.View.Pages.Library
{
    /// <summary>
    /// Логика взаимодействия для LibraryItem.xaml
    /// </summary>
    public partial class LibraryItem : UserControl
    {
        public LibraryItem(LibrariesModell modell, LibrariesContext context)
        {
            InitializeComponent();
            DataContext = new VMItem(this, modell, context);
            if (UsersModell.CurrentUser == UsersModell.usersRole.Reader)
            {
                this.Edit.Visibility = Visibility.Hidden;
                this.Delete.Visibility = Visibility.Hidden;
            }
        }
    }
}

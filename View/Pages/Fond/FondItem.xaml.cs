using Libraries.Contexts;
using Libraries.Modell;
using Libraries.ViewModell;
using System.Windows;
using System.Windows.Controls;

namespace Libraries.View.Pages.Fond
{
    /// <summary>
    /// Логика взаимодействия для FondItem.xaml
    /// </summary>
    public partial class FondItem : UserControl
    {
        public FondItem(FondsModell modell, FondsContext context)
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

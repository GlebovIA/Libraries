using Libraries.Contexts;
using Libraries.Modell;
using Libraries.ViewModell;
using System.Windows;
using System.Windows.Controls;

namespace Libraries.View.Pages.Replenishment
{
    /// <summary>
    /// Логика взаимодействия для ReplenishmentItem.xaml
    /// </summary>
    public partial class ReplenishmentItem : UserControl
    {
        public ReplenishmentItem(ReplenishmentsModell modell, ReplenishmentsContext context)
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

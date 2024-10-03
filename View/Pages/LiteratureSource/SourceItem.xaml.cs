using Libraries.Contexts;
using Libraries.Modell;
using Libraries.ViewModell;
using System.Windows;
using System.Windows.Controls;

namespace Libraries.View.Pages.LiteratureSource
{
    /// <summary>
    /// Логика взаимодействия для SourceItem.xaml
    /// </summary>
    public partial class SourceItem : UserControl
    {
        public SourceItem(Literature_sourcesModell modell, LiteratureSourcesContext context)
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

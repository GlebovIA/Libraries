using Libraries.Contexts;
using Libraries.Modell;
using Libraries.ViewModell;
using System.Linq;
using System.Windows.Controls;

namespace Libraries.View.Pages.Fond
{
    /// <summary>
    /// Логика взаимодействия для FondRedacPage.xaml
    /// </summary>
    public partial class FondRedacPage : Page
    {
        public FondsModell Modell { get; set; }
        public FondRedacPage(FondsContext context, FondsModell modell = null)
        {
            InitializeComponent();
            if (modell != null)
            {
                Modell = context.Fonds.Where(x => x.Id_fond == modell.Id_fond).FirstOrDefault();
                AddRedacBtn.Content = "Изменить";
                HeaderTBck.Text = "Редактирование фонда";
                DataContext = new VMRedac(Modell, context, false);
            }
            else
            {
                AddRedacBtn.Content = "Добавить";
                HeaderTBck.Text = "Добавление фонда";
                DataContext = new VMRedac(new FondsModell(), new FondsContext());
            }
        }
    }
}

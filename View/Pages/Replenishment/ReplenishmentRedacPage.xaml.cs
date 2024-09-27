using Libraries.Contexts;
using Libraries.Modell;
using Libraries.ViewModell;
using System.Linq;
using System.Windows.Controls;

namespace Libraries.View.Pages.Replenishment
{
    /// <summary>
    /// Логика взаимодействия для ReplenishmentRedacPage.xaml
    /// </summary>
    public partial class ReplenishmentRedacPage : Page
    {
        public ReplenishmentsModell Modell { get; set; }
        public ReplenishmentRedacPage(ReplenishmentsContext context, ReplenishmentsModell modell = null)
        {
            InitializeComponent();
            if (modell != null)
            {
                Modell = context.Replenishments.Where(x => x.Id_replenishment == modell.Id_replenishment).FirstOrDefault();
                AddRedacBtn.Content = "Изменить";
                HeaderTBck.Text = "Редактирование носителя литературы";
                DataContext = new VMRedac(Modell, context, false);
            }
            else
            {
                AddRedacBtn.Content = "Добавить";
                HeaderTBck.Text = "Добавление носителя литературы";
                DataContext = new VMRedac(new ReplenishmentsModell(), new ReplenishmentsContext());
            }
        }
    }
}

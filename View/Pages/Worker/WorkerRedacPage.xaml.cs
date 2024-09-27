using Libraries.Contexts;
using Libraries.Modell;
using Libraries.ViewModell;
using System.Linq;
using System.Windows.Controls;

namespace Libraries.View.Pages.Worker
{
    /// <summary>
    /// Логика взаимодействия для WorkerRedacPage.xaml
    /// </summary>
    public partial class WorkerRedacPage : Page
    {
        public WorkersModell Modell { get; set; }
        public WorkerRedacPage(WorkersContext context, WorkersModell modell = null)
        {
            InitializeComponent();
            if (modell != null)
            {
                Modell = context.Workers.Where(x => x.Id_worker == modell.Id_worker).FirstOrDefault();
                AddRedacBtn.Content = "Изменить";
                HeaderTBck.Text = "Редактирование носителя литературы";
                DataContext = new VMRedac(Modell, context, false);
            }
            else
            {
                AddRedacBtn.Content = "Добавить";
                HeaderTBck.Text = "Добавление носителя литературы";
                DataContext = new VMRedac(new WorkersModell(), new WorkersContext());
            }
        }
    }
}

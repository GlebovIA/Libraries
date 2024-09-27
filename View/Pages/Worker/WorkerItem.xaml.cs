using Libraries.Contexts;
using Libraries.Modell;
using Libraries.ViewModell;
using System.Windows.Controls;

namespace Libraries.View.Pages.Worker
{
    /// <summary>
    /// Логика взаимодействия для WorkerItem.xaml
    /// </summary>
    public partial class WorkerItem : UserControl
    {
        public WorkerItem(WorkersModell modell, WorkersContext context)
        {
            InitializeComponent();
            DataContext = new VMItem(this, modell, context);
        }
    }
}

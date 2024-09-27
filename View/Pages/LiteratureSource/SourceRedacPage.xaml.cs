using Libraries.Contexts;
using Libraries.Modell;
using Libraries.ViewModell;
using System.Linq;
using System.Windows.Controls;

namespace Libraries.View.Pages.LiteratureSource
{
    /// <summary>
    /// Логика взаимодействия для TypeRedacPage.xaml
    /// </summary>
    public partial class SourceRedacPage : Page
    {
        public Literature_sourcesModell Modell { get; set; }
        public SourceRedacPage(LiteratureSourcesContext context, Literature_sourcesModell modell = null)
        {
            InitializeComponent();
            if (modell != null)
            {
                Modell = context.Literature_sources.Where(x => x.Id_source == modell.Id_source).FirstOrDefault();
                AddRedacBtn.Content = "Изменить";
                HeaderTBck.Text = "Редактирование носителя литературы";
                DataContext = new VMRedac(Modell, context, false);
            }
            else
            {
                AddRedacBtn.Content = "Добавить";
                HeaderTBck.Text = "Добавление носителя литературы";
                DataContext = new VMRedac(new Literature_sourcesModell(), new LiteratureSourcesContext());
            }
        }
    }
}

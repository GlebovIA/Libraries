using Libraries.Contexts;
using Libraries.Modell;
using Libraries.ViewModell;
using System.Linq;
using System.Windows.Controls;

namespace Libraries.View.Pages.LiteratureType
{
    /// <summary>
    /// Логика взаимодействия для TypeRedacPage.xaml
    /// </summary>
    public partial class TypeRedacPage : Page
    {
        public Literature_typesModell Modell { get; set; }
        public TypeRedacPage(LiteratureTypesContext context, Literature_typesModell modell = null)
        {
            InitializeComponent();
            if (modell != null)
            {
                Modell = context.Literature_types.Where(x => x.Id_type == modell.Id_type).FirstOrDefault();
                AddRedacBtn.Content = "Изменить";
                HeaderTBck.Text = "Редактирование типа литературы";
                DataContext = new VMRedac(Modell, context, false);
            }
            else
            {
                AddRedacBtn.Content = "Добавить";
                HeaderTBck.Text = "Добавление типа литературы";
                DataContext = new VMRedac(new Literature_typesModell(), new LiteratureTypesContext());
            }
        }
    }
}

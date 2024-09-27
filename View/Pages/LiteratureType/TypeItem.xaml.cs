using Libraries.Contexts;
using Libraries.Modell;
using Libraries.ViewModell;
using System.Windows.Controls;

namespace Libraries.View.Pages.LiteratureType
{
    /// <summary>
    /// Логика взаимодействия для TypeItem.xaml
    /// </summary>
    public partial class TypeItem : UserControl
    {
        public TypeItem(Literature_typesModell modell, LiteratureTypesContext context)
        {
            InitializeComponent();
            DataContext = new VMItem(this, modell, context);
        }
    }
}

using Libraries.Modell;
using System.Windows.Controls;

namespace Libraries.View.Pages.CommonPages
{
    /// <summary>
    /// Логика взаимодействия для TabElement.xaml
    /// </summary>
    public partial class TabElement : Border
    {
        public TabElement(TabsModell context)
        {
            InitializeComponent();
            DataContext = context;
        }
    }
}

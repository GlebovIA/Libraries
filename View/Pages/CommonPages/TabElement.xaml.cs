using Libraries.Modell;
using Libraries.ViewModell;
using System.Windows.Controls;

namespace Libraries.View.Pages.CommonPages
{
    /// <summary>
    /// Логика взаимодействия для TabElement.xaml
    /// </summary>
    public partial class TabElement : Border
    {
        public TabElement(TabsModell modell)
        {
            InitializeComponent();
            DataContext = new VMTabs(modell, this);
        }
    }
}

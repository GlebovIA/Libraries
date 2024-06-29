using Libraries.ViewModell;
using System.Windows.Controls;

namespace Libraries.View.Pages.CommonPages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new VMMain(this);
        }
    }
}

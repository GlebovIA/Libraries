using Libraries.ViewModell;
using System.Windows.Controls;

namespace Libraries.View.Pages.CommonPages
{
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            DataContext = new VMLogIn(this);
        }
    }
}

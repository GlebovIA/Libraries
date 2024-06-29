using Libraries.ViewModell;
using System.Windows;

namespace Libraries
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new VMMW(this);
        }
    }
}

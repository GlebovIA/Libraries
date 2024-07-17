using Libraries.Modell;
using System.Windows.Controls;

namespace Libraries.View.Pages.Fonds
{
    /// <summary>
    /// Логика взаимодействия для FondItem.xaml
    /// </summary>
    public partial class FondItem : UserControl
    {
        public FondsModell Modell { get; set; }
        public FondItem(FondsModell modell)
        {
            InitializeComponent();
            Modell = modell;
        }
    }
}

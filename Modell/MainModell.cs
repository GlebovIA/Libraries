using Libraries.View.Pages.CommonPages;

namespace Libraries.Modell
{
    public class MainModell : BaseModell
    {
        public MainPage MP { get; set; }
        public MainModell(MainPage mp)
        {
            MP = mp;
        }
        public void AllTabs()
        {
            MP.TabList.ItemsSource = TabsModell.CreateTabs(MP);

        }
    }
}

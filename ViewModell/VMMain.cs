using Libraries.Classes;
using Libraries.Modell;
using Libraries.View.Pages.CommonPages;

namespace Libraries.ViewModell
{
    public class VMMain
    {
        private MainPage MP { get; set; }
        private MainModell main { get; set; }
        public VMMain(MainPage mp)
        {
            MP = mp;
            main = new MainModell();
            RelayCommand command = CreateTabs;
            command.Execute(this);
        }
        public RelayCommand CreateTabs
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    main.AllTabs(MP);
                });
            }
        }
    }
}

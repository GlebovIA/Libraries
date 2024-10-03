using Libraries.Classes;
using Libraries.Classes.Common;
using Libraries.Modell;
using Libraries.View.Pages.CommonPages;
using System.Windows;


namespace Libraries.ViewModell
{
    public class VMMain
    {
        private MainPage MP { get; set; }
        private MainModell main { get; set; }
        public VMMain(MainPage mp)
        {
            MP = mp;
            main = new MainModell(MP);
            if (UsersModell.CurrentUser == UsersModell.usersRole.Reader)
            {
                MP.ExportBtn.Visibility = Visibility.Hidden;
                MP.AddBtn.Visibility = Visibility.Hidden;
            }
            CreateTabs.Execute(main);
        }
        public RelayCommand CreateTabs
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    main.AllTabs();
                });
            }
        }
        public RelayCommand AddNewRecord
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    ItemsModell.Edit();
                });
            }
        }
        public RelayCommand Export
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    ExportToXLSX.Export();
                });
            }
        }
    }
}

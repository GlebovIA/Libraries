using Libraries.Classes;
using Libraries.Classes.Db;
using Libraries.View.Pages.CommonPages;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Libraries.ViewModell
{
    public class VMMW : INotifyPropertyChanged
    {
        private static AuthorizationPage AP = new AuthorizationPage();
        public static MainPage MP;
        private static Page _currentPage { get; set; }
        public static Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (value != null && value is Page)
                {
                    _currentPage = value;
                    MW.frame.Navigate(_currentPage);
                }
            }
        }
        private static MainWindow MW { get; set; }
        public VMMW(MainWindow mw)
        {
            MW = mw;
            CurrentPage = AP;
        }
        public RelayCommand Disconnect
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    DbConnection.Disconnect();
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

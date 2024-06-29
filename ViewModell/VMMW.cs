using Libraries.Classes.Db;
using Libraries.View.Pages.CommonPages;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Libraries.ViewModell
{
    public class VMMW : INotifyPropertyChanged
    {
        public enum pages
        {
            main,
            logIn,

        }
        private static AuthorizationPage AP = new AuthorizationPage();
        private static MainPage MP { get; set; }
        private static Page CurrentPage { get; set; }
        public static Page ChangePage
        {
            get { return CurrentPage; }
            set
            {
                if (value != null && value is Page)
                {
                    CurrentPage = value;
                    FrameNavigator(CurrentPage);
                }
            }
        }
        public static MainPage Main
        {
            get { return MP; }
            set
            {
                if (value != null && value is MainPage)
                {
                    MP = value;
                    FrameNavigator(MP);
                }
            }
        }
        private static MainWindow MW { get; set; }
        public VMMW(MainWindow mw)
        {
            MW = mw;
            FrameNavigator(AP);
        }
        private static void FrameNavigator(Page page)
        {
            MW.frame.Navigate(page);
        }
        public void Disconect()
        {
            FrameNavigator(AP);
            DbConnection.Disconnect();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

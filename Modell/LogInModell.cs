using Libraries.Classes.Db;
using Libraries.View.Pages.CommonPages;
using Libraries.ViewModell;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Libraries.Modell
{
    public class LogInModell : INotifyPropertyChanged
    {
        public void DoLogIn(string login, string password)
        {
            DbConnection.CreateConnection(login, password);
            UserModell.CreateUser(login);
            VMMW.Main = new MainPage();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

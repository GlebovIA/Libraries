using Libraries.Classes.Db;
using Libraries.View.Pages.CommonPages;
using Libraries.ViewModell;
using System.Windows;

namespace Libraries.Modell
{
    public class LogInModell : BaseModell
    {
        public void DoLogIn(string login, string password)
        {
            try
            {
                DbConnection.CreateConnection(login, password);
                UsersModell.CreateUser(login);
                MainPage main = new MainPage();
                VMMW.MP = main;
                VMMW.CurrentPage = main;
            }
            catch
            {
                MessageBox.Show("Проверьте правильность логина и пароля, а также подключение к базе данных.");
            }
        }
    }
}

﻿using Libraries.Classes.Db;
using Libraries.View.Pages.CommonPages;
using Libraries.ViewModell;

namespace Libraries.Modell
{
    public class LogInModell : BaseModell
    {
        public void DoLogIn(string login, string password)
        {
            DbConnection.CreateConnection(login, password);
            UserModell.CreateUser(login);
            VMMW.CurrentPage = new MainPage();
        }
    }
}
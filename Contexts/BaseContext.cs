using Libraries.Modell;
using Libraries.View.Pages.Library;
using Libraries.ViewModell;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using static Libraries.Modell.TabsModell;

namespace Libraries.Contexts
{
    public class BaseContext : DbContext
    {
        public static void Edit(BaseModell baseModell)
        {
            entity SelectedEntity = (VMTabs.CurrentElement.DataContext as VMTabs).Modell.Entity;
            switch (SelectedEntity)
            {
                case entity.Libraries:
                    VMMW.CurrentPage = new LibraryRedacPage(baseModell as LibrariesModell);
                    break;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.UseSqlServer(Classes.Db.DbConnection.OpenConnection()) == null)
            {
                MessageBox.Show("Проверьте правильность логина и пароля, а также подключение к базе данных.");
            }
        }
    }
}

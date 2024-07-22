using Libraries.Modell;
using Libraries.ViewModell;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using static Libraries.Modell.TabsModell;

namespace Libraries.Contexts
{
    public class BaseContext : DbContext
    {
        public static void Edit(BaseModell modell, BaseContext context, bool isNew)
        {
            if (isNew)
            {
                context.Add(modell);
            }
            context.SaveChanges();
            VMMW.CurrentPage = VMMW.MP;
            MP.ItemsList.ItemsSource = TabsModell.CreateItems(VMTabs.CurrentElement);
        }
        public static void Delete(BaseModell modell, BaseContext context)
        {
            context.Remove(modell);
            context.SaveChanges();
            VMMW.CurrentPage = VMMW.MP;
            MP.ItemsList.ItemsSource = TabsModell.CreateItems(VMTabs.CurrentElement);
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

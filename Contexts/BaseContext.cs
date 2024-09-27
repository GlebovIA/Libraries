using Libraries.Modell;
using Libraries.ViewModell;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;
using static Libraries.Modell.TabsModell;

namespace Libraries.Contexts
{
    public class BaseContext : DbContext
    {
        public static void Edit(BaseModell modell, BaseContext context, bool isNew)
        {
            try
            {
                if (isNew)
                {
                    context.Add(modell);
                }
                context.SaveChanges();
                VMMW.CurrentPage = VMMW.MP;
                MP.ItemsList.ItemsSource = TabsModell.CreateItems(VMTabs.CurrentElement);
            }
            catch (DbUpdateException) { MessageBox.Show("Все поля должны быть заполнены!", "Уведомление"); }
            catch (Exception) { MessageBox.Show("При выполнении действия произошла ошибка!", "Уведомление"); return; }
        }
        public static void Cancell()
        {
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
            optionsBuilder.UseSqlServer(Classes.Db.DbConnection.OpenConnection());
        }
    }
}

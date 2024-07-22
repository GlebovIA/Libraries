using Libraries.Contexts;
using Libraries.View.Pages.Library;
using Libraries.ViewModell;
using static Libraries.Modell.TabsModell;

namespace Libraries.Modell
{
    public class ItemsModell
    {
        public LibrariesModell Library { get; set; }
        public ItemsModell(object modell, TabsModell.entity entity)
        {
            switch (entity)
            {
                case TabsModell.entity.Libraries:
                    Library = modell as LibrariesModell;
                    break;
            }
        }
        public static void Edit(BaseModell modell = null)
        {
            entity SelectedEntity = (VMTabs.CurrentElement.DataContext as VMTabs).Modell.Entity;
            switch (SelectedEntity)
            {
                case entity.Libraries:

                    VMMW.CurrentPage = new LibraryRedacPage(new LibrariesContext(), modell as LibrariesModell);
                    break;
            }
        }
    }
}

using Libraries.Contexts;
using Libraries.View.Pages.Fond;
using Libraries.View.Pages.Library;
using Libraries.View.Pages.LiteratureSource;
using Libraries.View.Pages.LiteratureType;
using Libraries.View.Pages.Replenishment;
using Libraries.View.Pages.Worker;
using Libraries.ViewModell;
using static Libraries.Modell.TabsModell;

namespace Libraries.Modell
{
    public class ItemsModell
    {
        public static void Edit(BaseModell modell = null)
        {
            entity SelectedEntity = (VMTabs.CurrentElement.DataContext as VMTabs).Modell.Entity;
            switch (SelectedEntity)
            {
                case entity.Libraries:

                    VMMW.CurrentPage = new LibraryRedacPage(new LibrariesContext(), modell as LibrariesModell);
                    break;
                case entity.Fonds:
                    VMMW.CurrentPage = new FondRedacPage(new FondsContext(), modell as FondsModell);
                    break;
                case entity.Sources:
                    VMMW.CurrentPage = new SourceRedacPage(new LiteratureSourcesContext(), modell as Literature_sourcesModell);
                    break;
                case entity.Types:
                    VMMW.CurrentPage = new TypeRedacPage(new LiteratureTypesContext(), modell as Literature_typesModell);
                    break;
                case entity.Workers:
                    VMMW.CurrentPage = new WorkerRedacPage(new WorkersContext(), modell as WorkersModell);
                    break;
                case entity.Replenishments:
                    VMMW.CurrentPage = new ReplenishmentRedacPage(new ReplenishmentsContext(), modell as ReplenishmentsModell);
                    break;
            }
        }
    }
}

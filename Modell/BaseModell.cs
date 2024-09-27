using Libraries.Contexts;
using Libraries.View.Pages.CommonPages;
using Libraries.View.Pages.Fond;
using Libraries.View.Pages.Library;
using Libraries.View.Pages.LiteratureSource;
using Libraries.View.Pages.LiteratureType;
using Libraries.View.Pages.Replenishment;
using Libraries.View.Pages.Worker;
using Libraries.ViewModell;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using static Libraries.Modell.TabsModell;

namespace Libraries.Modell
{
    public class BaseModell : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public static List<UserControl> CreateItems(TabElement element)
        {
            VMTabs.CurrentElement = element;
            List<UserControl> Items = new List<UserControl>();
            entity SelectedEntity = (element.DataContext as VMTabs).Modell.Entity;
            MessageBox.Show(SelectedEntity.ToString());
            switch (SelectedEntity)
            {
                case entity.Libraries:
                    LibrariesContext libraries = new LibrariesContext();
                    foreach (LibrariesModell library in libraries.Libraries)
                    {
                        Items.Add(new LibraryItem(library, libraries));
                    }
                    break;
                case entity.Fonds:
                    FondsContext fonds = new FondsContext();
                    foreach (FondsModell fond in fonds.Fonds)
                    {
                        Items.Add(new FondItem(fond, fonds));
                    }
                    break;
                case entity.Sources:
                    LiteratureSourcesContext sources = new LiteratureSourcesContext();
                    foreach (Literature_sourcesModell source in sources.Literature_sources)
                    {
                        Items.Add(new SourceItem(source, sources));
                    }
                    break;
                case entity.Types:
                    LiteratureTypesContext types = new LiteratureTypesContext();
                    foreach (Literature_typesModell type in types.Literature_types)
                    {
                        Items.Add(new TypeItem(type, types));
                    }
                    break;
                case entity.Workers:
                    WorkersContext workers = new WorkersContext();
                    foreach (WorkersModell worker in workers.Workers)
                    {
                        Items.Add(new WorkerItem(worker, workers));
                    }
                    break;
                case entity.Replenishments:
                    ReplenishmentsContext replenishments = new ReplenishmentsContext();
                    foreach (ReplenishmentsModell replenishment in replenishments.Replenishments)
                    {
                        Items.Add(new ReplenishmentItem(replenishment, replenishments));
                    }
                    break;
            }
            return Items;
        }
    }
}

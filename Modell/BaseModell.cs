using Libraries.Contexts;
using Libraries.View.Pages.CommonPages;
using Libraries.View.Pages.Library;
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
        private model _model;
        public model Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }
        public enum model { library, fond, type, source, worker, replenishment }
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
                        Items.Add(new LibraryItem(library));
                    }
                    break;
                case entity.Fonds:
                    FondsContext fonds = new FondsContext();
                    foreach (FondsModell fond in fonds.Fonds)
                    {
                        //Items.Add(new FondItem(fond));
                    }
                    break;
                    //case entity.Sources:
                    //    LiteratureSourcesContext sources = new LiteratureSourcesContext();
                    //    foreach (Literature_sourceModell source in sources.Literature_sources)
                    //    {
                    //        Items.Add(new LiteratureSourceItem(source));
                    //    }
                    //    break;
                    //case entity.Types:
                    //    LiteratureTypesContext types = new LiteratureTypesContext();
                    //    foreach (Literature_typesModell type in types.Literature_types)
                    //    {
                    //        Items.Add(new LiteratureTypeItem(type));
                    //    }
                    //    break;
                    //case entity.Workers:
                    //    WorkersContext workers = new WorkersContext();
                    //    foreach (WorkersModell worker in workers.Workers)
                    //    {
                    //        Items.Add(new WorketItem(worker));
                    //    }
                    //    break;
                    //case entity.Replenishments:
                    //    ReplenishmentsContext replenishments = new ReplenishmentsContext();
                    //    foreach (ReplenishmentsModell replenishment in replenishments.Replenishments)
                    //    {
                    //        Items.Add(new ReplenishmentItem(replenishment));
                    //    }
                    //    break;
            }
            return Items;
        }
    }
}

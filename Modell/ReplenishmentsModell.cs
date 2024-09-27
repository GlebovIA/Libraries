using Libraries.Contexts;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows;

namespace Libraries.Modell
{
    public class ReplenishmentsModell : BaseModell
    {
        private int _id;
        private int _fond;
        private string _fondName;
        private int _worker;
        private string _workerName;
        private DateTime _date;
        private int _literatureSource;
        private string _sourceName;
        private int _literatureType;
        private string _typeName;
        private string _publishingCompany;
        private DateTime _publishingDate;
        private int _copyCount;
        [Key]
        public int Id_replenishment
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id_replenishment));
            }
        }
        public int Fond
        {
            get { return _fond; }
            set
            {
                _fond = value;
                OnPropertyChanged(nameof(Fond));
            }
        }
        public int Worker
        {
            get { return _worker; }
            set
            {
                _worker = value;
                OnPropertyChanged(nameof(Worker));
            }
        }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        public int Literature_source
        {
            get { return _literatureSource; }
            set
            {
                _literatureSource = value;
                OnPropertyChanged(nameof(Literature_source));
            }
        }
        public int Literature_type
        {
            get { return _literatureType; }
            set
            {
                _literatureType = value;
                OnPropertyChanged(nameof(_literatureType));
            }
        }
        public string Publishing_company
        {
            get { return _publishingCompany; }
            set
            {
                _publishingCompany = value;
                OnPropertyChanged(nameof(Publishing_company));
            }
        }
        public DateTime Publishing_date
        {
            get { return _publishingDate; }
            set
            {
                _publishingDate = value;
                OnPropertyChanged(nameof(Publishing_date));
            }
        }
        public int Copy_count
        {
            get { return _copyCount; }
            set
            {
                _copyCount = value;
                OnPropertyChanged(nameof(Copy_count));
            }
        }
        [NotMapped]
        public string GetFond
        {
            get { return _fondName; }
            set
            {
                _fondName = (new FondsContext()).Fonds.Where(x => x.Id_fond == _fond).First().Fond_name;
            }
        }
        [NotMapped]
        public string GetDate
        {
            get { return "Пополнение от: " + _date.ToString("dd.MM.yyyy"); }
        }
        [NotMapped]
        public ObservableCollection<FondsModell> AllFonds
        {
            get { return new ObservableCollection<FondsModell>(new FondsContext().Fonds); }
        }
        [NotMapped]
        public ObservableCollection<WorkersModell> AllWorkers
        {
            get { return new ObservableCollection<WorkersModell>(new WorkersContext().Workers); }
        }
        [NotMapped]
        public ObservableCollection<Literature_sourcesModell> AllSources
        {
            get { return new ObservableCollection<Literature_sourcesModell>(new LiteratureSourcesContext().Literature_sources); }
        }
        [NotMapped]
        public ObservableCollection<Literature_typesModell> AllTypes
        {
            get { return new ObservableCollection<Literature_typesModell>(new LiteratureTypesContext().Literature_types); }
        }
        [NotMapped]
        public FondsModell SelectedFond
        {
            get { if (Fond == 0) return AllFonds.First(); else return AllFonds.Where(x => x.Id_fond == Fond).First(); }
            set { MessageBox.Show(value.Fond_name); Fond = value.Id_fond; OnPropertyChanged(nameof(SelectedFond)); }
        }
        [NotMapped]
        public WorkersModell SelectedWorker
        {
            get { if (Worker == 0) return AllWorkers.First(); else return AllWorkers.Where(x => x.Id_worker == Worker).First(); }
            set { MessageBox.Show(value.GetFio); Worker = value.Id_worker; OnPropertyChanged(nameof(SelectedWorker)); }
        }
        [NotMapped]
        public Literature_sourcesModell SelectedSource
        {
            get { if (Literature_source == 0) return AllSources.First(); else return AllSources.Where(x => x.Id_source == Literature_source).First(); }
            set { MessageBox.Show(value.Source_name); Literature_source = value.Id_source; OnPropertyChanged(nameof(SelectedSource)); }
        }
        [NotMapped]
        public Literature_typesModell SelectedType
        {
            get { if (Literature_type == 0) return AllTypes.First(); else return AllTypes.Where(x => x.Id_type == Literature_type).First(); }
            set { MessageBox.Show(value.Type_name); Literature_type = value.Id_type; OnPropertyChanged(nameof(SelectedType)); }
        }
    }
}

using Libraries.Contexts;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        public string GetFond
        {
            get { return _fondName; }
            set
            {
                _fondName = (new FondsContext()).Fonds.Where(x => x.Id_fond == _fond).First().Fond_name;
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
        public string GetWorker
        {
            get { return _workerName; }
            set
            {
                _workerName = (new WorkersContext()).Workers.Where(x => x.Id_worker == _worker).First().GetFio;
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
        public string GetLiteratureSource
        {
            get { return _sourceName; }
            set
            {
                _sourceName = (new LiteratureSourcesContext()).Literature_sources.Where(x => x.Id_source == _literatureSource).First().Source_name;
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
        public string GetLiteratureType
        {
            get { return _typeName; }
            set
            {
                _typeName = (new LiteratureTypesContext()).Literature_types.Where(x => x.Id_type == _literatureType).First().Type_name;
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
        public ReplenishmentsModell() => Model = model.replenishment;
    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Libraries.Modell
{
    public class Replenishments
    {
        private int _id;
        public int Id_replenishment
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id_replenishment));
            }
        }
        private int _fond;
        public int Fond
        {
            get { return _fond; }
            set
            {
                _fond = value;
                OnPropertyChanged(nameof(Fond));
            }
        }
        private int _worker;
        public int Worker
        {
            get { return _worker; }
            set
            {
                _worker = value;
                OnPropertyChanged(nameof(Worker));
            }
        }
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        private int _literatureSource;
        public int Literature_source
        {
            get { return _literatureSource; }
            set
            {
                _literatureSource = value;
                OnPropertyChanged(nameof(Literature_source));
            }
        }
        private int _literatureType;
        public int Literature_type
        {
            get { return _literatureType; }
            set
            {
                _literatureType = value;
                OnPropertyChanged(nameof(_literatureType));
            }
        }
        private string _publishingCompany;
        public string Publishing_company
        {
            get { return _publishingCompany; }
            set
            {
                _publishingCompany = value;
                OnPropertyChanged(nameof(Publishing_company));
            }
        }
        private DateTime _publishingDate;
        public DateTime Publishing_date
        {
            get { return _publishingDate; }
            set
            {
                _publishingDate = value;
                OnPropertyChanged(nameof(Publishing_date));
            }
        }
        private int _copyCount;
        public int Copy_count
        {
            get { return _copyCount; }
            set
            {
                _copyCount = value;
                OnPropertyChanged(nameof(Copy_count));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

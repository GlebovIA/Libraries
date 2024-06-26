using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Libraries.Modell
{
    public class Fonds : INotifyPropertyChanged
    {
        private int _id;
        public int Id_fond
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id_fond));
            }
        }
        private string _name;
        public string Fond_name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Fond_name));
            }
        }
        private int _bookCount;
        public int Book_count
        {
            get { return _bookCount; }
            set
            {
                _bookCount = value;
                OnPropertyChanged(nameof(Book_count));
            }
        }
        private int _journalCount;
        public int Journal_count
        {
            get { return _journalCount; }
            set
            {
                _journalCount = value;
                OnPropertyChanged(nameof(Journal_count));
            }
        }
        private int _newspapperCount;
        public int Newspapper_count
        {
            get { return _newspapperCount; }
            set
            {
                _newspapperCount = value;
                OnPropertyChanged(nameof(_newspapperCount));
            }
        }
        private int _collectionCount;
        public int Collection_count
        {
            get { return _collectionCount; }
            set
            {
                _collectionCount = value;
                OnPropertyChanged(nameof(Collection_count));
            }
        }
        private int _dissertationCount;
        public int Dissertation_count
        {
            get { return _dissertationCount; }
            set
            {
                _dissertationCount = value;
                OnPropertyChanged(nameof(Dissertation_count));
            }
        }
        private int _reportCount;
        public int Report_count
        {
            get { return _reportCount; }
            set
            {
                _reportCount = value;
                OnPropertyChanged(nameof(Report_count));
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

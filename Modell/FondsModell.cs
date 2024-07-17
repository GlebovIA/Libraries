using Libraries.Contexts;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Libraries.Modell
{
    public class FondsModell : BaseModell
    {
        private int _id;
        private string _name;
        private int _library;
        private string _libraryName;
        private int _bookCount;
        private int _journalCount;
        private int _newspapperCount;
        private int _collectionCount;
        private int _dissertationCount;
        private int _reportCount;
        [Key]
        public int Id_fond
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id_fond));
            }
        }
        public string Fond_name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Fond_name));
            }
        }
        public int Library
        {
            get { return _library; }
            set
            {
                _library = value;
                OnPropertyChanged(nameof(Library));
            }
        }
        public string GetLibrary
        {
            get { return _libraryName; }
            set
            {
                _libraryName = (new LibrariesContext()).Libraries.Where(x => x.Id_library == _library).First().Library_name;
            }
        }
        public int Book_count
        {
            get { return _bookCount; }
            set
            {
                _bookCount = value;
                OnPropertyChanged(nameof(Book_count));
            }
        }
        public int Journal_count
        {
            get { return _journalCount; }
            set
            {
                _journalCount = value;
                OnPropertyChanged(nameof(Journal_count));
            }
        }
        public int Newspapper_count
        {
            get { return _newspapperCount; }
            set
            {
                _newspapperCount = value;
                OnPropertyChanged(nameof(_newspapperCount));
            }
        }
        public int Collection_count
        {
            get { return _collectionCount; }
            set
            {
                _collectionCount = value;
                OnPropertyChanged(nameof(Collection_count));
            }
        }
        public int Dissertation_count
        {
            get { return _dissertationCount; }
            set
            {
                _dissertationCount = value;
                OnPropertyChanged(nameof(Dissertation_count));
            }
        }
        public int Report_count
        {
            get { return _reportCount; }
            set
            {
                _reportCount = value;
                OnPropertyChanged(nameof(Report_count));
            }
        }
        public FondsModell() => Model = model.fond;
    }
}

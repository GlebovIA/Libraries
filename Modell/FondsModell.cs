using Libraries.Contexts;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows;

namespace Libraries.Modell
{
    public class FondsModell : BaseModell
    {
        private int _id;
        private string _name;
        private int _library;
        private int _bookCount;
        private int _journalCount;
        private int _newspaperCount;
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
        [ForeignKey(nameof(Library))]
        public int Library
        {
            get { return _library; }
            set
            {
                _library = value;
                OnPropertyChanged(nameof(Library));
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
        public int Newspaper_count
        {
            get { return _newspaperCount; }
            set
            {
                _newspaperCount = value;
                OnPropertyChanged(nameof(_newspaperCount));
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
        [NotMapped]
        public string ThisLibrary
        {
            get { return AllLibraries.Where(x => x.Id_library == _library).First().Library_name; }
        }
        [NotMapped]
        public ObservableCollection<LibrariesModell> AllLibraries
        {
            get { return new ObservableCollection<LibrariesModell>(new LibrariesContext().Libraries); }
        }
        [NotMapped]
        public LibrariesModell SelectedLibrary
        {
            get { if (Library == 0) return AllLibraries.First(); else return AllLibraries.Where(x => x.Id_library == Library).First(); }
            set { MessageBox.Show(value.Library_name); Library = value.Id_library; OnPropertyChanged(nameof(SelectedLibrary)); }
        }
    }
}

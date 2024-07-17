using System.ComponentModel.DataAnnotations;

namespace Libraries.Modell
{
    public class Literature_sourceModell : BaseModell
    {
        private int _id;
        private string _sourceName;
        [Key]
        public int Id_source
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id_source));
            }
        }
        public string Source_name
        {
            get { return _sourceName; }
            set
            {
                _sourceName = value;
                OnPropertyChanged(nameof(Source_name));
            }
        }
        public Literature_sourceModell() => Model = model.source;
    }
}

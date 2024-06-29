using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Libraries.Modell
{
    public class Literature_sourceModell : INotifyPropertyChanged
    {
        private int _id;
        public int Id_source
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id_source));
            }
        }
        private string _sourceName;
        public string Source_name
        {
            get { return _sourceName; }
            set
            {
                _sourceName = value;
                OnPropertyChanged(nameof(Source_name));
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

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Libraries.Modell
{
    public class Literature_typesModell : INotifyPropertyChanged
    {
        private int _id;
        public int Id_type
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id_type));
            }
        }
        private string _typeName;
        public string Type_name
        {
            get { return _typeName; }
            set
            {
                _typeName = value;
                OnPropertyChanged(nameof(Type_name));
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

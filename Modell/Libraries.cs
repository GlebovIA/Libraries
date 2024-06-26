using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Libraries.Modell
{
    public class Libraries : INotifyPropertyChanged
    {
        private int _id;
        public int Id_library
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id_library));
            }
        }
        private string _name;
        public string Library_name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Library_name));
            }
        }
        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
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

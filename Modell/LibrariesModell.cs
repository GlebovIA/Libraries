using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libraries.Modell
{
    public class LibrariesModell : BaseModell
    {
        private int _id;
        private string _name;
        private string _city;
        private string _address;
        [Key]
        public int Id_library
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id_library));
            }
        }
        public string Library_name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Library_name));
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        [NotMapped]
        public string FullAddress
        {
            get { return "г. " + City + " ул. " + Address; }
        }
    }
}

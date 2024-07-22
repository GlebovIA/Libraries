using System.ComponentModel.DataAnnotations;

namespace Libraries.Modell
{
    public class Literature_typesModell : BaseModell
    {
        private int _id;
        private string _typeName;
        [Key]
        public int Id_type
        {
            get { return _id; }
            set
            {
                _id = value;
                Id = _id;
                OnPropertyChanged(nameof(Id_type));
            }
        }
        public string Type_name
        {
            get { return _typeName; }
            set
            {
                _typeName = value;
                OnPropertyChanged(nameof(Type_name));
            }
        }
    }
}

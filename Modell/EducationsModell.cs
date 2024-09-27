using System.ComponentModel.DataAnnotations;

namespace Libraries.Modell
{
    public class EducationsModell : BaseModell
    {
        private int _idEducation;
        private string _education;
        [Key]
        public int Id_education
        {
            get { return _idEducation; }
            set
            {
                _idEducation = value;
                OnPropertyChanged(nameof(Id_education));
            }
        }
        public string Education
        {
            get { return _education; }
            set
            {
                _education = value;
                OnPropertyChanged(nameof(Education));
            }
        }
    }
}

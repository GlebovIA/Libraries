using System.ComponentModel.DataAnnotations;

namespace Libraries.Modell
{
    public class JobsModell : BaseModell
    {
        private int _idJob;
        private string _jobName;
        [Key]
        public int Id_job
        {
            get { return _idJob; }
            set
            {
                _idJob = value;
                OnPropertyChanged(nameof(Id_job));
            }
        }
        public string Job_name
        {
            get { return _jobName; }
            set
            {
                _jobName = value;
                OnPropertyChanged(nameof(Job_name));
            }
        }
    }
}

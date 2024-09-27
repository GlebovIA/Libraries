using Libraries.Contexts;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows;

namespace Libraries.Modell
{
    public class WorkersModell : BaseModell
    {
        private int _id;
        private string _workerSurname;
        private string _workerName;
        private string _workerPatronymic;
        private int _library;
        private int _job;
        private DateTime _birthDate;
        private DateTime _admissionDate;
        private int _education;
        private decimal _salary;
        private string _fio;
        [Key]
        public int Id_worker
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id_worker));
            }
        }
        public string Worker_surname
        {
            get { return _workerSurname; }
            set
            {
                _workerSurname = value;
                OnPropertyChanged(nameof(Worker_surname));
            }
        }
        public string Worker_name
        {
            get { return _workerName; }
            set
            {
                _workerName = value;
                OnPropertyChanged(nameof(Worker_name));
            }
        }
        public string Worker_patronymic
        {
            get { return _workerPatronymic; }
            set
            {
                _workerPatronymic = value;
                OnPropertyChanged(nameof(Worker_patronymic));
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
        public int Job
        {
            get { return _job; }
            set
            {
                _job = value;
                OnPropertyChanged(nameof(Job));
            }
        }
        public DateTime Birth_date
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged(nameof(Birth_date));
            }
        }
        public DateTime Admission_date
        {
            get { return _admissionDate; }
            set
            {
                _admissionDate = value;
                OnPropertyChanged(nameof(Admission_date));
            }
        }
        public int Education
        {
            get { return _education; }
            set
            {
                _education = value;
                OnPropertyChanged(nameof(Education));
            }
        }
        public decimal Salary
        {
            get { return _salary; }
            set
            {
                _salary = value;
                OnPropertyChanged(nameof(Salary));
            }
        }
        [NotMapped]
        public string GetFio
        {
            get { return _workerSurname + " " + _workerName + " " + _workerPatronymic; }
        }
        [NotMapped]
        public string ThisLibrary
        {
            get { return SelectedLibrary.Library_name; }
        }
        [NotMapped]
        public ObservableCollection<LibrariesModell> AllLibraries
        {
            get { return new ObservableCollection<LibrariesModell>(new LibrariesContext().Libraries); }
        }
        [NotMapped]
        public ObservableCollection<JobsModell> AllJobs
        {
            get { return new ObservableCollection<JobsModell>(new JobsContext().Jobs); }
        }
        [NotMapped]
        public ObservableCollection<EducationsModell> AllEducations
        {
            get { return new ObservableCollection<EducationsModell>(new EducationsContext().Educations); }
        }
        [NotMapped]
        public LibrariesModell SelectedLibrary
        {
            get { if (Library == 0) return AllLibraries.First(); else return AllLibraries.Where(x => x.Id_library == Library).First(); }
            set { MessageBox.Show(value.Library_name); Library = value.Id_library; OnPropertyChanged(nameof(SelectedLibrary)); }
        }
        [NotMapped]
        public JobsModell SelectedJob
        {
            get { if (Job == 0) return AllJobs.First(); else return AllJobs.Where(x => x.Id_job == Job).First(); }
            set { MessageBox.Show(value.Job_name); Job = value.Id_job; OnPropertyChanged(nameof(SelectedJob)); }
        }
        [NotMapped]
        public EducationsModell SelectedEducation
        {
            get { if (Education == 0) return AllEducations.First(); else return AllEducations.Where(x => x.Id_education == Education).First(); }
            set { MessageBox.Show(value.Education); Education = value.Id_education; OnPropertyChanged(nameof(SelectedEducation)); }
        }
    }
}

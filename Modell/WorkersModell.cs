using Libraries.Contexts;
using System;
using System.Linq;

namespace Libraries.Modell
{
    public class WorkersModell : BaseModell
    {
        private int _id;
        private string _workerSurname;
        private string _workerName;
        private string _workerLastname;
        private int _library;
        private string _libraryName;
        private string _job;
        private DateTime _birthDate;
        private DateTime _admissionDate;
        private string _education;
        private int _copyCount;
        private string _fio;
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
        public string Worker_lastname
        {
            get { return _workerLastname; }
            set
            {
                _workerLastname = value;
                OnPropertyChanged(nameof(Worker_lastname));
            }
        }
        public int Library
        {
            get { return _library; }
            set
            {
                _library = value;
                OnPropertyChanged(nameof(Library));
            }
        }
        public string GetLibrary
        {
            get { return _libraryName; }
            set
            {
                _libraryName = (new LibrariesContext()).Libraries.Where(x => x.Id_library == _library).First().Library_name;
            }
        }
        public string Job
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
        public string Education
        {
            get { return _education; }
            set
            {
                _education = value;
                OnPropertyChanged(nameof(Education));
            }
        }
        public int Copy_count
        {
            get { return _copyCount; }
            set
            {
                _copyCount = value;
                OnPropertyChanged(nameof(Copy_count));
            }
        }
        public string GetFio
        {
            get { return _fio; }
            set
            {
                _fio = _workerSurname + " " + _workerName + " " + _workerLastname;
            }
        }
        public WorkersModell() => Model = model.worker;
    }
}

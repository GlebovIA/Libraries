using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Libraries.Modell
{
    public class WorkersModell : INotifyPropertyChanged
    {
        private int _id;
        public int Id_worker
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id_worker));
            }
        }
        private string _workerSurname;
        public string Worker_surname
        {
            get { return _workerSurname; }
            set
            {
                _workerSurname = value;
                OnPropertyChanged(nameof(Worker_surname));
            }
        }
        private string _workerName;
        public string Worker_name
        {
            get { return _workerName; }
            set
            {
                _workerName = value;
                OnPropertyChanged(nameof(Worker_name));
            }
        }
        private string _workerLastname;
        public string Worker_lastname
        {
            get { return _workerLastname; }
            set
            {
                _workerLastname = value;
                OnPropertyChanged(nameof(Worker_lastname));
            }
        }
        private int _library;
        public int Library
        {
            get { return _library; }
            set
            {
                _library = value;
                OnPropertyChanged(nameof(Library));
            }
        }
        private string _job;
        public string Job
        {
            get { return _job; }
            set
            {
                _job = value;
                OnPropertyChanged(nameof(Job));
            }
        }
        private DateTime _birthDate;
        public DateTime Birth_date
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged(nameof(Birth_date));
            }
        }
        private DateTime _admissionDate;
        public DateTime Admission_date
        {
            get { return _admissionDate; }
            set
            {
                _admissionDate = value;
                OnPropertyChanged(nameof(Admission_date));
            }
        }
        private string _education;
        public string Education
        {
            get { return _education; }
            set
            {
                _education = value;
                OnPropertyChanged(nameof(Education));
            }
        }
        private int _copyCount;
        public int Copy_count
        {
            get { return _copyCount; }
            set
            {
                _copyCount = value;
                OnPropertyChanged(nameof(Copy_count));
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

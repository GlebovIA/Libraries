using Libraries.Contexts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Libraries.Modell
{
    public class UserModell : INotifyPropertyChanged
    {
        private int _id;
        private string _login;
        private string _role;
        [Key]
        public int Id_user
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id_user));
            }
        }
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Role
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }
        public static usersRole CurrentUser { get; set; }
        public enum usersRole
        {
            Admin,
            Librarian,
            Reader
        }
        public static void CreateUser(string login)
        {
            UsersContext context = new UsersContext();
            string role = context.Users.Where(x => x.Login == login).First().Role;
            CurrentUser = DefineRole(role);
            MessageBox.Show(CurrentUser.ToString());
        }
        private static usersRole DefineRole(string roleString)
        {
            if (roleString == usersRole.Admin.ToString())
                return usersRole.Admin;
            if (roleString == usersRole.Librarian.ToString())
                return usersRole.Librarian;
            else return usersRole.Reader;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

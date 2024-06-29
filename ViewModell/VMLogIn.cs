using Libraries.Classes;
using Libraries.Modell;
using Libraries.View.Pages.CommonPages;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Libraries.ViewModell
{
    public class VMLogIn : INotifyPropertyChanged
    {
        public LogInModell logIn { get; set; }
        private static AuthorizationPage AP { get; set; }
        public VMLogIn(AuthorizationPage ap)
        {
            AP = ap;
            logIn = new LogInModell();
        }
        public RelayCommand LogIn
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    logIn.DoLogIn(AP.loginTBx.Text, AP.passwordPBx.Password);
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

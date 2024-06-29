using Libraries.View.Pages.CommonPages;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Libraries.Modell
{
    public class MainModell : INotifyPropertyChanged
    {
        public void AllTabs(MainPage mp)
        {
            mp.TabList.ItemsSource = TabsModell.CreateTabs();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

using Libraries.View.Pages.CommonPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using static System.Windows.Media.Brushes;

namespace Libraries.Modell
{
    public class TabsModell : INotifyPropertyChanged
    {
        private int _id { get; set; }
        private string _name { get; set; }
        private string _image { get; set; }
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        public static List<TabElement> AccessibleEntities { get; set; }
        public TabsModell(string name, string img, int idElement)
        {
            Name = name;
            Image = img;
            Id = idElement;
        }
        public static List<TabElement> CreateTabs()
        {
            AccessibleEntities = new List<TabElement>();
            AccessibleEntities.Add(new TabElement(new TabsModell("Библиотеки", "/Resources/Images/library.png", 1)));
            AccessibleEntities.Add(new TabElement(new TabsModell("Фонды", "/Resources/Images/fonds.png", 2)));
            AccessibleEntities.Add(new TabElement(new TabsModell("Типы литературы", "/Resources/Images/literatureTypes.png", 3)));
            AccessibleEntities.Add(new TabElement(new TabsModell("Носители литературы", "/Resources/Images/literatureSources.png", 4)));
            if (UserModell.CurrentUser == UserModell.usersRole.Librarian || UserModell.CurrentUser == UserModell.usersRole.Admin)
            {
                AccessibleEntities.Add(new TabElement(new TabsModell("Пополнения фондов", "/Resources/Images/replenishments.png", 5)));
                AccessibleEntities.Add(new TabElement(new TabsModell("Сотрудники", "/Resources/Images/workers.png", 6)));
            }
            foreach (TabElement tab in AccessibleEntities)
            {
                tab.MouseEnter += (s, a) => MouseEnterAction(s, a);
                tab.MouseLeave += (s, a) => MouseLeaveAction(s, a);
            }
            return AccessibleEntities;
        }
        private static void MouseEnterAction(object sender, EventArgs e)
        {
            TabElement item = sender as TabElement;
            item.BorderThickness = new Thickness(2);
            item.BorderBrush = Gray;
        }
        private static void MouseLeaveAction(object sender, EventArgs e)
        {
            TabElement item = sender as TabElement;
            item.BorderThickness = new Thickness(0);
            item.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 239, 208, 168));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

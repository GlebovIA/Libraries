using Libraries.View.Pages.CommonPages;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using static System.Windows.Media.Brushes;

namespace Libraries.Modell
{
    public class TabsModell : BaseModell
    {
        public enum entity
        {
            Libraries, Fonds, Types, Sources, Workers, Replenishments, Educations, Jobs
        }
        private entity _entity { get; set; }
        private string _name { get; set; }
        private string _image { get; set; }
        public entity Entity
        {
            get { return _entity; }
            set
            {
                _entity = value;
                OnPropertyChanged(nameof(Entity));
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
        public static MainPage MP { get; set; }
        public static List<TabElement> AccessibleEntities { get; set; }
        public TabsModell(string name, string img, entity entity)
        {
            Name = name;
            Image = img;
            Entity = entity;
        }
        public static List<TabElement> CreateTabs(MainPage mp)
        {
            MP = mp;
            AccessibleEntities = new List<TabElement>
            {
                new TabElement(new TabsModell("Библиотеки", "/Resources/Images/library.png", entity.Libraries)),
                new TabElement(new TabsModell("Фонды", "/Resources/Images/fonds.png", entity.Fonds)),
                new TabElement(new TabsModell("Типы литературы", "/Resources/Images/literatureTypes.png", entity.Types)),
            };
            if (UsersModell.CurrentUser == UsersModell.usersRole.Librarian || UsersModell.CurrentUser == UsersModell.usersRole.Admin)
            {
                AccessibleEntities.Add(new TabElement(new TabsModell("Носители литературы", "/Resources/Images/literatureSources.png", entity.Sources)));
                AccessibleEntities.Add(new TabElement(new TabsModell("Пополнения фондов", "/Resources/Images/replenishments.png", entity.Replenishments)));
                AccessibleEntities.Add(new TabElement(new TabsModell("Сотрудники", "/Resources/Images/workers.png", entity.Workers)));
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
    }
}

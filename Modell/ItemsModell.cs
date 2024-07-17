namespace Libraries.Modell
{
    public class ItemsModell
    {
        public LibrariesModell Library { get; set; }
        public ItemsModell(object modell, TabsModell.entity entity)
        {
            switch (entity)
            {
                case TabsModell.entity.Libraries:
                    Library = modell as LibrariesModell;
                    break;
            }
        }

    }
}

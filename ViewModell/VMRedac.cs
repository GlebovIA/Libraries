using Libraries.Classes;
using Libraries.Contexts;
using Libraries.Modell;

namespace Libraries.ViewModell
{
    public class VMRedac
    {
        public BaseModell Modell { get; set; }
        public BaseContext Context { get; set; }
        public bool IsNew { get; set; }
        public VMRedac(BaseModell modell, BaseContext context, bool isNew = true)
        {
            Modell = modell;
            Context = context;
            IsNew = isNew;
        }
        public RelayCommand Apply
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    BaseContext.Edit(Modell, Context, IsNew);
                });
            }
        }
        public RelayCommand Cancell
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    BaseContext.Cancell();
                });
            }
        }

    }
}

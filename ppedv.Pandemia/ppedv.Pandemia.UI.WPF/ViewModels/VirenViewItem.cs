using ppedv.Pandemia.Model;
using System.Linq;

namespace ppedv.Pandemia.UI.WPF.ViewModels
{
    public class VirenViewItem : ViewModelBase
    {

        public Virus Virus { get; }
        public VirenViewItem(Virus virus)
        {
            this.Virus = virus;
        }
        public string Name
        {
            get
            {
                if (Virus == null)
                    return "--";

                return Virus.Name;
            }
            set
            {
                //   if (string.IsNullOrWhiteSpace(value))
                //       throw new ValidationException("blöd!");

                if (Virus != null)
                    Virus.Name = value;

                IChanged();
                OnPropChanged("");
            }
        }

        public string Namelength
        {
            get
            {
                if (Virus == null)
                    return "--";
                return Virus.Name.Length.ToString();
            }
        }
        public int AnzahlInfektionen { get => Virus.Infektionen.Count; }

    }
}

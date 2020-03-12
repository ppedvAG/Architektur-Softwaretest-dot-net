using ppedv.Pandemia.Logic;
using ppedv.Pandemia.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ppedv.Pandemia.UI.WPF.ViewModels
{
    public class VirenViewModel : ViewModelBase
    {
        Core core = new Core();
        private Virus selectedVirus;

        public ObservableCollection<Virus> Virenliste { get; set; }

        public Virus SelectedVirus
        {
            get => selectedVirus;
            set
            {
                selectedVirus = value;
                IChanged();
                OnPropChanged(nameof(Name));
            }
        }

        public ICommand SaveCommand { get; set; }

        public VirenViewModel()
        {
            Virenliste = new ObservableCollection<Virus>(core.Repository.GetAll<Virus>());

            SaveCommand = new RelayCommand(o => core.Repository.SaveAll());
        }

        public string Name
        {
            get
            {
                if (SelectedVirus == null)
                    return "--";

                return SelectedVirus.Name;
            }
            set
            {
                //   if (string.IsNullOrWhiteSpace(value))
                //       throw new ValidationException("blöd!");

                if (SelectedVirus != null)
                    SelectedVirus.Name = value;

                OnPropChanged("");
                IChanged();
                

                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Namelength)));

            }
        }

        public string Namelength
        {
            get
            {
                if (SelectedVirus == null)
                    return "--";
                return SelectedVirus.Name.Length.ToString();
            }
        }



    }
}

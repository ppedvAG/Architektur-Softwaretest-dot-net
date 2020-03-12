using ppedv.Pandemia.Logic;
using ppedv.Pandemia.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ppedv.Pandemia.UI.WPF.ViewModels
{
    public class VirenViewModel : ViewModelBase
    {
        Core core = new Core();
        private VirenViewItem selectedVirus;

        public ObservableCollection<VirenViewItem> Virenliste { get; set; } = new ObservableCollection<VirenViewItem>();

        public VirenViewItem SelectedVirus
        {
            get => selectedVirus;
            set
            {
                selectedVirus = value;
                IChanged();
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand NewCommand { get; set; }

        public VirenViewModel()
        {
            LoadViren();

            SaveCommand = new RelayCommand(o => core.Repository.SaveAll());
            LoadCommand = new RelayCommand(o => LoadViren());
            NewCommand = new RelayCommand(CreateNewVirus);
        }

        private void CreateNewVirus(object obj)
        {
            var newVirus = new Virus() { Name = "NEU" };
            core.Repository.Add(newVirus);

            var newItem = new VirenViewItem(newVirus);
            Virenliste.Add(newItem);

            SelectedVirus = newItem;
        }

        private void LoadViren()
        {
            Virenliste.Clear();
            core.Repository.GetAll<Virus>().ToList().ForEach(x => Virenliste.Add(new VirenViewItem(x)));
        }
    }
}

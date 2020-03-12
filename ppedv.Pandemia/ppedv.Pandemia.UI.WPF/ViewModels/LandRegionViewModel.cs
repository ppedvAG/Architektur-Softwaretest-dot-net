using ppedv.Pandemia.Logic;
using ppedv.Pandemia.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ppedv.Pandemia.UI.WPF.ViewModels
{
    public class LandRegionViewModel
    {
        Core core = new Core();
        public ObservableCollection<LandTreeViewItem> LandTreeViewItems { get; set; } = new ObservableCollection<LandTreeViewItem>();

        public ICommand LoadCommand { get; set; }
        public LandRegionViewModel()
        {
            LoadCommand = new RelayCommand(o => LoadAll());
            LoadDemo();
            //LoadAll();

        }

        private void LoadDemo()
        {
            var v = new Virus() { Name = "Becks" };

            for (int i = 0; i < 10; i++)
            {
                var l = new Land() { Name = $"l{i:00}" };
                var rl = new Region() { Land = l };
                l.Region.Add(rl);

                var inf = new Infektion() { Person = $"Fred #{i:000}" };
                inf.Wohnort = rl;
                rl.Infektionen.Add(inf);

                v.Infektionen.Add(inf);


                var ltvi = new LandTreeViewItem(l);
                var vtvi = new VirusTreeViewItem(v);
                ltvi.Viren.Add(vtvi);
                var itvi = new InfektionsTreeViewItem(inf);
                vtvi.Infektionen.Add(itvi);

                LandTreeViewItems.Add(ltvi);
            }

        }

        private void LoadAll()
        {
            LandTreeViewItems.Clear();
            foreach (var l in core.Repository.GetAll<Land>())
            {
                var ltvi = new LandTreeViewItem(l);
                foreach (var r in l.Region)
                {
                    foreach (var i in r.Infektionen)
                    {
                        foreach (var v in i.Viren)
                        {
                            var vtvi = new VirusTreeViewItem(v);
                            ltvi.Viren.Add(vtvi);

                            foreach (var vi in v.Infektionen)
                            {
                                var itvi = new InfektionsTreeViewItem(vi);
                                vtvi.Infektionen.Add(itvi);
                            }
                        }

                    }
                }
                LandTreeViewItems.Add(ltvi);
            }
        }
    }

    public class LandTreeViewItem : ViewModelBase
    {
        public Land Land { get; }

        public LandTreeViewItem(Land land)
        {
            this.Land = land;
        }

        public ObservableCollection<VirusTreeViewItem> Viren { get; set; } = new ObservableCollection<VirusTreeViewItem>();

    }

    public class VirusTreeViewItem : ViewModelBase
    {
        public Virus Virus { get; }
        public VirusTreeViewItem(Virus virus)
        {
            this.Virus = virus;
        }
        public ObservableCollection<InfektionsTreeViewItem> Infektionen { get; set; } = new ObservableCollection<InfektionsTreeViewItem>();

    }
    public class InfektionsTreeViewItem : ViewModelBase
    {
        public Infektion Infektion { get; set; }

        public string VirenCount { get => Infektion.Viren.Count().ToString(); }
        public InfektionsTreeViewItem(Infektion inf)
        {
            this.Infektion = inf;
        }
    }
}

using ppedv.Pandemia.Logic;
using ppedv.Pandemia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Pandemia.UI.DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Pandemia v0.1 ***");
            var core = new Core();

            foreach (var inf in core.Repository.GetAll<Infektion>())
            {
                Console.WriteLine($"{inf.Person} ({inf.GebDatum:d}) aus {inf?.Wohnort?.Name},{inf?.Wohnort?.Land?.Name}");
                inf.Viren.ToList().ForEach(x => Console.WriteLine($"\t {x.Name}"));

                if (inf.Id == 240)
                    inf.Person = "DU BIST KRANK!!!";

              
            }

            var land = core.Repository.GetAll<Land>().Where(x => x.Name.StartsWith("Bayer")).FirstOrDefault();
            if (land != null)
                land.Name = "Baden-Württemberg";


            core.Repository.SaveAll();


            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }
}

using System;
using System.Data.Common;

namespace HalloFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Factory!");


            var kantine = new Kantine();
            var essen = kantine.GetEssen();
            Console.WriteLine($"{essen.Beschreibung} {essen.Kcal}");
            essen.Essen();

            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }

    public class Kantine//EssenFactory
    {
        public IEssen GetEssen()
        {
            var std = DateTime.Now.Hour;
            if (std >= 6 && std <= 11)
                return new Frühstück();
            else if (std >= 11 && std <= 16)
                return new Mittagessen();
            else if (std >= 16 && std <= 20)
                return new Abendessen();

            return null;
        }
    }

}

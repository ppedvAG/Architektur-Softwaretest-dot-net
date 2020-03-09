using System;

namespace HalloFactory
{
    public class Abendessen : IEssen
    {
        public int Kcal => 940;

        public string Beschreibung => "Döner";

        public void Essen()
        {
            Console.WriteLine("Döner macht schöner");
        }
    }
}

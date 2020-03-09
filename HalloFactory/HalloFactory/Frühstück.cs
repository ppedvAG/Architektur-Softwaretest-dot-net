using System;

namespace HalloFactory
{
    public class Frühstück : IEssen
    {
        public int Kcal => 248;

        public string Beschreibung => "Ein Ei und Brot mit Marmelade";

        public void Essen()
        {
            Console.WriteLine("Frühstück wurde verzehrt");
        }
    }
}

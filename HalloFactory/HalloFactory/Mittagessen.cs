using System;

namespace HalloFactory
{
    public class Mittagessen : IEssen
    {
        public int Kcal => 870;

        public string Beschreibung => "Maultaschen";

        public void Essen()
        {
            Console.WriteLine("Das Mittagessen wurde gemampft");
        }
    }
}

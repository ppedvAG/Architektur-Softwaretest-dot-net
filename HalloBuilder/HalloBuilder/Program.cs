using System;

namespace HalloBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Builder!");

            var schrank1 = new Schrank.SchrankBuilder()
                              .SetAnzahlTüren(5)
                              .SetAnzahlBöden(12)
                              .Create();


            var schrank2 = new Schrank.SchrankBuilder()
                              .SetAnzahlTüren(4)
                              .SetAnzahlBöden(4)
                              .Pull().Pull().Update()
                              .SetOberfläche(Oberfläche.Lackiert)
                              .SetFarbe("red")
                              .Create();

            var schrank3 = new Schrank.SchrankBuilder()
                  .SetAnzahlTüren(4)
                  .SetOberfläche(Oberfläche.Gewachst)
                  .SetFarbe("red")
                  .Create();
        }
    }
    public enum Oberfläche
    {
        Natur,
        Lackiert,
        Gewachst
    }
}

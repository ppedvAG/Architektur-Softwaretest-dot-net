using System;

namespace HalloBuilder
{
    public class Schrank
    {
        public int AnzahlTüren { get; private set; }
        public int AnzahlBöden { get; private set; }
        public Oberfläche Oberfläche { get; private set; }
        public string Farbe { get; private set; }
        public bool Kleiderstange { get; private set; }

        private Schrank() { }

        public class SchrankBuilder
        {
            private Schrank schrank = new Schrank();

            public Schrank Create() => schrank;

            public SchrankBuilder SetAnzahlTüren(int türen)
            {
                if (türen >= 2 && türen <= 7)
                {
                    schrank.AnzahlTüren = türen;
                    return this;
                }
                throw new ArgumentException("Es sind nur 2-7 Türen erlaubt");
            }

            public SchrankBuilder SetAnzahlBöden(int böden)
            {
                if (böden >= 0 && böden <= 12)
                {
                    schrank.AnzahlBöden = böden;
                    return this;
                }
                throw new ArgumentException("Es sind nur 0-12 Böden erlaubt");
            }

            public SchrankBuilder SetFarbe(string farbe)
            {
                if (schrank.Oberfläche != Oberfläche.Lackiert)
                    throw new ArgumentException("Nut Lackierte Schränke können eine Farbe haben");

                if (farbe == "pink")
                    throw new ArgumentException("igitt!!!");

                schrank.Farbe = farbe;
                return this;
            }

            public SchrankBuilder Update()
            {
                Pull();
                return this;
            }
            public SchrankBuilder Pull()
            {
                //todo
                return this;
            }

            public SchrankBuilder SetOberfläche(Oberfläche ober)
            {
                schrank.Oberfläche = ober;

                if (ober == Oberfläche.Gewachst || ober == Oberfläche.Natur)
                    schrank.Farbe = "";

                return this;
            }
        }
    }
}

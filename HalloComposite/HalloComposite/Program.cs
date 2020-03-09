using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HalloComposite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Hello Composite Pattern");

            var milchEinkaufen = new Aufgabenliste() { Beschreibung = "Milch einkaufen" };
            milchEinkaufen.Aufgaben.Add(new Einzelaufgabe() { Beschreibung = "Zum laden fahren" });
            milchEinkaufen.Aufgaben.Add(new Einzelaufgabe() { Erledigt = true, Beschreibung = "Milch aus dem Regal nehmen" });
            milchEinkaufen.Aufgaben.Add(new Einzelaufgabe() { Beschreibung = "Nach Hause fahren" });

            var tanken = new Aufgabenliste() { Beschreibung = "Nach Hause fahren und Tanken" };
            tanken.Aufgaben.Add(new Einzelaufgabe() { Beschreibung = "Auto auftanken" });
            tanken.Aufgaben.Add(new Einzelaufgabe() { Beschreibung = "Nach Hause fahren" });
            milchEinkaufen.Aufgaben.Add(tanken);

            ZeigeAufgabe(milchEinkaufen);

            Console.WriteLine("Ende");
            Console.ReadLine();

            void ZeigeAufgabe(Aufgabe aufgabe, string tab = "")
            {
                if (aufgabe is Einzelaufgabe ea)
                    Console.WriteLine($"{tab} {ea.Beschreibung} {(ea.Erledigt ? "OK" : "TODO")}");
                else if (aufgabe is Aufgabenliste al)
                {

                    Console.WriteLine($"{tab} -{al.Beschreibung}- ({(al.Erledigt ? "OK" : "TODO")})");
                    tab += "\t";
                    al.Aufgaben.ForEach(x => ZeigeAufgabe(x, tab));
                }
            }
        }
    }
    public abstract class Aufgabe
    {
        public abstract string Beschreibung { get; set; }
        public abstract bool Erledigt { get; set; }
    }

    public class Einzelaufgabe : Aufgabe
    {
        public override string Beschreibung { get; set; }
        public override bool Erledigt { get; set; }
    }
    public class Aufgabenliste : Aufgabe
    {
        public List<Aufgabe> Aufgaben = new List<Aufgabe>();

        public override string Beschreibung { get; set; }
        public override bool Erledigt
        {
            get => Aufgaben.All(x => x.Erledigt);
            set
            {
                //Aufgaben.ForEach(x => x.Erledigt = value);
                foreach (var item in Aufgaben)
                {
                    item.Erledigt = value;
                }
            }
        }
    }
}

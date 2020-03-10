using System;
using System.Collections;
using System.Collections.Generic;

namespace HalloDecorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var brot = new Käse(new Brot());
            Console.WriteLine($"{brot.Name} {brot.Preis:c}");

            var pizza = new Salami(new Käse(new Käse(new Pizza())));
            Console.WriteLine($"{pizza.Name} {pizza.Preis:c}");

            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }

    public interface ICompo
    {
        public string Name { get; }
        public decimal Preis { get; }
    }

    public class Pizza : ICompo
    {
        public string Name => "Pizza";

        public decimal Preis => 5.8m;
    }

    public class Brot : ICompo
    {
        public string Name => "Brot";

        public decimal Preis => 2.3m;
    }

    public abstract class Deco : ICompo
    {
        protected readonly ICompo parent;

        public Deco(ICompo compo)
        {
            parent = compo;
        }

        public abstract string Name { get; }

        public abstract decimal Preis { get; }

    }

    public class Käse : Deco
    {
        public Käse(ICompo compo) : base(compo) { }

        public override string Name => $"{parent.Name} Käse";

        public override decimal Preis => parent.Preis + 1.2m;
    }

    public class Salami : Deco
    {
        public Salami(ICompo compo) : base(compo) { }

        public override string Name => $"{parent.Name} Salmi";

        public override decimal Preis => parent.Preis + 2.33m;
    }
}

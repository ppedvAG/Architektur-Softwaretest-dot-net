using ppedv.Pandemia.Model;
using ppedv.Pandemia.Model.Contracts;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ppedv.Pandemia.Logic.Tests")]

namespace ppedv.Pandemia.Logic
{
    public class Core
    {

        private static Core core;
        private static object sync = new object();
        public static Core Instance
        {
            get
            {
                lock (sync)
                {
                    if (core == null)
                        core = new Core(new Data.XML.XmlRepository(@"C:\Users\ar2\source\repos\ppedvAG\Architekt_NBG_09032020\ppedv.Pandemia\ppedv.Pandemia.Data.XML.Test\bin\Debug\AutoFix.xml"));
                }
                return core;
            }
        }


        public IRepository Repository { get; private set; }

        internal Core(IRepository repo)
        {
            Repository = repo;
            LandService = new LandServices(this);
        }

        public LandServices LandService { get; }


        //public Core() : this(new Data.EF.EfRepository())
        //{ }
        public Core() : this(new Data.XML.XmlRepository(@"C:\Users\ar2\source\repos\ppedvAG\Architekt_NBG_09032020\ppedv.Pandemia\ppedv.Pandemia.Data.XML.Test\bin\Debug\AutoFix.xml"))
        {
        }

    }
}

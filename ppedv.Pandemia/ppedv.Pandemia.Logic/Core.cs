using ppedv.Pandemia.Model;
using ppedv.Pandemia.Model.Contracts;
using System;
using System.Linq;

namespace ppedv.Pandemia.Logic
{
    public class Core
    {




        public IRepository Repository { get; private set; }

        public Core(IRepository repo)
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

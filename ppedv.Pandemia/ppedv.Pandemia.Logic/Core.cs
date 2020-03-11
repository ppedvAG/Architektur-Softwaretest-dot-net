using ppedv.Pandemia.Model.Contracts;

namespace ppedv.Pandemia.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Core(IRepository repo)
        {
            Repository = repo;
        }

        public Core() : this(new Data.EF.EfRepository())
        { }

    }
}

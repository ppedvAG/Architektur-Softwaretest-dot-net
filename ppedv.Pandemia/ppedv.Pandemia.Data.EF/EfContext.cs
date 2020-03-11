using ppedv.Pandemia.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Pandemia.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Infektion> Infektionen { get; set; }
        public DbSet<Land> Laender { get; set; }
        public DbSet<Region> Regionen { get; set; }
        public DbSet<Virus> Viren { get; set; }

        public EfContext() : base("Server=(localdb)\\bla;Database=Pandemia;Trusted_Connection=true")
        { }
    }
}

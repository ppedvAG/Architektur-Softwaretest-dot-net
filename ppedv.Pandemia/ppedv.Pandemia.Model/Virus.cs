using System.Collections.Generic;

namespace ppedv.Pandemia.Model
{
    public class Virus : Entity
    {
        public string Name { get; set; }
        public virtual HashSet<Infektion> Infektionen { get; set; } = new HashSet<Infektion>();
    }

}

using System.Collections.Generic;

namespace ppedv.Pandemia.Model
{
    public class Region : Entity
    {
        public string Name { get; set; }
        public virtual Land Land { get; set; }
        public virtual HashSet<Infektion> Infektionen { get; set; } = new HashSet<Infektion>();
    }

}

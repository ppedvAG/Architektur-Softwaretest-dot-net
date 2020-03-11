using System.Collections.Generic;

namespace ppedv.Pandemia.Model
{
    public class Land : Entity
    {
        public string Name { get; set; }
        public virtual HashSet<Region> Region { get; set; } = new HashSet<Region>();
    }

}

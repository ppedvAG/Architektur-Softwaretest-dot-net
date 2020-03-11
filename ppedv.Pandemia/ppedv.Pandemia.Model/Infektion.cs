using System;
using System.Collections.Generic;

namespace ppedv.Pandemia.Model
{
    public class Infektion : Entity
    {
        public string Person { get; set; }
        public DateTime GebDatum { get; set; }
        public virtual Region Wohnort { get; set; }
        public virtual HashSet<Virus> Viren { get; set; } = new HashSet<Virus>();
    }

}

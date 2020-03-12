using ppedv.Pandemia.Model;
using ppedv.Pandemia.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.Pandemia.Logic
{
    public class LandServices
    {
        private Core core;
        public LandServices(Core core)
        {
            this.core = core;
        }

        public bool IsLandInfected(Land land)
        {
            if (land == null)
                throw new ArgumentNullException();

            return land.Region.Any(x => x.Infektionen.Any());
        }

        public Land GetLandMitMeistenInfectionen()
        {
            return core.Repository.GetAll<Land>()
                             .OrderByDescending(x => x.Region.Sum(y => y.Infektionen.Count))
                             .FirstOrDefault();
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.Pandemia.Model;
using ppedv.Pandemia.Model.Contracts;
using System;

namespace ppedv.Pandemia.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_IsLandInfected_land_is_null_throws_ArgumentNullException()
        {
            var core = new Core();

            Assert.ThrowsException<ArgumentNullException>(() => core.IsLandInfected(null));
        }

        [TestMethod]
        public void Core_IsLandInfected_no_infections_results_false()
        {
            var core = new Core();
            var land = new Land();
            land.Region.Add(new Region());

            Assert.IsFalse(core.IsLandInfected(land));
        }

        [TestMethod]
        public void Core_IsLandInfected_no_regions_results_false()
        {
            var core = new Core();
            var land = new Land();

            Assert.IsFalse(core.IsLandInfected(land));
        }

        [TestMethod]
        public void Core_IsLandInfected_reults_true()
        {
            var core = new Core();
            var land = new Land();
            var r = new Region();
            r.Land = land;
            land.Region.Add(r);

            r.Infektionen.Add(new Infektion() { Wohnort = r });
            Assert.IsTrue(core.IsLandInfected(land));

            //mit 2 infektionen sollte auch ok sein
            r.Infektionen.Add(new Infektion() { Wohnort = r });
            Assert.IsTrue(core.IsLandInfected(land));
        }

        [TestMethod]
        public void Core_GetLandMitMeistenInfectionen()
        {
            var core = new Core(new TestRepo());

            var result = core.GetLandMitMeistenInfectionen();

            Assert.AreEqual("l2", result.Name);
        }


        [TestMethod]
        public void Core_GetLandMitMeistenInfectionen_Moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Land>()).Returns(() =>
            {
                var l1 = new Land() { Name = "l1" };
                var l1r = new Region() { Land = l1 };
                l1.Region.Add(l1r);

                var l2 = new Land() { Name = "l2" };
                var l2r = new Region() { Land = l2 };
                l2.Region.Add(l2r);

                l1r.Infektionen.Add(new Infektion());
                l1r.Infektionen.Add(new Infektion());


                l2r.Infektionen.Add(new Infektion());
                l2r.Infektionen.Add(new Infektion());
                l2r.Infektionen.Add(new Infektion());

                return new[] { l1, l2 };
            });
            var core = new Core(mock.Object);

            var result = core.GetLandMitMeistenInfectionen();

            Assert.AreEqual("l2", result.Name);
        }


    }
}

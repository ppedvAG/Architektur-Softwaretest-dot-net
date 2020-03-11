using System;
using System.IO;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Pandemia.Model;

namespace ppedv.Pandemia.Data.XML.Test
{
    [TestClass]
    public class XmlRepositoryTest
    {
        [TestMethod]
        public void XmlRepo_can_add_Infektion()
        {
            var repo = new XmlRepository();
            var inf = new Infektion() { Person = "Bernd" };
            repo.Add(inf);
            repo.SaveAll();
        }

        [TestMethod]
        public void XmlRepo_can_add_Infektion_with_2_Virus()
        {
            var repo = new XmlRepository();
            var inf = new Infektion() { Person = "Bernd" };
            inf.Viren.Add(new Virus() { Name = "v1" });
            inf.Viren.Add(new Virus() { Name = "v2" });

            repo.Add(inf);
            repo.SaveAll();
        }

        [TestMethod]
        public void XmlRepo_can_add_Infektion_with_2_Virus_MitLand()
        {
            var repo = new XmlRepository();
            var inf = new Infektion() { Person = "Bernd" };
            inf.Viren.Add(new Virus() { Name = "v1" });
            inf.Viren.Add(new Virus() { Name = "v2" });
            var l = new Land() { Name = "Seuchenland" };
            inf.Wohnort = new Region() { Name = "Pesttal", Land = l };

            repo.Add(inf);
            repo.SaveAll();
        }

        [TestMethod]
        public void XmlRepo_can_add_2_Infektion_gleiches_Land()
        {
            var repo = new XmlRepository();

            var l = new Land() { Name = "Seuchenland" };

            var inf1 = new Infektion() { Person = "Bernd" };
            inf1.Wohnort = new Region() { Name = "Pesttal", Land = l };
            var inf2 = new Infektion() { Person = "Bernd" };
            inf2.Wohnort = new Region() { Name = "Rotzberg", Land = l };

            repo.Add(inf1);
            repo.Add(inf2);
            repo.SaveAll();
        }

        [TestMethod]
        public void XmlRepo_can_add_2_Infektion_und_unabhägige_Laender()
        {
            var repo = new XmlRepository();

            var inf1 = new Infektion() { Person = "Bernd" };
            var inf2 = new Infektion() { Person = "Brot" };

            var land = new Land() { Name = "Pestland" };
            var land2 = new Land() { Name = "Seuchenland" };
            land2.Region.Add(new Region() { Name = "Todeszones" });

            repo.Add(inf1);
            repo.Add(inf2);
            repo.Add(land);
            repo.Add(land2);
            repo.SaveAll();
        }

        [TestMethod]
        public void XmlRepo_can_add_Infektion_and_Laender_asign_later()
        {
            var testFile = "myFile.xml";
            if (File.Exists(testFile))
                File.Delete(testFile);

            var inf1 = new Infektion() { Person = "Bernd" };
            var land = new Land() { Name = "Seuchenland" };
            land.Region.Add(new Region() { Name = "Todeszones" });

            {
                var repo = new XmlRepository(testFile);
                repo.Add(inf1);
                repo.Add(land);
                repo.SaveAll();
            }

            {
                var repo = new XmlRepository(testFile);
                var iLoaded = repo.GetAll<Infektion>().FirstOrDefault();
                var lLoaded = repo.GetAll<Land>().FirstOrDefault();
                iLoaded.Wohnort = lLoaded.Region.FirstOrDefault();

                //repo.Update(iLoaded);
                repo.SaveAll();
            }
        }

        [TestMethod]
        public void XmlRepo_can_CR_Infektion_AutoFix_FluentAss()
        {
            var fn = "AutoFix.xml";
            var fix = new Fixture();

            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            for (int i = 0; i < 100; i++)
            {

                var inf = fix.Create<Infektion>();

                using (var repo = new XmlRepository(fn))
                {
                    repo.Add(inf);
                    repo.SaveAll();
                }

                using (var con = new XmlRepository(fn))
                {
                    var loaded = con.GetById<Infektion>(inf.Id);
                    loaded.Should().BeEquivalentTo(inf, c =>
                    {
                        c.Using<DateTime>(ctx => ctx.Subject.Should().BeCloseTo(ctx.Expectation))
                         .WhenTypeIs<DateTime>();
                        c.IgnoringCyclicReferences();
                        return c;
                    });
                }
            }

        }
    }
}

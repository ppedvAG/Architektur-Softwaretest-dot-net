using System;
using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Pandemia.Model;

namespace ppedv.Pandemia.Data.EF.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContext_can_create_DB()
        {
            var con = new EfContext();

            if (con.Database.Exists())
                con.Database.Delete();

            Assert.IsFalse(con.Database.Exists());
            con.Database.Create();

            Assert.IsTrue(con.Database.Exists());
            con.Database.Exists().Should().BeTrue();
        }

        [TestMethod]
        public void EfContext_can_CRUD_Infektion()
        {
            var inf = new Infektion() { Person = $"Fred_{Guid.NewGuid()}", GebDatum = DateTime.Now.AddDays(-30000) };
            var newName = $"Wilma_{Guid.NewGuid()}";

            //CREATE
            using (var con = new EfContext())
            {
                con.Infektionen.Add(inf);
                Assert.AreEqual(1, con.SaveChanges());
            }

            //READ
            using (var con = new EfContext())
            {
                var loaded = con.Infektionen.Find(inf.Id);
                Assert.IsNotNull(loaded);
                Assert.AreEqual(inf.Person, loaded.Person);


                //Assert.AreEqual(inf.Modified, loaded.Modified);
                loaded.Modified.Should().BeCloseTo(inf.Modified);

                //UPDATE
                loaded.Person = newName;
                Assert.AreEqual(1, con.SaveChanges());
            }

            //verify UPDATE + DELETE
            using (var con = new EfContext())
            {
                var loaded = con.Infektionen.Find(inf.Id);
                Assert.AreEqual(newName, loaded.Person);

                con.Infektionen.Remove(loaded);
                Assert.AreEqual(1, con.SaveChanges());
            }

            //verfiy DELETE
            using (var con = new EfContext())
            {
                var loaded = con.Infektionen.Find(inf.Id);
                Assert.IsNull(loaded);
            }

        }

        [TestMethod]
        public void EfContext_can_CR_Infektion_AutoFix_FluentAss()
        {
            var fix = new Fixture();

            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            var inf = fix.Create<Infektion>();

            using (var con = new EfContext())
            {
                con.Infektionen.Add(inf);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Infektionen.Find(inf.Id);
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

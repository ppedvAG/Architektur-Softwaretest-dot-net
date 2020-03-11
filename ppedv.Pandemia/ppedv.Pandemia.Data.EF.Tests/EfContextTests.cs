﻿using System;
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

    }
}

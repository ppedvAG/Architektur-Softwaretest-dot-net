using ppedv.Pandemia.Model;
using ppedv.Pandemia.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Pandemia.Logic.Tests
{
    public class TestRepo : IRepository
    {
        public void Add<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
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

            if (typeof(T) == typeof(Land))
                return new[] { l1, l2 }.Cast<T>();

            throw new NotImplementedException();
        }

        public T GetById<T>(Guid id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}

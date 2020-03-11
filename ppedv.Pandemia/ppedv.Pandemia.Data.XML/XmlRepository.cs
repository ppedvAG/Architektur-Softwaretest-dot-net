using ppedv.Pandemia.Model;
using ppedv.Pandemia.Model.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ppedv.Pandemia.Data.XML
{
    public class XmlRepository : IRepository
    {
        string infFile = "inf.xml";
        List<Infektion> infektions = new List<Infektion>();

        public XmlRepository()
        {
            LoadInf();
        }

        private void LoadInf()
        {
            if (!File.Exists(infFile))
                return;

            using (var sr = new StreamReader(infFile))
            {
                var serial = new XmlSerializer(typeof(List<Infektion>));
                infektions = (List<Infektion>)serial.Deserialize(sr);
            }
        }

        private void SaveInf()
        {
            using (var sw = new StreamWriter(infFile))
            {
                var serial = new XmlSerializer(typeof(List<Infektion>));
                serial.Serialize(sw, infektions);
            }
        }

        public void Add<T>(T entity) where T : Entity
        {
            if (entity is Infektion i)
                infektions.Add(i);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            if (entity is Infektion i)
                infektions.Remove(i);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            if (typeof(T) == typeof(Infektion))
                return infektions.Cast<T>();

            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            SaveInf();
        }



        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}

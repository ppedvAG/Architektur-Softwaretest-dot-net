using ppedv.Pandemia.Model;
using ppedv.Pandemia.Model.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace ppedv.Pandemia.Data.XML
{

    public class XmlDataContainer
    {

        public HashSet<Land> Laender { get; set; } = new HashSet<Land>();
        public HashSet<Region> Regionen { get; set; } = new HashSet<Region>();
        public HashSet<Infektion> Infektionen { get; set; } = new HashSet<Infektion>();
        public HashSet<Virus> Viren { get; set; } = new HashSet<Virus>();

        public HashSet<T> GetSet<T>()
        {
            var props = this.GetType().GetTypeInfo().GetProperties();
            var gen = props.Where(x => x.PropertyType.IsGenericType && x.PropertyType.GetGenericTypeDefinition() == typeof(HashSet<>));
            var first = gen.FirstOrDefault(x => x.PropertyType.GetGenericArguments()[0] == typeof(T));
            var ll=  first.GetValue(this) as HashSet<T>;
            return ll;
        }

    }

    public class XmlRepository : IRepository, IDisposable
    {
        XmlDataContainer container = new XmlDataContainer();
        string filename;
        public XmlRepository(string filename = "pandemia.xml")
        {
            this.filename = filename;
            LoadAll();
        }

        private void LoadAll()
        {
            if (!File.Exists(filename))
                return;

            using (var sr = XmlReader.Create(filename))
            {
                var sett = new DataContractSerializerSettings();
                sett.PreserveObjectReferences = true;

                var serial = new DataContractSerializer(container.GetType(), sett);
                container = (XmlDataContainer)serial.ReadObject(sr);
            }
        }


        public void Add<T>(T entity) where T : Entity
        {
            container.GetSet<T>().Add(entity);

            //if (entity is Infektion i)
                //container.Infektionen.Add(i);
            //if (entity is Land l)
                //container.Laender.Add(l);
            //if (entity is Region r)
                //container.Regionen.Add(r);
            //if (entity is Virus v)
                //container.Viren.Add(v);
            

            //entity.Id = GetAll<T>().Max(x => x.Id) + 1;
        }

        public void Delete<T>(T entity) where T : Entity
        {
            container.GetSet<T>().Remove(entity);

            //if (entity is Infektion i)
                //container.Infektionen.Remove(i);
            //if (entity is Virus v)
                //container.Viren.Remove(v);
            //if (entity is Region r)
                //container.Regionen.Remove(r);
            //if (entity is Land llll)
                //container.Laender.Remove(llll);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return container.GetSet<T>().ToList();


            //if (typeof(T) == typeof(Infektion))
            //    return container.Infektionen.Cast<T>();

            //if (typeof(T) == typeof(Land))
            //    return container.Laender.Cast<T>();

            //if (typeof(T) == typeof(Region))
            //    return container.Regionen.Cast<T>();

            //if (typeof(T) == typeof(Virus))
            //    return container.Viren.Cast<T>();

            //throw new NotImplementedException();
        }

        public T GetById<T>(Guid id) where T : Entity
        {
            return GetAll<T>().FirstOrDefault(x => x.Id == id);
        }

        public void SaveAll()
        {
            using (var sw = XmlWriter.Create(filename, new XmlWriterSettings() { Indent = true }))
            {
                var sett = new DataContractSerializerSettings();
                sett.PreserveObjectReferences = true;

                var serial = new DataContractSerializer(container.GetType(), sett);
                serial.WriteObject(sw, container);
            }
        }


        //nur online...
        public void Update<T>(T entity) where T : Entity
        {
            var loaded = GetById<T>(entity.Id);
            if (loaded != null)
                Delete<T>(loaded);

            Add(entity);
            entity.Id = loaded.Id;

        }

        public void Dispose()
        {

        }
    }
}

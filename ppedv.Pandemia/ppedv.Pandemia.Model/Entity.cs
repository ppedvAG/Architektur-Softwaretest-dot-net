using System;
using System.ComponentModel;

namespace ppedv.Pandemia.Model
{
    public abstract class Entity : INotifyPropertyChanged
    {
        public Guid Id { get; set; } = new Guid();
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;

        public event PropertyChangedEventHandler PropertyChanged;
    }

}

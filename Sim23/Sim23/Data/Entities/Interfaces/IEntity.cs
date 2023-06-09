﻿namespace Sim23.Data.Entities.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime DateCreated { get; set; }
    }
    public abstract class BaseEntity<T> : IEntity<T>
    {
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

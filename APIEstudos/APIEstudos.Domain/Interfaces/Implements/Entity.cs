using APIEstudos.Domain.Interfaces.Entities;

namespace APIEstudos.Domain.Interfaces.Implements
{
    public abstract class Entity : IEntity
    {
    }

    public abstract class Entity<TKey> : IEntity
    {
        public virtual TKey? Id { get; set; }
    }
}

using APIEstudos.Domain.Interfaces.Entities;

namespace APIEstudos.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task Add(TEntity entity);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
        Task <TEntity> FindById <TKey>(TKey id);
    }
}
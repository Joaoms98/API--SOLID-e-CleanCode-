namespace APIEstudos.Domain.Interfaces
{
    public interface IRepository <T>
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);

        
        Task <T> FindById (Guid id);
    }
}
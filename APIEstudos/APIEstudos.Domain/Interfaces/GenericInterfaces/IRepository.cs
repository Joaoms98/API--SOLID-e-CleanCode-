namespace APIEstudos.Domain.Interfaces
{
    public interface IRepository <T>
    {
        Task Add(T entity);
        Task Delete(Guid id);
        Task Update(T entity);

        
        Task <T> FindById (Guid id);
        Task <IEnumerable<T>> GetAll();
    }
}
namespace APIEstudos.Domain.Interfaces
{
    public interface IRepository <T>
    {
        /// <summary>
        /// Method for adding a new entity
        /// </summary>
        /// <param name="entity"></param>
        Task Add(T entity);

        /// <summary>
        /// Method for deleted a entity
        /// </summary>
        /// <param name="id"></param>
        Task Delete(Guid id);

        /// <summary>
        /// Method for Update a entity
        /// </summary>
        /// <param name="entity"></param>
        Task Update(T entity);
        
        /// <summary>
        /// Method for find a entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>entity</returns>
        Task <T> FindById (Guid id);

        /// <summary>
        /// Method for get all entities
        /// </summary>
        /// <returns>A IEnumerable list of all entities</returns>
        Task <IEnumerable<T>> GetAll();

        /// <summary>
        /// Method for find a entity by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>entity</returns>
        Task <T> FindByEmail (string email);

        /// <summary>
        /// Method for find a entity by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>entity</returns>
        Task <T> FindByName (string name);
    }
}
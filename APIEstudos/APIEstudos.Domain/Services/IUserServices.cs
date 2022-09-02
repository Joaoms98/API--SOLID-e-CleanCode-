using APIEstudos.Core.Models;
using APIEstudos.Domain.Responses;

namespace APIEstudos.Domain.Interfaces
{
    public interface IUserServices
    {
        Task<UserResponse> Add(UserModel user);
        Task<UserResponse> Update(UserModel user);
        Task Delete(Guid id);

        Task<UserResponse> FindById(Guid id);
        Task<IEnumerable<UserModel>> GetAll();
        Task<UserResponse> FindByEmail(string email);
        Task CreateUserNotDuplicate (string email);
    }
}

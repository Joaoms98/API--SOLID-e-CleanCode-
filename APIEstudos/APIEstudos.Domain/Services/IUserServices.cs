using APIEstudos.Domain.Responses;
using APIEstudos.Infrastructure.Models;

namespace APIEstudos.Domain.Interfaces
{
    public interface IUserServices
    {
        Task<UserResponse> Add(UserModel user);
        Task<UserResponse> FindById(Guid Id);
    }
}

using APIEstudos.Core.Models;
using APIEstudos.Domain.Responses;

namespace APIEstudos.Domain.Interfaces
{
    public interface IUserServices
    {
        Task<UserResponse> Add(UserModel user);
        Task<UserResponse> FindById(Guid Id);
    }
}

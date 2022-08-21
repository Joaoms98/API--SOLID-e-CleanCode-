using APIEstudos.Domain.Responses;
using APIEstudos.Infrastructure.Models;

namespace APIEstudos.Domain.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUserAsync(UserModel user);
    }
}
    
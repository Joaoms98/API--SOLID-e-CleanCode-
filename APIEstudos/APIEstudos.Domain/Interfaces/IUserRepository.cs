using APIEstudos.Infrastructure.Models;

namespace APIEstudos.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUserAsync(UserModel user);
    }
}

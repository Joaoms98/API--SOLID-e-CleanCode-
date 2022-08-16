using APIEstudos.models;

namespace APIEstudos.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUserAsync(UserModel user);
    }
}

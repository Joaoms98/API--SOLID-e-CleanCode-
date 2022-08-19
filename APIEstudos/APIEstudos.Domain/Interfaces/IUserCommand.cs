using APIEstudos.Domain.Commands;
using APIEstudos.Domain.Responses;

namespace APIEstudos.Domain.Interfaces
{
    public interface IUserCommand
    {
        Task<CreateUserResponse> CreateUserAsync(CreateUserRequest User);
    }
}

using APIEstudos.Domain.Commands;
using APIEstudos.Domain.Responses;

namespace APIEstudos.Domain.Interfaces
{
    public interface IUserCommand
    {
        Task<UserResponse> CreateUserAsync(CreateUserRequest User);
        Task<UserResponse> UpdateUserAsync(UpdateUserRequest User);
        
        Task DeleteUserAsync(DeleteUserRequest User);
    }
}

using APIEstudos.Domain.Responses;
using MediatR;

namespace APIEstudos.Domain.Commands
{
    public class CreateUserRequest : IRequest<UserResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

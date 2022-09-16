using MediatR;
using APIEstudos.Domain.Responses;

namespace APIEstudos.Domain.Commands
{
    public class UpdateUserRequest : IRequest<UserResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
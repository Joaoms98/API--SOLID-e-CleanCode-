using MediatR;
using APIEstudos.Domain.Responses;

namespace APIEstudos.Domain.Commands
{
    public class DeleteUserRequest : IRequest<UserResponse>
    {
        public Guid Id { get; set; }
    }
}
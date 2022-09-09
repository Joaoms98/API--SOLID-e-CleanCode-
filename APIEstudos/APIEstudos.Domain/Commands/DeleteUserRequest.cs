using MediatR;

namespace APIEstudos.Domain.Commands
{
    public class DeleteUserRequest : IRequest<object>
    {
        public Guid Id { get; set; }
    }
}
using APIEstudos.Domain.Responses;
using MediatR;

namespace APIEstudos.Domain.Commands
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime Date { get; set; }
    }
}

using APIEstudos.Response;
using MediatR;

namespace APIEstudos.Requests
{
    public class CreateUserRequest : IRequest<UserResponse>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime Date { get; set; }
    }
}

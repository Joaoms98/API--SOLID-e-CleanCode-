using MediatR;
using APIEstudos.Domain.Responses;

namespace APIEstudos.Domain.Queries
{
    public class GetUserByNameQuery : IRequest<UserResponse>
    {
        public string Name { get; set; }

        public GetUserByNameQuery(string name)
        {
            Name = name;
        }
    }
}
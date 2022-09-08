using MediatR;
using APIEstudos.Domain.Responses;

namespace APIEstudos.Domain.Queries
{
    public class GetUserByIdQuery : IRequest<UserResponse>
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
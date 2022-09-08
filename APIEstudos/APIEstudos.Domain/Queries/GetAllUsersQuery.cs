using MediatR;
using APIEstudos.Domain.Responses;

namespace APIEstudos.Domain.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserResponse>>
    {
        
    }
}
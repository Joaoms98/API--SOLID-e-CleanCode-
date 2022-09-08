using AutoMapper;
using MediatR;
using APIEstudos.Core.Models;
using APIEstudos.Domain.Interfaces;
using APIEstudos.Domain.Queries;
using APIEstudos.Domain.Responses;

namespace APIEstudos.Domain.Handlers.Query
{
    public class GetUserByNameHandler : IRequestHandler<GetUserByNameQuery , UserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByNameHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponse> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            UserModel user = await _userRepository.FindByName(request.Name);

            if (user is null)
            {
                throw new DllNotFoundException($"User {request.Name} not found");
            }

            return await Task.FromResult(
                _mapper.Map<UserResponse>(user)
            );
        }
    }
}
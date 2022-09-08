using AutoMapper;
using MediatR;
using APIEstudos.Core.Models;
using APIEstudos.Domain.Interfaces;
using APIEstudos.Domain.Queries;
using APIEstudos.Domain.Responses;

namespace APIEstudos.Domain.Handlers.Query
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, UserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByEmailHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponse> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            UserModel user = await _userRepository.FindByEmail(request.Email);
            
            if (user is null)
            {
                throw new DllNotFoundException($"Could not find user with id {request.Email}");
            }

            return await Task.FromResult(
                _mapper.Map<UserResponse>(user)
            );
        }
    }
}
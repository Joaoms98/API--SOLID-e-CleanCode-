using AutoMapper;
using MediatR;
using APIEstudos.Core.Models;
using APIEstudos.Domain.Interfaces;
using APIEstudos.Domain.Queries;
using APIEstudos.Domain.Responses;

namespace APIEstudos.Domain.Handlers.Query
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<UserModel> users = await _userRepository.GetAll();

            if (users is null)
            {
                throw new DllNotFoundException($"Could not find users");
            }

            return await Task.FromResult(
            _mapper.Map<IEnumerable<UserResponse>>(users)
            );
        }
    }
}
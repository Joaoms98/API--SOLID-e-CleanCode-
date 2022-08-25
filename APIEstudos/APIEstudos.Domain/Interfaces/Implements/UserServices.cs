using APIEstudos.Domain.Responses;
using APIEstudos.Infrastructure.Models;
using AutoMapper;

namespace APIEstudos.Domain.Interfaces.Implements
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserServices(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> CreateUserAsync(UserModel user)
        {
            var response = _mapper.Map<CreateUserResponse>(user);
            await _userRepository.Add(user);
            return response;
        }
    }
}

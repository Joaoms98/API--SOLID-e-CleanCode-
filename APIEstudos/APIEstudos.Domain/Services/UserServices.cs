using APIEstudos.Core.Models;
using APIEstudos.Domain.Responses;
using AutoMapper;

namespace APIEstudos.Domain.Interfaces.Implements
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserServices(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponse> Add(UserModel user)
        {
            var response = _mapper.Map<UserResponse>(user);
            await _userRepository.Add(user);
            return response;
        }

        public async Task<UserResponse> Update(UserModel user)
        {
            var response = _mapper.Map<UserResponse>(user);
            await _userRepository.Update(user);
            return response;
        }

        public async Task Delete(Guid id)
        {
            await _userRepository.Delete(id);
        }

        public async Task<UserResponse> FindById(Guid id)
        {
            var response = _mapper.Map<UserResponse>(await _userRepository.FindById(id));
            return response;
        }
    }
}

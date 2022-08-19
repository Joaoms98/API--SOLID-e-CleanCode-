
using APIEstudos.Domain.Responses;
using APIEstudos.Infrastructure.Models;

namespace APIEstudos.Domain.Interfaces.Implements
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> CreateUserAsync(UserModel user)
        {
            var response = new CreateUserResponse();
            await _userRepository.CreateUserAsync(user);
            return response;
        }
    }
}

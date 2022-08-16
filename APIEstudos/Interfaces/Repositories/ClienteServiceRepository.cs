using APIEstudos.models;
using APIEstudos.Response;

namespace APIEstudos.Interfaces.Repositories
{
    public class ClienteServiceRepository : IUserService
    {
        private readonly IUserRepository _userRepository;

        public ClienteServiceRepository(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> CreateUserAsync(UserModel user)
        {
            var response = new UserResponse();
            await _userRepository.CreateUserAsync(user);
            return response;
        }
    }
}

using AutoMapper;
using APIEstudos.Domain.Interfaces;
using APIEstudos.Domain.Commands;
using APIEstudos.Domain.Responses;
using APIEstudos.Infrastructure.Models;

namespace APIEstudos.Domain.Handlers.Command
{
    public class CreateUserHandler : IUserCommand
    {
        protected readonly IUserService _userService;
        protected readonly IMapper _mapper;

        public CreateUserHandler(
            IMapper mapper,
            IUserService user
        )
        {
            _mapper = mapper;
            _userService = user;
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
        {
            var userModel = _mapper.Map<UserModel>(request);
            return await _userService.CreateUserAsync(userModel);
        }
    }
}

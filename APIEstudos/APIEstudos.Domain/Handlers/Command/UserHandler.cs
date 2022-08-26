using AutoMapper;
using APIEstudos.Domain.Interfaces;
using APIEstudos.Domain.Commands;
using APIEstudos.Domain.Responses;
using APIEstudos.Core.Models;

namespace APIEstudos.Domain.Handlers.Command
{
    public class UserHandler : IUserCommand
    {
        protected readonly IUserServices _userServices;
        protected readonly IMapper _mapper;

        public UserHandler(
            IMapper mapper,
            IUserServices user
        )
        {
            _mapper = mapper;
            _userServices = user;
        }

        public async Task<UserResponse> CreateUserAsync(CreateUserRequest request)
        {
            var response = _mapper.Map<UserModel>(request);
            return await _userServices.Add(response);
        }
    }
}

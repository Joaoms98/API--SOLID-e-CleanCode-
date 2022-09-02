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
            await _userServices.CreateUserNotDuplicate(request.Email);
            var response = _mapper.Map<UserModel>(request);
            return await _userServices.Add(response);
        }

        public async Task<UserResponse> UpdateUserAsync(UpdateUserRequest request)
        {
            var response = _mapper.Map<UserModel>(request);
            return await _userServices.Update(response);
        }

        public async Task DeleteUserAsync(DeleteUserRequest request)
        {
             var response = _mapper.Map<UserModel>(request);
             await _userServices.Delete(response.Id);
        }
    }
}

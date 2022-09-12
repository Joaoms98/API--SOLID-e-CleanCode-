using MediatR;
using APIEstudos.Domain.Commands;
using APIEstudos.Domain.Responses;
using APIEstudos.Domain.Interfaces;
using AutoMapper;
using APIEstudos.Core.Models;
using APIEstudos.Domain.Services;

namespace APIEstudos.Domain.Handlers.Command
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidate _userValidate;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUserRepository userRepository, IUserValidate userValidate, IMapper mapper)
        {
            _userRepository = userRepository;
            _userValidate = userValidate;
            _mapper = mapper;
        }
        public async Task<UserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            UserModel user = await _userRepository.FindById(request.Id);

            if(user is null)
            {
                throw new DllNotFoundException($"Could not find user id: {request.Id}");
            }
            
            if(_userValidate.UserIsValid(request.Name, request.Email))
            {
                user.Name = request.Name;
                user.Email = request.Email;

                await _userRepository.Update(user);
                return _mapper.Map<UserResponse>(user);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}

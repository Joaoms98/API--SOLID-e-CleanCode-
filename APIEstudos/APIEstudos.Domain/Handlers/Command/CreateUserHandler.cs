using MediatR;
using AutoMapper;
using APIEstudos.Domain.Commands;
using APIEstudos.Domain.Responses;
using APIEstudos.Domain.Interfaces;
using APIEstudos.Core.Models;
using APIEstudos.Domain.Services;
using APIEstudos.Core.Exceptions;

namespace APIEstudos.Domain.Handlers.Command
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, UserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidate _userValidate;
        private readonly IMapper _mapper;

        public CreateUserHandler(
        IUserRepository userRepository, 
        IUserValidate userValidate, 
        IMapper mapper
        )
        {
            _userRepository = userRepository;
            _userValidate = userValidate;
            _mapper = mapper;
        }

        public async Task<UserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var emailAlreadyExists = await _userRepository.FindByEmail(request.Email);
            
            if (emailAlreadyExists != null)
            {
                throw new UserExistsException($"{request.Email} is already in use");
            }

            if(_userValidate.UserIsValid(request.Name, request.Email))
            {
                UserModel user = new UserModel {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Date = DateTime.Now
                };

                await _userRepository.Add(user);
                return _mapper.Map<UserResponse>(user);
            }
            else
            {
                throw new ValidationException();
            }
        }
    }
}
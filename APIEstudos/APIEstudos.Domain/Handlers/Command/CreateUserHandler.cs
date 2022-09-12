using MediatR;
using AutoMapper;
using APIEstudos.Domain.Commands;
using APIEstudos.Domain.Responses;
using APIEstudos.Domain.Interfaces;
using APIEstudos.Core.Models;

namespace APIEstudos.Domain.Handlers.Command
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, UserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }   
        public async Task<UserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var emailAlreadyExists = await _userRepository.FindByEmail(request.Email);
            
            if (emailAlreadyExists != null)
            {
                throw new InvalidOperationException($"{request.Email} is already in use");
            }
            
            if(string.IsNullOrEmpty(request.Email))
            {
                throw new InvalidOperationException($"Email is Required");
            }

            if(string.IsNullOrEmpty(request.Name))
            {
               throw new InvalidOperationException($"Name is Required"); 
            }

            UserModel user = new UserModel {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Date = DateTime.Now
            };

            await _userRepository.Add(user);
            return _mapper.Map<UserResponse>(user);
        }
    }
}
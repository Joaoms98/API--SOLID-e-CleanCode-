using MediatR;
using APIEstudos.Domain.Commands;
using APIEstudos.Domain.Responses;
using APIEstudos.Domain.Interfaces;
using AutoMapper;
using APIEstudos.Core.Models;

namespace APIEstudos.Domain.Handlers.Command
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            UserModel user = await _userRepository.FindById(request.Id);

            if(user is null)
            {
                throw new DllNotFoundException($"Could not find user by id: {request.Id}");
            }

            if(string.IsNullOrEmpty(request.Email))
            {
                throw new InvalidOperationException($"Email is Required");
            }

            if(string.IsNullOrEmpty(request.Name))
            {
               throw new InvalidOperationException($"Name is Required"); 
            }
            
            user.Name = request.Name;
            user.Email = request.Email;

            await _userRepository.Update(user);
            return _mapper.Map<UserResponse>(user);
        }
    }
}

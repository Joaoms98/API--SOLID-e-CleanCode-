using MediatR;
using APIEstudos.Domain.Commands;
using APIEstudos.Domain.Responses;
using APIEstudos.Domain.Interfaces;
using AutoMapper;

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
            var user = await _userRepository.FindById(request.Id);

            if(user is null)
            {
                throw new DllNotFoundException($"Could not find user by id: {request.Id}");
            }

            await _userRepository.Update(user);
            return _mapper.Map<UserResponse>(user);
        }
    }
}
using MediatR;
using AutoMapper;
using APIEstudos.Domain.Commands;
using APIEstudos.Domain.Interfaces;

namespace APIEstudos.Domain.Handlers.Command
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, object>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<object> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindById(request.Id);

            if(user is null)
            {
                throw new DllNotFoundException($"Could not find user by id: {request.Id}");
            }

            await _userRepository.Delete(user.Id);
            return (new object[]
            {
                $"Delete user {request.Id}",
            });
        }
    }
}
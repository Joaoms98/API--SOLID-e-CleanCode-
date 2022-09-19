using AutoMapper;
using MediatR;
using APIEstudos.Domain.Interfaces;
using APIEstudos.Domain.Queries;
using APIEstudos.Domain.Responses;
using APIEstudos.Core.Models;
using APIEstudos.Core.Exceptions;

namespace APIEstudos.Domain.Handlers.Query
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            UserModel user = await _userRepository.FindById(request.Id);
            
            if (user is null)
            {
                throw new UserExistsException($"Could not find user with id {request.Id}");
            }

            return await Task.FromResult(
                _mapper.Map<UserResponse>(user)
            );
        }
    }
}
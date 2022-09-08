using APIEstudos.Core.Models;
using APIEstudos.Domain.Responses;
using AutoMapper;

namespace APIEstudos.Domain.Interfaces.Implements
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserServices(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponse> Add(UserModel user)
        {
            var exists = await _userRepository.FindByEmail(user.Email);
            
            if (exists !=   null)
            {
                throw new Exception("Email already exists.");
            }
            
            var response = _mapper.Map<UserResponse>(user);
            await _userRepository.Add(user);
            return response;
        }
 
        public async Task<UserResponse> Update(UserModel user)
        {
            var exists = await _userRepository.FindById(user.Id);
            
            if (exists == null)
            {
                throw new Exception("Couldn't find the user with the specified id");
            }

            var response = _mapper.Map<UserResponse>(user);
            await _userRepository.Update(user);
            return response;
        }

        public async Task Delete(Guid id)
        {
            var exists = await _userRepository.FindById(id);
            
            if (exists == null)
            {
                throw new Exception("Couldn't find the user with the specified id");
            }

            await _userRepository.Delete(id);
        }

        public async Task<UserResponse> FindById(Guid id)
        {
            var response = _mapper.Map<UserResponse>(await _userRepository.FindById(id));
            
            if(response == null)
            {
                throw new Exception("Couldn't find the user with the specified  id");
            }

            return response;
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            var user = await _userRepository.GetAll();
            
            if(user == null)
            {
                throw new Exception("Couldn't find the users");
            }

            return user;
        }

        public async Task<UserResponse> FindByEmail(string email)
        {
           var response = _mapper.Map<UserResponse> (await _userRepository.FindByEmail(email));

           if (response == null)
           {
                throw new Exception("Couldn't find the user with the specified email");
           }

            return response;
        }

        public async Task<UserResponse> FindByName(string name)
        {
            var response = _mapper.Map<UserResponse> (await _userRepository.FindByName(name));

           if (response == null)
           {
                throw new Exception("Couldn't find the user with the specified name");
           }

            return response;
        }
    }
}

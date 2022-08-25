using APIEstudos.Infrastructure;
using APIEstudos.Infrastructure.Models;

namespace APIEstudos.Domain.Interfaces.Implements
{
    public class UserRepository : IUserRepository
    {
        private readonly DbBaseContext _context;

        public UserRepository(DbBaseContext context)
        {
            _context = context;
        }

        public async Task Add(UserModel entity)
        {
             await _context.Users.AddAsync(new UserModel
            {
                Name = entity.Name,
                Email = entity.Email,
                Date = entity.Date
            });
            await _context.SaveChangesAsync();
        }

        public Task Delete(UserModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UserModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

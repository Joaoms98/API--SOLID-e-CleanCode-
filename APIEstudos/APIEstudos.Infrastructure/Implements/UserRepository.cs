using APIEstudos.Core.Models;
using APIEstudos.Infrastructure;
using Microsoft.EntityFrameworkCore;

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

        public async Task<UserModel> FindById(Guid id)
        {
            return await _context.Users
                    .FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task Update(UserModel entity)
        {
            throw new NotImplementedException();
        }
    }
}

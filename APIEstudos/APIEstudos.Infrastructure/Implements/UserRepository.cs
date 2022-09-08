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
                Date = DateTime.Now
            });
            await _context.SaveChangesAsync();
        }

        public async Task Update(UserModel entity)
        {
            var User = await FindById(entity.Id);
            User.Name = entity.Name;
            User.Email = entity.Email;
            _context.Users.Update(User);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            _context.Remove(await FindById(id));
            await _context.SaveChangesAsync();
        }

        public async Task<UserModel> FindById(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return await _context.Users
                .ToListAsync();
        }

        public async Task<UserModel> FindByEmail(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserModel> FindByName(string name)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Name == name);
        }
    }
}

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

        public async Task CreateUserAsync(UserModel user)
        {
            await _context.Users.AddAsync(new UserModel
            {
                Name = user.Name,
                Email = user.Email,
                Date = user.Date
            });
            await _context.SaveChangesAsync();
        }
    }
}

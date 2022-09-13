using APIEstudos.Infrastructure;
using Microsoft.EntityFrameworkCore;
using APIEstudos.Core.Models;

namespace APIEstudos.Domain.Interfaces.Implements
{
    public class UserRepository : IUserRepository
    {
        private readonly DbBaseContext _context;

        public UserRepository(DbBaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method for adding a user to the repository
        /// </summary>
        /// <param name="entity">UserModel</param>
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

        /// <summary>
        /// Method for Update a user to the repository
        /// </summary>
        /// <param name="entity">UserModel</param>
        public async Task Update(UserModel entity)
        {
            var User = await FindById(entity.Id);
            User.Name = entity.Name;
            User.Email = entity.Email;
            _context.Users.Update(User);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method for deleted a user to the repository
        /// </summary>
        /// <param name="id">Guid id</param>
        public async Task Delete(Guid id)
        {
            _context.Remove(await FindById(id));
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method for find a user by id
        /// </summary>
        /// <param name="id">Guid id</param>
        public async Task<UserModel> FindById(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        /// Method for get all users
        /// </summary>
        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return await _context.Users
                .ToListAsync();
        }

        /// <summary>
        /// Method for find a user by email
        /// </summary>
        /// <param name="email">email user</param>
        public async Task<UserModel> FindByEmail(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        /// <summary>
        /// Method for find a user by name
        /// </summary>
        /// <param name="name">name user</param>
        public async Task<UserModel> FindByName(string name)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Name == name);
        }
    }
}

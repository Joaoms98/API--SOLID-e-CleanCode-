using Microsoft.EntityFrameworkCore;
using APIEstudos.Infrastructure.Models;

namespace APIEstudos.Infrastructure
{
    public class DbBaseContext : DbContext
    {
        public DbBaseContext(DbContextOptions<DbBaseContext> opt) : base(opt)
        {
        }
        public DbSet<UserModel> Users { get; set; }
    }
}   

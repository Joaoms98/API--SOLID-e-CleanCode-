using APIEstudos.Core.Models;
using Microsoft.EntityFrameworkCore;

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

using APIEstudos.models;
using Microsoft.EntityFrameworkCore;

namespace APIEstudos.Data
{
    public class DbBaseContext : DbContext
    {
        public DbBaseContext(DbContextOptions<DbBaseContext> opt) : base(opt)
        {
        }
        public DbSet<UserModel> Users { get; set; }
    }
}

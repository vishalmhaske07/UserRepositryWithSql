using Microsoft.EntityFrameworkCore;
using UserRepositryWithSql.Models;

namespace UserRepositryWithSql.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext>options) : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
    }
}

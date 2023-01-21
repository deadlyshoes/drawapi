using Microsoft.EntityFrameworkCore;

namespace DrawApi.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; } = null!;
    }
}

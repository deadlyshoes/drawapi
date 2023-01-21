using Microsoft.EntityFrameworkCore;

namespace DrawApi.Models
{
    public class ShapeContext : DbContext
    {
        public ShapeContext(DbContextOptions<ShapeContext> options) : base(options)
        {
        }

        public DbSet<Shape> shapes { get; set; } = null!;
        public DbSet<User> users { get; set; } = null!;
    }
}

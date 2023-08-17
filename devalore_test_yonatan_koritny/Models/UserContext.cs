using Microsoft.EntityFrameworkCore;

namespace devalore_test_yonatan_koritny.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
    }
}

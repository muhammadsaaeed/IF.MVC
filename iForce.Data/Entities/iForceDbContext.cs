using System.Data.Entity;

namespace iForce.Data.Entities
{
    public class iForceDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
    }
}

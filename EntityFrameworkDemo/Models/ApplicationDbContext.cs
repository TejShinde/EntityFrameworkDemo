using Microsoft .EntityFrameworkCore;

namespace EntityFrameworkDemo .Models
    {
    public class ApplicationDbContext : DbContext
        {
        // override configuration that we need at app level
        public ApplicationDbContext ( DbContextOptions<ApplicationDbContext> options ) : base(options)

            {
            }
        // LINQ  --> conversion DBset --> SQL  -> exec
        // Entity <Employee> 
        public DbSet<EmployeeEF> Employees { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; } // New UserLogin table
        }
}

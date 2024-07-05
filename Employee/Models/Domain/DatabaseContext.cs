using Microsoft.EntityFrameworkCore;

namespace Employee.Models.Domain
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext>options):base(options) 
        {
            
        }
        public DbSet<Employees> Employees { get; set; }
    }
}

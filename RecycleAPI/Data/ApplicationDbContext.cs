using Microsoft.EntityFrameworkCore;
using RecycleAPI.Data.Entities;

namespace RecycleAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recycle> Recycles { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Status> Statuses { get; set; }

    }
}

using EventManagerWeb.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace EventManagerWeb.DataAccess
{
    public class EventManagerDbContext : DbContext
    {
        private readonly IConfiguration configuration;
        public EventManagerDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MINH-LAPTOP;Database=EventManagerDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Event>().ToTable("Events");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<EnrolledEvent>().ToTable("EnrolledEvents");
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EnrolledEvent> EnrolledEvents { get; set; }
        public DbSet<User> Users { get; set; }

    }
}

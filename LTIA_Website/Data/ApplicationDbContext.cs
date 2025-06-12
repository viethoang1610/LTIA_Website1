using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LTIA_website.Models;

namespace LTIA_website.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Flight> Flights { get; set; } = default!;
        public DbSet<Airline> Airlines { get; set; } = default!;
        public DbSet<News> News { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Định nghĩa rõ khoá chính cho Airline
            builder.Entity<Airline>().HasKey(a => a.Id);
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>    
    {
        public DbSet<Goods> Commodity { get; set; } 
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cart>()
                .Property(b => b.Count)
                .HasDefaultValue(1);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

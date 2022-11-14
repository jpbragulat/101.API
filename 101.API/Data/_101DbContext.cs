using _101.API.Models;
using Microsoft.EntityFrameworkCore;

namespace _101.API.Data
{
    
    
    public class _101DbContext : DbContext
    {
        public _101DbContext(DbContextOptions<_101DbContext> options) : base(options) { }
        
        public DbSet<Users> Users { get; set; } // tiene q llamarse igual que la DB
        public DbSet<Cars> Cars { get; set; }

       // protected override void OnModelCreating(ModelBuilder modelBuilder)
       //{
       //     modelBuilder.Entity<Users>().ToTable("Users");
       //
       // }
    }
}


using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using echarging.Models;


namespace echarging.Data
{
    public class echargingContext : DbContext
    {
        public echargingContext (DbContextOptions<echargingContext> options)
            : base(options)
        {
        }

        public DbSet<Kwh> Kwh { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kwh>().ToTable("Kwh");
        }
    }
}

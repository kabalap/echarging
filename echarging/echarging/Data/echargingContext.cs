using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Kwh>().ToTable("Kwhdata");
        }
    }
}

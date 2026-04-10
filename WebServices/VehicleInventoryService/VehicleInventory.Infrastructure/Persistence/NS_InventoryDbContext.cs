using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain.Entities;

namespace VehicleInventory.InfrastructureNS.Persistence
{
    public class NS_InventoryDbContext : DbContext
    {
        public NS_InventoryDbContext   (DbContextOptions<NS_InventoryDbContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.VehicleCode).IsRequired().HasMaxLength(50);
                entity.Property(v => v.VehicleType).IsRequired().HasMaxLength(50);
                entity.Property(v => v.LocationId).IsRequired();
                entity.Property(v => v.Status).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}

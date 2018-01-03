using Microsoft.EntityFrameworkCore;
using donut_arugular_SPA.Models;

namespace donut_arugular_SPA
{
    public class myDbContext : DbContext 
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<ModelFeature> ModelFeatures { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleFeature> VehicleFeatures { get; set; }
        public myDbContext(DbContextOptions<myDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>().HasKey(vf => new {vf.VehicleId, vf.FeatureId});
        }

    }
}
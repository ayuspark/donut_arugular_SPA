using Microsoft.EntityFrameworkCore;
using donut_arugular_SPA.Models;

namespace donut_arugular_SPA
{
    public class myDbContext : DbContext 
    {
        public myDbContext(DbContextOptions<myDbContext> options) : base(options)
        {
        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}
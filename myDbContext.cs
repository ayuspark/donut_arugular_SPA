using Microsoft.EntityFrameworkCore;

namespace donut_arugular_SPA
{
    public class myDbContext : DbContext 
    {
        public myDbContext(DbContextOptions<myDbContext> options) : base(options)
        {
            
        }
    }
}
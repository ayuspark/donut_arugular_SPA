using System.Threading.Tasks;
using donut_arugular_SPA.Models;
using donut_arugular_SPA.Persistence;
using Microsoft.EntityFrameworkCore;

namespace donut_arugular_SPA.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly myDbContext _context;

        public VehicleRepository(myDbContext context)
        {
            _context = context;
        }
        public async Task<Vehicle> GetVehicleAsync(int id, bool includeRelatedProp = true)
        {
            if(!includeRelatedProp)
            {
                return await _context.Vehicles.FindAsync(id);
            }
            return await _context.Vehicles
            .Include(v => v.Features)
                .ThenInclude(f => f.Feature)
            .Include(v => v.Model)
                .ThenInclude(m => m.Make)
            .SingleOrDefaultAsync(v => v.Id == id);
        }

        public void Add(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
        }

        public void Remove(Vehicle v)
        {
            _context.Vehicles.Remove(v);
        }
    }
}
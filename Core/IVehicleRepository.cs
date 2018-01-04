using System.Collections.Generic;
using System.Threading.Tasks;
using donut_arugular_SPA.Models;

namespace donut_arugular_SPA.Persistence
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleAsync(int id, bool includeRelatedProp = true);
        Task<IEnumerable<Vehicle>> AllVehicles();
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);
    }
}
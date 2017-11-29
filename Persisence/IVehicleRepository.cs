using System.Threading.Tasks;
using donut_arugular_SPA.Models;

namespace donut_arugular_SPA.Persisence
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleAsync(int id);
    }
}
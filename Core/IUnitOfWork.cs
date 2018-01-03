using System.Threading.Tasks;

namespace donut_arugular_SPA.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
using System.Threading.Tasks;

namespace donut_arugular_SPA.Persisence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
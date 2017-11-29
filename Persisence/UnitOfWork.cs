using System.Threading.Tasks;

namespace donut_arugular_SPA.Persisence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly myDbContext _context;
        public UnitOfWork(myDbContext context)
        {
            _context = context;

        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
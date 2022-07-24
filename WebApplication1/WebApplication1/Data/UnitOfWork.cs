using WebApplication1.Data.Repository;
using WebApplication1.Interfaces;

namespace WebApplication1.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IUrlModelRepository _urlRepository;
        public IUrlModelRepository UrlModelRepository
        {
            get
            {
                if (_urlRepository == null)
                {
                    _urlRepository = new UrlModelRepository(_context);
                }
                return _urlRepository;
            }
        }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            _ = await _context.SaveChangesAsync();
        }
    }

}

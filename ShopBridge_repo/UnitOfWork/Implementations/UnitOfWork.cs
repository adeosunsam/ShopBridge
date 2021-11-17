using ShopBridge_data.Contexts;
using ShopBridge_repo.Interfaces;
using ShopBridge_repo.Repository.Implementations;
using ShopBridge_repo.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace ShopBridge_repo.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProductRepository _product;
        private readonly ShopDbContext _context;

        public UnitOfWork(ShopDbContext context)
        {
            _context = context;
        }

        public IProductRepository Product => _product ??= new ProductRepository(_context);

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

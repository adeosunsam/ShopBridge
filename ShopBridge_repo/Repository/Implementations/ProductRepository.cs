using Microsoft.EntityFrameworkCore;
using ShopBridge_data.Contexts;
using ShopBridge_model;
using ShopBridge_repo.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge_repo.Repository.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ShopDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Product>();

        }
        private readonly ShopDbContext _context;
        private readonly DbSet<Product> _dbSet;

        public IQueryable<Product> GetProducts()
        {
            return _dbSet.Select(x => x);
        }

        public async Task<Product> GetProductByName(string productName)
        {
            var findProduct = await _dbSet.FirstOrDefaultAsync(product => product.ProductName == productName);
            return findProduct;
        }

        public async Task<Product> GetProductById(string id)
        {
            var findProduct = await _dbSet.FirstOrDefaultAsync(product => product.Id == id);
            return findProduct;
        }
    }
}

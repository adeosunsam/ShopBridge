using ShopBridge_model;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge_repo.Repository.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable<Product> GetProducts();
        Task<Product> GetProductByName(string productName);
        Task<Product> GetProductById(string id);
    }
}

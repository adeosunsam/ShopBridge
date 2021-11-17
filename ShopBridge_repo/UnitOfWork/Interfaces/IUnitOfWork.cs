using ShopBridge_repo.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace ShopBridge_repo.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Product { get; }
        Task Save();
    }
}

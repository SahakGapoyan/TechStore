using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.Entity;

namespace TechStore.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBrandRepository BrandRepository { get; }
        IModelRepository ModelRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IColorRepository ColorRepository { get; }
        ICartItemRepository CartItemRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IOrderRepository OrderRepository { get; }
        ISmartPhoneRepository SmartPhoneRepository { get; }
        ILaptopRepository LaptopRepository { get; }
        IMemoryRepository MemoryRepository { get; }
        ITvRepository TvRepository { get; }
        IOSRepsoitory OSRepsoitory { get; }
        IRamRepository RamRepository { get; }
        IUserRepository UserRepository { get; }
        IProductRepository<T> GetProductRepository<T>(CancellationToken token = default) where T : Product;
        Task SaveAsync(CancellationToken token);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.DbContext;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechStoreDbContext _context;

        public UnitOfWork(TechStoreDbContext context)
        {
            _context = context;
            BrandRepository = new BrandRepository(_context);
            ModelRepository = new ModelRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            ColorRepository = new ColorRepository(_context);
            UserRepository = new UserRepository(_context);
            CartItemRepository = new CartItemRepository(_context);
            OrderItemRepository = new OrderItemRepository(_context);
            OrderRepository = new OrderRepository(_context);
            SmartPhoneRepository = new SmartPhoneRepository(_context);
            LaptopRepository = new LaptopRepository(_context);
            TvRepository = new TvRepository(_context);
            RamRepository = new RamRepository(_context);
            MemoryRepository = new MemoryRepository(_context);
            OSRepsoitory = new OSRepository(_context);

        }
        public IBrandRepository BrandRepository { get; }

        public ICartItemRepository CartItemRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public IColorRepository ColorRepository { get; }

        public ILaptopRepository LaptopRepository { get; }

        public IMemoryRepository MemoryRepository { get; }

        public IModelRepository ModelRepository { get; }

        public IOrderItemRepository OrderItemRepository { get; }

        public IOrderRepository OrderRepository { get; }

        public IOSRepsoitory OSRepsoitory { get; }

        public IRamRepository RamRepository { get; }

        public ISmartPhoneRepository SmartPhoneRepository { get; }

        public ITvRepository TvRepository { get; }

        public IUserRepository UserRepository { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IProductRepository<T> GetProductRepository<T>(CancellationToken token = default) where T : Product
        {
            return new ProductRepository<T>(_context);
        }

        public async Task SaveAsync(CancellationToken token)
        {
            await _context.SaveChangesAsync(token);
        }

    }
}

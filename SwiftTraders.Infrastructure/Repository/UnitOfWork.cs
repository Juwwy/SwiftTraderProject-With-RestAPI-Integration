using SwiftTraders.ApplicationCore.Entities;
using SwiftTraders.ApplicationCore.Interfaces.Repositories;
using SwiftTraders.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraders.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public IRepository<Category> Categories { get; private set; }

        public IRepository<Products> Products { get; private set; }

        public IRepository<AdvertModel> Adverts { get; private set; }
        public IRepository<Order> Orders { get; private set; }

        private readonly SwiftTraderDbContext DbContext;

        public UnitOfWork(IRepository<Products> productRepository, IRepository<Category> categoryRepository, IRepository<AdvertModel> advertRepository, IRepository<Order> orderRepository, SwiftTraderDbContext dbContext)
        {
            Products = productRepository;
            Categories = categoryRepository;
            Adverts = advertRepository;
            Orders = orderRepository;
            DbContext = dbContext;
        }

        public async Task<int> Complete()
        {
            return await DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}

using SwiftTraders.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraders.ApplicationCore.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Category> Categories { get; }
        public IRepository<Products> Products { get; }
        public IRepository<AdvertModel> Adverts { get; }
        public IRepository<Order> Orders { get; }
        Task<int> Complete();
    }
}

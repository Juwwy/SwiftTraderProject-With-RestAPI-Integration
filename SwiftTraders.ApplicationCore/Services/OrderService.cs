using SwiftTraders.ApplicationCore.DTOs;
using SwiftTraders.ApplicationCore.Entities;
using SwiftTraders.ApplicationCore.Interfaces.Repositories;
using SwiftTraders.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraders.ApplicationCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly string[] includes = new string[] {  };

        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> AddOrder(OrderDTO id)
        {
            var order = new Order()
            {
                
                ProductName = id.ProductName,
                Price = id.Price,
                Username = id.Username,
                TotalCost = id.TotalCost,
                Quantity = id.Quantity
            };

            await unitOfWork.Orders.Add(order);
            await unitOfWork.Complete();

            return order.Id;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrders(int count = 20)
        {
            var order = await unitOfWork.Orders.GetAll(includes);
            return order.Select(o => Map(o)).ToList();
        }

        public async Task<OrderDTO> GetOrder(string id)
        {
            return Map(await unitOfWork.Orders.Get(o => o.Id == id, includes));
        }

        public async Task RemoveOrder(string id)
        {
            var order = await unitOfWork.Orders.Find(id);
            unitOfWork.Orders.Remove(order);
            await unitOfWork.Complete();
        }

        private static OrderDTO Map(Order model)
        {
            return new OrderDTO
            {
                OrderId = model.Id,
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                Quantity = model.Quantity,
                Username = model.Username,
                TotalCost = model.TotalCost,
                Price = model.Price
            };
        }
    }
}

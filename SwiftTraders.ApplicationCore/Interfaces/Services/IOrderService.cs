using SwiftTraders.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraders.ApplicationCore.Interfaces.Services
{
    public interface IOrderService
    {
        Task<OrderDTO> GetOrder(string id);

        Task<IEnumerable<OrderDTO>> GetAllOrders(int count = 20);
        Task<string> AddOrder(OrderDTO id);
        Task RemoveOrder(string id);
    }
}

using SwiftTraders.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraders.ApplicationCore.Interfaces.Services
{
    public interface IProductService
    {
        Task<ProductsDTO> GetProduct(string id);
        Task<IEnumerable<ProductsDTO>> GetAllProduct(int count = 20);
        Task<string> AddProduct(ProductsDTO product);
        Task RemoveProduct(string id);
    }
}

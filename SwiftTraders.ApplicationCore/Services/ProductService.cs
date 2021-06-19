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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly string[] includes = new string[] { "Category"};

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> AddProduct(ProductsDTO model)
        {
            var product = new Products()
            {
                ProductName = model.ProductName,
                CategoryId = model.CatId,
                Price = model.Price,
                Description = model.Description,
                ImgUrl = model.ImgUrl
            };

            await unitOfWork.Products.Add(product);
            await unitOfWork.Complete();

            return product.Id;
        }

        public async Task<IEnumerable<ProductsDTO>> GetAllProduct(int count = 60)
        {
            var prod = await unitOfWork.Products.GetAll(includes);
            return prod.Select(p => Map(p)).ToList();
        }

        public async Task<ProductsDTO> GetProduct(string id)
        {
            return Map(await unitOfWork.Products.Get(a => a.Id == id, includes));
        }

        public async Task RemoveProduct(string id)
        {
            var prod = await unitOfWork.Products.Find(id);
            unitOfWork.Products.Remove(prod);
            await unitOfWork.Complete();
        }

        private static ProductsDTO Map(Products model)
        {
            return new ProductsDTO()
            {
                ProductId = model.Id,
                CatId = model.CategoryId,
                Price = model.Price,
                Description = model.Description,
                ProductName = model.ProductName,
                ImgUrl = model.ImgUrl
            };
        }
    }
}

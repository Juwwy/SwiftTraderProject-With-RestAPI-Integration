using Firebase.Database;
using SwiftTraderPRoject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraderPRoject.Services
{
    public class ProductServices
    {
        FirebaseClient client;

        public ProductServices()
        {
            client = new FirebaseClient("https://swifttraderapp-default-rtdb.firebaseio.com/");
        }

        public async Task<List<Products>> GetAllProductsAsync()
        {
            var products = (await client.Child("ProductsItem").OnceAsync<Products>()).Select(p => new Products()
            {
                ProductId = p.Object.ProductId,
                CatId = p.Object.CatId,
                Price = p.Object.Price,
                Description = p.Object.Description,
                ImgUrl = p.Object.ImgUrl,
                ProductName = p.Object.ProductName
            }).ToList();

            return products;
        }

        public async Task<ObservableCollection<Products>> GetProductsByCategoryAsync(int id)
        {
            var itemCategory = new ObservableCollection<Products>();
            var Items = (await GetAllProductsAsync()).Where(p => p.CatId == id).ToList();
            foreach (var item in Items)
            {
                itemCategory.Add(item);
            }

            return itemCategory;
        }

        public async Task<ObservableCollection<Products>> GetLatestProduct()
        {
            var latestItem = new ObservableCollection<Products>();
            var Items = (await GetAllProductsAsync()).OrderByDescending(f => f.ProductId).Take(5);

            foreach(var item in Items)
            {
                latestItem.Add(item);
            }

            return latestItem;
        }
    }
}

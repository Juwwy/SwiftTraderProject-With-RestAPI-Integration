using Newtonsoft.Json;
using SwiftTraderPRoject.Models.RestModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraderPRoject.Services.APIServices
{
    public class ProductService
    {
        HttpClient client = new HttpClient();
        

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            
            string result = await client.GetStringAsync("https://swifttraderpresentationapi.azurewebsites.net/api/v1/Product");
            return JsonConvert.DeserializeObject<IEnumerable<Products>>(result);
        }

        public async Task<Products> AddProduct(string catId, string productName, string description, string imgUrl, decimal price)
        {
            Products product = new Products()
            {
                CatId = catId,
                ProductName = productName,
                Description = description,
                ImgUrl = imgUrl,
                Price = price
            };

           
            var response = await client.PostAsync("https://swifttraderpresentationapi.azurewebsites.net/api/v1/Product", new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<Products>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Products> GetProduct(string id)
        {
            client = new HttpClient();
            string product = await client.GetStringAsync("https://swifttraderpresentationapi.azurewebsites.net/api/v1/Product" + id);
            return JsonConvert.DeserializeObject<Products>(product);
        }

        public async Task RemoveUser(string id)
        {
            client = new HttpClient();
            await client.DeleteAsync("https://swifttraderpresentationapi.azurewebsites.net/api/v1/Product" + id);
        }

        public async Task<ObservableCollection<Products>> GetProductsByCategoryAsync(string id)
        {
            var itemCategory = new ObservableCollection<Products>();
            var Items = (await GetAllProducts()).Where(p => p.CatId == id).ToList();
            foreach (var item in Items)
            {
                itemCategory.Add(item);
            }

            return itemCategory;
        }

        public async Task<ObservableCollection<Products>> GetLatestProduct()
        {
            var latestItem = new ObservableCollection<Products>();
            var Items = (await GetAllProducts()).OrderByDescending(f => f.ProductId).Take(5);

            foreach (var item in Items)
            {
                latestItem.Add(item);
            }

            return latestItem;
        }
    }
}

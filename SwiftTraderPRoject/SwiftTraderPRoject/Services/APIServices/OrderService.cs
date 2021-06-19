using Newtonsoft.Json;
using SwiftTraderPRoject.Models;
using SwiftTraderPRoject.Models.RestModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SwiftTraderPRoject.Services.APIServices
{
    public class OrderService
    {
        HttpClient client;
        //private static readonly string BaseAddress = "";
        //private static readonly string URL = $"{BaseAddress}";
        //private string authorizationKey;


        public async Task<IEnumerable<Order>> GetAllProducts()
        {
            client = new HttpClient();
            string result = await client.GetStringAsync("https://swifttraderpresentationapi.azurewebsites.net/api/v1/Order");
            return JsonConvert.DeserializeObject<IEnumerable<Order>>(result);
        }

        public async Task<Order> AddOrder(string productId, string productName, decimal price, int quantity, string userId, string userName, decimal totalCost)
        {

            Order order = new Order()
            {
                ProductId = productId,
                ProductName = productName,
                Price = price,
                Quantity = quantity,
                UserId = userId,
                Username =userName,
                TotalCost = totalCost
            };

            client = new HttpClient();
            var response = await client.PostAsync("https://swifttraderpresentationapi.azurewebsites.net/api/v1/Order", new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<Order>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Order> GetOrder(string id)
        {
            client = new HttpClient();
            string order = await client.GetStringAsync("https://swifttraderpresentationapi.azurewebsites.net/api/v1/Order" + id);
            return JsonConvert.DeserializeObject<Order>(order);
        }

        public async Task RemoveUser(string id)
        {
            client = new HttpClient();
            await client.DeleteAsync("https://swifttraderpresentationapi.azurewebsites.net/api/v1/Order" + id);
        }

        public async Task<string> PlaceOrderAsync()
        {
            var sqliteDB = DependencyService.Get<ISqlite>().GetConnection();
            var record = sqliteDB.Table<CartItem>().ToList();

            var orderId = Guid.NewGuid().ToString();
            var userName = Preferences.Get("Username", string.Empty);
            decimal totalCost = 0;

            foreach (var item in record)
            {
                Order data = new Order()
                {
                    
                   // OrderId = orderId,
                    ProductName = item.ProductName,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                   
                };

                totalCost += (item.Price * item.Quantity);
                await AddOrder(data.ProductId, data.ProductName, data.Price, data.Quantity, data.UserId, userName, totalCost);
            }

          

            //await client.Child("Orders").PostAsync(new Order()
            //{
            //    OrderId = orderId,
            //    Username = userName,
            //    TotalCost = totalCost
            //});

            return orderId;
        }
    }
}

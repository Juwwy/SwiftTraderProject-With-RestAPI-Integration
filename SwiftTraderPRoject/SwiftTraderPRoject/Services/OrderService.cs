using Firebase.Database;
using Firebase.Database.Query;
using SwiftTraderPRoject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SwiftTraderPRoject.Services
{
    public class OrderService
    {
        FirebaseClient client;
        public decimal Cost { get; set; }
        public OrderService()
        {
            client = new FirebaseClient("https://swifttraderapp-default-rtdb.firebaseio.com/");
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
                OrderDetails data = new OrderDetails()
                {
                    OrderDetailId = Guid.NewGuid().ToString(),
                    OrderId = orderId,
                    ProductName = item.ProductName,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                };

                totalCost += (item.Price * item.Quantity);
                await client.Child("OrderDetails").PostAsync(data);
            }

            Cost = totalCost;

            await client.Child("Orders").PostAsync(new Order()
            {
                OrderId = orderId,
                Username = userName,
                TotalCost = totalCost
            });

            return orderId;
        }

        public override string ToString()
        {
            return $"{Cost}";
        }
    }
}

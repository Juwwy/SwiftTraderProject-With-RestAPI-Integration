using SwiftTraderPRoject.Models;
using SwiftTraderPRoject.Services;
using SwiftTraderPRoject.Services.APIServices;
using SwiftTraderPRoject.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SwiftTraderPRoject.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        public ObservableCollection<UserCartItem> CartItems { get; set; }

        private decimal totalCost;
        public decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; OnPropertyChanged(); }
        }

        public Command OrderCommand { get; set; }

        public CartViewModel()
        {
            CartItems = new ObservableCollection<UserCartItem>();
            LoadItems();
            OrderCommand = new Command(async () => await OrderCommandAsync());
        }

        private void LoadItems()
        {
            var sqliteDB = DependencyService.Get<ISqlite>().GetConnection();
            var data = sqliteDB.Table<CartItem>().ToList();

            CartItems.Clear();

            foreach (var item in data)
            {
                CartItems.Add(new UserCartItem()
                {
                    CartItemId = item.CartItemId,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Cost = item.Price * item.Quantity,
                    Quantity = item.Quantity
                    
                });

               TotalCost += (item.Price * item.Quantity);
            }
        }

        private async Task OrderCommandAsync()
        {
           if(TotalCost > 0)
            {
                var order = await new OrderService().PlaceOrderAsync() as string;
                RemoveItemsFromCart();
                await Application.Current.MainPage.Navigation.PushModalAsync(new OrderPage(order)); //order
            }
            else { await Application.Current.MainPage.DisplayAlert("Order Declined!", "Cart is empty", "Ok"); }
        }

        private void RemoveItemsFromCart()
        {
            var deleteItem = new CartItemService();
            deleteItem.RemoveItemsFromCart();
        }
    }
}

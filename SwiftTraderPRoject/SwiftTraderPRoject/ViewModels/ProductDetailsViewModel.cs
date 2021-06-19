using SwiftTraderPRoject.Models;
using SwiftTraderPRoject.Models.RestModels;
using SwiftTraderPRoject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SwiftTraderPRoject.ViewModels
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        private Products selectedProducts;
        public Products SelectedProducts
        {
            get { return selectedProducts; }
            set { selectedProducts = value; OnPropertyChanged(); }
        }

        private int totalQty;
        public int TotalQty
        {
            get { return totalQty; }
            set 
            { totalQty = value;
                if (totalQty < 0)
                    totalQty = 0;
                else if (totalQty > 10)
                    totalQty -= 1;
                OnPropertyChanged();
            }
        }

        public Command IncrementCommand { get; set; }
        public Command DecrementCommand { get; set; }
        public Command AddToCartCommand { get; set; }
        public Command ViewCartCommand { get; set; }
        public Command HomePageCommand { get; set; }

        public ProductDetailsViewModel(Products product)
        {
            SelectedProducts = product;
            TotalQty = 0;
            IncrementCommand = new Command(() => IncrementCom());
            DecrementCommand = new Command(() => DecrementCom());
            AddToCartCommand = new Command( () =>  AddToCart());
            ViewCartCommand = new Command(async () => await ViewCartCommandAsync());
            HomePageCommand = new Command(async () => await HomePageCommandAsync());
        }
        public ProductDetailsViewModel()
        {

        }

        private async Task HomePageCommandAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new DashBoard());
        }

        private async Task ViewCartCommandAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        }

        private void AddToCart()
        {

           
            if (TotalQty > 0)
            {
                var sqliteConn = DependencyService.Get<ISqlite>().GetConnection();
                try
                {
                    CartItem item = new CartItem
                    {
                        ProductId = SelectedProducts.ProductId,
                        ProductName = SelectedProducts.ProductName,
                        Price = SelectedProducts.Price,
                        Quantity = TotalQty
                    };

                    var data = sqliteConn.Table<CartItem>().ToList().FirstOrDefault(d => d.ProductId == SelectedProducts.ProductId);
                    if (data == null)
                        sqliteConn.Insert(item);
                    else { data.Quantity += TotalQty; }
                    sqliteConn.Update(data);

                    sqliteConn.Commit();
                    sqliteConn.Close();

                    Application.Current.MainPage.DisplayAlert("Success", "Selected item added to cart", "Ok");
                }
                catch (Exception ex)
                {

                    Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                }
                finally { sqliteConn.Close(); }
            }
            else { Application.Current.MainPage.DisplayAlert("Invalid Order", "Quantity cannot be empty", "Ok"); return; }
        }

        private void DecrementCom()
        {
            TotalQty--;
        }

        private void IncrementCom()
        {
            TotalQty++;
        }

    }
}

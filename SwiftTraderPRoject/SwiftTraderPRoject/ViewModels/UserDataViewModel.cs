using SwiftTraderPRoject.Models;
using SwiftTraderPRoject.Models.RestModels;
using SwiftTraderPRoject.Services;
using SwiftTraderPRoject.Services.APIServices;
using SwiftTraderPRoject.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SwiftTraderPRoject.ViewModels
{
    public class UserDataViewModel : BaseViewModel
    {
        private string fullname;
        public string Fullname
        {
            get { return fullname; }
            set { fullname = value; OnPropertyChanged(); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value.Trim().ToLower(); OnPropertyChanged(); }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set { username = value.Trim(); OnPropertyChanged(); }
        }

        private string telephone;
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value.Trim(); OnPropertyChanged(); }
        }

        private int userCartItemsCount;
        public int UserCartItemsCount
        {
            get { return userCartItemsCount; }
            set { userCartItemsCount = value; OnPropertyChanged(); }
        }

        public Command ViewCartCommand { get; set; }
        public Command LogoutCommand { get; set; }

        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Products> LatestItems { get; set; }
        public ObservableCollection<AdvertModel> Adverts { get; set; }
        public ObservableCollection<UserCartItem> Services { get; set; }
        public ObservableCollection<Products> Products { get; set; }



        public UserDataViewModel()
        {
            GetData();
            UserCartItemsCount = new CartItemService().GetUserCartCount();
            ViewCartCommand = new Command(async () => await ViewCartCommandAsync());
            LogoutCommand = new Command(async () => await LogoutCommandAsync());
            Categories = new ObservableCollection<Category>();
            LatestItems = new ObservableCollection<Products>();
            Adverts = new ObservableCollection<AdvertModel>();
            Services = new ObservableCollection<UserCartItem>();
            Products = new ObservableCollection<Products>();
            GetCategory();
            GetLatestItemsAsync();
            GetAdvertsAsync();
            GetAllProducts();
        }

        public  void GetCartItemService()
        {
            Services = new CartViewModel().CartItems;
        }

        

        private async Task ViewCartCommandAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        }

        private async Task LogoutCommandAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LogoutPage());
        }

        private void GetData()
        {
            Fullname = Preferences.Get("Fullname", string.Empty);
            Email = Preferences.Get("Email", string.Empty);
            Username = Preferences.Get("Username", string.Empty);
            Telephone = Preferences.Get("Telephone", string.Empty);
        }

        private async void GetCategory()
        {
            var data = await new CategoryService().GetAllCategory();
            Categories.Clear();

            foreach (var item in data)
            {
                Categories.Add(item);
            }

        }

        private async void GetLatestItemsAsync()
        {
            var data = await new ProductService().GetLatestProduct();
            LatestItems.Clear();

            foreach (var item in data)
            {
                LatestItems.Add(item);
            }
        }

        private async void GetAllProducts()
        {
            var data = await new ProductService().GetAllProducts();
            Products.Clear();

            foreach (var item in data)
            {
                Products.Add(item);
            }
        }

        private async void GetAdvertsAsync()
        {
            var data = await new AdvertService().GetAllAdverts();
            Adverts.Clear();

            foreach (var item in data)
            {
                Adverts.Add(item);
            }
        }
    }
}

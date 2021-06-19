using SwiftTraderPRoject.Services;
using SwiftTraderPRoject.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SwiftTraderPRoject.ViewModels
{
    public class LogoutViewModel : BaseViewModel
    {
        private int userCartItemCount;
        public int UserCartItemCount
        {
            get { return userCartItemCount; }
            set { userCartItemCount = value; OnPropertyChanged(); }
        }

        private bool isCartExists;
        public bool IsCartExists
        {
            get { return isCartExists; }
            set { isCartExists = value; OnPropertyChanged(); }
        }

        public Command ExitCommand { get; set; }
        public Command RevertToCartCommand { get; set; }

        public LogoutViewModel()
        {
            UserCartItemCount = new CartItemService().GetUserCartCount();

            IsCartExists = (UserCartItemCount > 0) ? true : false;
            ExitCommand = new Command( () => ExitCommandAsync());
            RevertToCartCommand = new Command(async () => await RevertToCartCommandAsync());
        }

        private async Task RevertToCartCommandAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new DashBoard());
        }

        private void ExitCommandAsync()
        {
            var del = new CartItemService();
             del.RemoveItemsFromCart();
            Preferences.Remove("Username");
            Application.Current.MainPage.Navigation.PushModalAsync( new LoginPage());
        }
    }
}

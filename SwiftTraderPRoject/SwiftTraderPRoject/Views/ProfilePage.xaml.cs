using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwiftTraderPRoject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private void CartBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        }

        private void SettingBtn_Clicked(object sender, EventArgs e)
        {
            
        }

        private void PaymentTapped_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new PaymentPage());
        }
    }
}
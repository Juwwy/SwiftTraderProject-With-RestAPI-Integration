using SwiftTraderPRoject.Services;
using SwiftTraderPRoject.Services.APIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwiftTraderPRoject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        public OrderPage(string id) //string id
        {
            InitializeComponent();
            user_name.Text = Preferences.Get("Username", string.Empty);
            orderId.Text = id;
            var getCost = new OrderService();
            cost.Text = getCost.ToString();
        }

        private void BackBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainDashBoard();
        }
    }
}
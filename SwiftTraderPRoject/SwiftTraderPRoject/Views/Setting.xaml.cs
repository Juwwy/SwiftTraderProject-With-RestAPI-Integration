using SwiftTraderPRoject.Helpers;
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
    public partial class Setting : ContentPage
    {
        public Setting()
        {
            InitializeComponent();
        }

        private async void Ads_Clicked(object sender, EventArgs e)
        {
            var ads = new AddAdvert();
            await ads.GetAllAdvert();
        }

        private async void Cat_Clicked(object sender, EventArgs e)
        {
            var category = new AddCategory();
            await category.AddCategoriesAsync();
        }

        private async void Prod_Clicked(object sender, EventArgs e)
        {
            var products = new AddProducts();
            await products.GetAllProductAsync();
        }

        private void BtnCreateTable_Clicked(object sender, EventArgs e)
        {
            var create = new CreateCartTable();
            if(create.CreateTable())
            {
                DisplayAlert("Success", "Cart Table Created", "Ok");
            }
            else { DisplayAlert("Error", "Error while creating table", "Ok"); }
        }
    }
}
using SwiftTraderPRoject.Models;
using SwiftTraderPRoject.Models.RestModels;
using SwiftTraderPRoject.ViewModels;
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
    public partial class ProductDetailsPage : ContentPage
    {
        
        private ProductDetailsViewModel pvm;


        public ProductDetailsPage(Products products)
        {
            InitializeComponent();
            pvm = new ProductDetailsViewModel(products);
            this.BindingContext = pvm;
        }

        private async void BackBtn_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new MainDashBoard());
        }

        
    }
}
using SwiftTraderPRoject.Models;
using SwiftTraderPRoject.Models.RestModels;
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
    public partial class AllProductPage : ContentPage
    {
        public AllProductPage()
        {
            InitializeComponent();
        }

        private async void ProductSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var prod = e.CurrentSelection.FirstOrDefault() as Products;
            if (prod == null)
                return;
            await Navigation.PushModalAsync(new ProductDetailsPage(prod));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
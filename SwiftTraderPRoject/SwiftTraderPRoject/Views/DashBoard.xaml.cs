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
    public partial class DashBoard : ContentPage
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private async void Category_Select(object sender, SelectionChangedEventArgs e)
        {
            var category = e.CurrentSelection.FirstOrDefault() as Category;
            if (category == null)
                return;

            await Navigation.PushModalAsync(new ProductCategoryPage(category));//check later to add category
            ((CollectionView)sender).SelectedItem = null;
        }

        private async void ProductSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = e.CurrentSelection.FirstOrDefault() as Products;
            if (product == null)
                return;

            await Navigation.PushModalAsync(new ProductDetailsPage(product));
            ((CollectionView)sender).SelectedItem = null;
         }
    }
}
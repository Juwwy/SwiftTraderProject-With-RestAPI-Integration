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
    public partial class ProductCategoryPage : ContentPage
    {
        ProductPageViewModel import;
         // category into productpageviewmodel
        public ProductCategoryPage(Category category)
        {
            InitializeComponent();
            import = new ProductPageViewModel(category);
            this.BindingContext = import;
        }

        private async void TypeSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as Products;
            if (selectedItem == null)
                return;

            await Navigation.PushModalAsync(new ProductDetailsPage(selectedItem)); // selectedItem
            ((CollectionView)sender).SelectedItem = null;


        }
    }
}
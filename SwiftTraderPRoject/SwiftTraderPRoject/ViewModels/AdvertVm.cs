using SwiftTraderPRoject.Services.APIServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SwiftTraderPRoject.ViewModels
{
    public class AdvertVm : BaseViewModel
    {
        private string ad;
        public string Ad 
        {       get { return ad; } 
            
            set { ad = value; OnPropertyChanged(); }
        }

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }


        private bool result;
        public bool Result
        {
            get { return result; }
            set { result = value; OnPropertyChanged(); }
        }


        public Command AddAdsCommand { get; set; }

        public AdvertVm()
        {
            AddAdsCommand = new Command(async () => await AddAdsCommandAsync());
        }

        private async Task AddAdsCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                if(string.IsNullOrEmpty(Ad))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Ads cannot be empty", "Ok");
                    return;
                }

                AdvertService user = new AdvertService();

                Result = await user.Addads(Ad);

                if(Result)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "ad added successfully", "Ok");
                }
            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally { IsBusy = false; }
        }
    }
}

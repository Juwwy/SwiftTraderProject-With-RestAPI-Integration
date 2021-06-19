using Firebase.Database;
using Firebase.Database.Query;
using SwiftTraderPRoject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SwiftTraderPRoject.Helpers
{
    public class AddAdvert
    {
        FirebaseClient client;
        public List<AdvertModel> Adverts { get; set; }

        public AddAdvert()
        {
            client = new FirebaseClient("https://swifttraderapp-default-rtdb.firebaseio.com/");
            Adverts = new List<AdvertModel>()
            {
               new AdvertModel()
               {
                   SwiftTraderAdVert = "ad5t.jpg"
               },
               new AdvertModel()
               {
                   SwiftTraderAdVert = "ad3.jpg"
               },
               new AdvertModel()
               {
                   SwiftTraderAdVert = "ad1t"
               },
               new AdvertModel()
               {
                   SwiftTraderAdVert = "Ad2.jpg"
               },

            };
        }

        public async Task GetAllAdvert()
        {
            try
            {
                foreach (var ads in Adverts)
                {
                    await client.Child("Adverts").PostAsync(new AdvertModel()
                    {
                        SwiftTraderAdVert = ads.SwiftTraderAdVert
                    });
                }
            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        
    }
}

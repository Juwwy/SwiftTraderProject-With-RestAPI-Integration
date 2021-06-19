using Firebase.Database;
using SwiftTraderPRoject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraderPRoject.Services
{
    public class AdvertService
    {
        FirebaseClient client;

        public AdvertService()
        {
            client = new FirebaseClient("https://swifttraderapp-default-rtdb.firebaseio.com/");
        }

        public async Task<List<AdvertModel>> GetAdvertsAsync()
        {
            var ads = (await client.Child("Adverts").OnceAsync<AdvertModel>()).Select(a => new AdvertModel()
            {
                SwiftTraderAdVert = a.Object.SwiftTraderAdVert,
            }).ToList();

            return ads;
        }
    }
}

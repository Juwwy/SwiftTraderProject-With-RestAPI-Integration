using Newtonsoft.Json;
using SwiftTraderPRoject.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraderPRoject.Services.APIServices
{
    public class AdvertService
    {
        HttpClient client;
        
        public async Task<IEnumerable<AdvertModel>> GetAllAdverts()
        {
            client = new HttpClient();
            string result = await client.GetStringAsync("https://swifttraderpresentationapi.azurewebsites.net/api/v1/Advert");
            return JsonConvert.DeserializeObject<IEnumerable<AdvertModel>>(result);
        }

        public async Task<AdvertModel> Addads(string ad)
        {
            AdvertModel ads = new AdvertModel()
            {
                SwiftTraderAdVert = ad
            };

            client = new HttpClient();
            var response = await client.PostAsync("https://swifttraderpresentationapi.azurewebsites.net/api/v1/Advert", new StringContent(JsonConvert.SerializeObject(ads), Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<AdvertModel>(await response.Content.ReadAsStringAsync());
        }

        public async Task<AdvertModel> GetProduct(string id)
        {
            client = new HttpClient();
            string ads = await client.GetStringAsync("https://swifttraderpresentationapi.azurewebsites.net/api/v1/Advert" + id);
            return JsonConvert.DeserializeObject<AdvertModel>(ads);
        }

        public async Task RemoveUser(string id)
        {
            client = new HttpClient();
            await client.DeleteAsync("https://swifttraderpresentationapi.azurewebsites.net/api/v1/Advert" + id);
        }
    }
}

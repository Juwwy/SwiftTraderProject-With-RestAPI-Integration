using Newtonsoft.Json;
using SwiftTraderPRoject.Models;
using SwiftTraderPRoject.Models.RestModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraderPRoject.Services.APIServices
{
    public class CategoryService
    {
        HttpClient client;
        //private static readonly string BaseAddress = "https";://swifttraderpresentationapi.azurewebsites.net
        //private static readonly string URL = $"{BaseAddress}/api/v1/Category";
        //private string authorizationKey;


        //private async Task<HttpClient> GetClient()
        //{
        //    client = new HttpClient();
        //    if (string.IsNullOrEmpty(authorizationKey))
        //    {
        //        authorizationKey = await client.GetStringAsync(URL + "login");
        //        authorizationKey = JsonConvert.DeserializeObject<string>(authorizationKey);
        //    }

        //    client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
        //    client.DefaultRequestHeaders.Add("Accept", "application/json");

        //    return client;
        //}

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            client = new HttpClient();
            string result = await client.GetStringAsync("https://swifttraderpresentationapi.azurewebsites.net/api/v1/Category");
            return JsonConvert.DeserializeObject<IEnumerable<Category>>(result);
        }

        public async Task<Category> AddCategory(string categoryName, string description, string imgUrl)
        {
            Category category = new Category()
            {
                CategoryName = categoryName,
                Description = description,
                ImgUrl = imgUrl
            };

            client = new HttpClient();
            var response = await client.PostAsync("https://swifttraderpresentationapi.azurewebsites.net/api/v1/Category", new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<Category>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Category> GetCategory(string id)
        {
            client = new HttpClient();
            string cate = await client.GetStringAsync("https://swifttraderpresentationapi.azurewebsites.net/api/v1/Category" + id);
            return JsonConvert.DeserializeObject<Category>(cate);
        }

        public async Task RemoveUser(string id)
        {
            client = new HttpClient();
            await client.DeleteAsync("https://swifttraderpresentationapi.azurewebsites.net/api/v1/Product" + id);
        }

        
    }
}

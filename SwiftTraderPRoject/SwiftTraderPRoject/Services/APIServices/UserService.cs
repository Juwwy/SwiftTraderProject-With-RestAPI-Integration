using Newtonsoft.Json;
using SwiftTraderPRoject.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraderPRoject.Services.APIServices
{
    public class UserService
    {
        HttpClient client;
        private static readonly string BaseAddress = "https://www.google.com/";
        private static readonly string URL = $"{BaseAddress}/api/Users";
        private string authorizationKey;

        private async Task<HttpClient> GetClient()
        {
            client = new HttpClient();
            if(string.IsNullOrEmpty(authorizationKey))
            {
                authorizationKey = await client.GetStringAsync(URL + "login");
                authorizationKey = JsonConvert.DeserializeObject<string>(authorizationKey);
            }

            client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            client = await GetClient();
            string result = await client.GetStringAsync(URL);
            return JsonConvert.DeserializeObject<IEnumerable<Users>>(result);
        }


        public async Task<Users> AddUser(string fullname, string email, string userName, string telephone, string password)
        {
            Users user = new Users()
            {
                Fullname = fullname,
                Email = email,
                Username = userName,
                Telephone = telephone,
                Password = password,
            };

            client = await GetClient();
            var response = await client.PostAsync(URL, new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<Users>(await response.Content.ReadAsStringAsync());


        }

        public async Task<Users> GetUser(string id)
        {
            client = await GetClient();
            string user = await client.GetStringAsync(URL + id);
            return JsonConvert.DeserializeObject<Users>(user);
        }

        public async Task RemoveUser(string id)
        {
            client = await GetClient();
            await client.DeleteAsync(URL + id);
        }
    }
}

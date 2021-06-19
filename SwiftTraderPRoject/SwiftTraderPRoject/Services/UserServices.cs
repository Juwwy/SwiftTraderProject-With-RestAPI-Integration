using Firebase.Database;
using Firebase.Database.Query;
using SwiftTraderPRoject.Models;
using SwiftTraderPRoject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraderPRoject.Services
{
    public class UserServices
    {
        FirebaseClient client;

        public UserServices()
        {
            client = new FirebaseClient("https://swifttraderapp-default-rtdb.firebaseio.com/");
        }

        public async Task<bool> IsUserExist(string userName)
        {
            var user = (await client.Child("Users").OnceAsync<Users>()).Where(u => u.Object.Username == userName).FirstOrDefault();
            return user != null;
        }

        public async Task<bool> RegisterUser(string fullname, string email, string username, string telephone, string password, string CPass)
        {
            if(await IsUserExist(username)== false)
            {
                await client.Child("Users")
                    .PostAsync(new Users()
                    {
                        Fullname = fullname,
                        Email = email,
                        Username = username,
                        Telephone = telephone,
                        Password = password,
                        CPassword = CPass
                    });
               
                return true;
               
            }
            else { return false; }
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            var user = (await client.Child("Users").OnceAsync<Users>()).Where(e => e.Object.Email == email).Where(p => p.Object.Password == password).FirstOrDefault();
            return user != null;
        }

        public async Task<UserDataViewModel> UserData(string email, string pass)
        {
            var user = (await client.Child("Users").OnceAsync<Users>()).Where(u => u.Object.Email == email).Where(u => u.Object.Password == pass).Select(u => new UserDataViewModel()
            {
                Fullname = u.Object.Fullname,
                Email = u.Object.Email,
                Username = u.Object.Username,
                Telephone = u.Object.Telephone
            }).FirstOrDefault();
            return user;
            
        }

    }
}

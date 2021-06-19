using Firebase.Database;
using SwiftTraderPRoject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraderPRoject.Services
{
    public class CategoryServices
    {
        FirebaseClient client;

        public CategoryServices()
        {
            client = new FirebaseClient("https://swifttraderapp-default-rtdb.firebaseio.com/");

        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = (await client.Child("Categories").OnceAsync<Category>()).Select(c => new Category()
            {
                CatId = c.Object.CatId,
                CategoryName = c.Object.CategoryName,
                Description = c.Object.Description,
                ImgUrl = c.Object.ImgUrl
            }).ToList();

            return categories;
        }

        
    }
}

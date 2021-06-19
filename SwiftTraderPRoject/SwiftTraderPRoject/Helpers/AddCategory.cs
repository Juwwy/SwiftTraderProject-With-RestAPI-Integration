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
    public class AddCategory
    {
        FirebaseClient client;
        public List<Category> Categories { get; set; }
        public AddCategory()
        {
            client = new FirebaseClient("https://swifttraderapp-default-rtdb.firebaseio.com/");
            Categories = new List<Category>()
            {
                new Category()
                {
                    CatId = 1,
                    CategoryName = "Clothes",
                    ImgUrl = "prod1.jpg",
                    Description = "Men and Women fashion wear of variety of designs"
                },
                new Category()
                {
                    CatId = 2,
                    CategoryName = "Jewelry",
                    ImgUrl = "gold9.jpg",
                    Description = "Beautifying valuable Jewelry at very affordable rate  "
                },
                new Category()
                {
                    CatId = 3,
                    CategoryName = "Wrist watch",
                    ImgUrl = "watch2.jpg",
                    Description = "Quality men and women style wrist watch at a friendly order rate"
                },
                new Category()
                {
                    CatId = 4,
                    CategoryName = "Shoes",
                    ImgUrl = "shoe1.jpg",
                    Description = "Designers foot wears of any type available"
                },
                new Category()
                {
                    CatId = 5,
                    CategoryName = "Phones",
                    ImgUrl = "TecnoPova.png",
                    Description = "Mobile phone available at cheap rate"
                },

            };
        }

        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach (var item in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CatId = item.CatId,
                        CategoryName = item.CategoryName,
                        ImgUrl = item.ImgUrl,
                        Description = item.Description
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

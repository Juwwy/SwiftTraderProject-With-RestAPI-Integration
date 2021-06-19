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
    public class AddProducts
    {
        FirebaseClient client;
        public List<Products> ProductsItems { get; set; }

        public AddProducts()
        {
            client = new FirebaseClient("https://swifttraderapp-default-rtdb.firebaseio.com/");
            ProductsItems = new List<Products>()
            {
                new Products()
                {
                    ProductId = 1,
                    CatId = 1,
                    ProductName = "Red Gown",
                    Price = 56,
                    Description = "Red female gown with beautiful layers",
                    ImgUrl = "prod1"
                },
                 new Products()
                {
                    ProductId = 2,
                    CatId = 1,
                    ProductName = "French Gown",
                    Price = 80,
                    Description = "Butter color female gown with beautiful layers. Ancient french fashion style ",
                    ImgUrl = "prod2"
                },


                  new Products()
                {
                ProductId = 5,
                CatId = 2,
                ProductName = "Bead necklace",
                Price = 75,
                Description = "Beautiful bead stones necklace for women",
                ImgUrl = "gold2"
                },
                 new Products()
                   {
                    ProductId = 6,
                    CatId = 2,
                    ProductName = "Tiny gold blade ",
                    Price = 135,
                    Description = "Very tiny Gold blade necklace with avery beautiful design",
                    ImgUrl = "gold3"
                   },

                 new Products()
                   {
                    ProductId = 7,
                    CatId = 2,
                    ProductName = "Gold ear rings",
                    Price = 40,
                    Description = "Ear fitting pieces of gold earring for women",
                    ImgUrl = "gold4"
                   },

                new Products()
                {
                ProductId = 3,
                CatId = 1,
                ProductName = "Round neck shirt",
                Price = 35,
                Description = "Unisex round neck short-hand shirt with very soft fabrics",
                ImgUrl = "prod3"
                },

                new Products()
                   {
                    ProductId = 4,
                    CatId = 2,
                    ProductName = "Slim Gold necklace ",
                    Price = 120,
                    Description = "Soft touch neck chain for women",
                    ImgUrl = "gold1"
                   },

                
                 new Products()
                   {
                    ProductId = 8,
                    CatId = 4,
                    ProductName = "Nike Sneakers",
                    Price = 30,
                    Description = "Smart jogging and outfitting footwear for men",
                    ImgUrl = "shoe1"
                   },


                 new Products()
                   {
                    ProductId = 13,
                    CatId = 3,
                    ProductName = "Silver Rollace",
                    Price = 80,
                    Description = "Steel fashioned wristwatch for men",
                    ImgUrl = "watch2"
                   },

                 new Products()
                   {
                    ProductId = 14,
                    CatId = 3,
                    ProductName = "Leather band Wristwatch",
                    Price = 46,
                    Description = "Water resistance wristwatch with very good leather handle",
                    ImgUrl = "watch3"
                   },
                 new Products()
                   {
                    ProductId = 9,
                    CatId = 4,
                    ProductName = "Addidas shoes",
                    Price = 42,
                    Description = "Black Smart jogging and outfitting footwear for men",
                    ImgUrl = "shoe2"
                   },
                 new Products()
                   {
                    ProductId = 10,
                    CatId = 4,
                    ProductName = "Jordan hillboot",
                    Price = 70,
                    Description = "Men white jordan hill top shoe. Very well fit in for party",
                    ImgUrl = "shoe3"
                   },

                 new Products()
                   {
                    ProductId = 11,
                    CatId = 4,
                    ProductName = "Nike Sneakers",
                    Price = 30,
                    Description = "Smart jogging and outfitting footwear for men",
                    ImgUrl = "shoe2"
                   },

                 new Products()
                   {
                    ProductId = 12,
                    CatId = 3,
                    ProductName = "Apple iWatch",
                    Price = 300,
                    Description = "Unisex smart wrist watch",
                    ImgUrl = "watch1"
                   },


                 new Products()
                   {
                    ProductId = 15,
                    CatId = 3,
                    ProductName = "Women Wristwatch",
                    Price = 15,
                    Description = "Multi-color ladies wrist watch with very soft paint texture",
                    ImgUrl = "watch4"
                   },

                 new Products()
                   {
                    ProductId = 16,
                    CatId = 1,
                    ProductName = "Men T-Shirt",
                    Price = 36,
                    Description = "Office made smart long-hand T-Shirt for Men",
                    ImgUrl = "prod4"
                   },


                 new Products()
                   {
                    ProductId = 30,
                    CatId = 5,
                    ProductName = "Tecno Spark 4",
                    Price = 120,
                    Description = "Very strong Battery life device with 3GB RAM with 13MP Rear camera",
                    ImgUrl = "phone1"
                   },

                 new Products()
                   {
                    ProductId = 31,
                    CatId = 5,
                    ProductName = "Samsung 10",
                    Price = 1650,
                    Description = "Samsung marvelous latest product with very friendly user experience. 32MP Rear camera with 8GB RAM with 3200MAh Battery life",
                    ImgUrl = "samsung10"
                   },

                 new Products()
                   {
                    ProductId = 20,
                    CatId = 1,
                    ProductName = "Female elastic gown dress",
                    Price = 145,
                    Description = "Red soft elastic fabric gown for women ",
                    ImgUrl = "prod8"
                   },

                 new Products()
                   {
                    ProductId = 21,
                    CatId = 1,
                    ProductName = "Home net gown",
                    Price = 36,
                    Description = "Simple home and outdoor gown for ladies",
                    ImgUrl = "prod9"
                   },
                 new Products()
                   {
                    ProductId = 22,
                    CatId = 2,
                    ProductName = "Diamond stone Ring",
                    Price = 320,
                    Description = "Beautify stone ring",
                    ImgUrl = "gold5"
                   },
                 new Products()
                   {
                    ProductId = 23,
                    CatId = 2,
                    ProductName = "India Gold chain with stone",
                    Price = 168,
                    Description = "Neck fitting beutiful jewelry",
                    ImgUrl = "gold6"
                   },
                 new Products()
                   {
                    ProductId = 24,
                    CatId = 2,
                    ProductName = "Tiny blade gold chain",
                    Price = 50,
                    Description = "Gold made shinning necklace",
                    ImgUrl = "gold7"
                   },
                 new Products()
                   {
                    ProductId = 25,
                    CatId = 2,
                    ProductName = "Gold wrist bangles",
                    Price = 40,
                    Description = "Gold ring bangles for ladies",
                    ImgUrl = "gold8"
                   },

                 new Products()
                   {
                    ProductId = 17,
                    CatId = 1,
                    ProductName = "Italian Round-neck shirt",
                    Price = 50,
                    Description = "Unisex flexible round neck",
                    ImgUrl = "prod5"
                   },

                 new Products()
                   {
                    ProductId = 18,
                    CatId = 1,
                    ProductName = "Complete wears combo",
                    Price = 250,
                    Description = "Complete Outfit pack available for pre-oder",
                    ImgUrl = "prod6"
                   },

                 new Products()
                   {
                    ProductId = 19,
                    CatId = 1,
                    ProductName = "Office suite wears",
                    Price = 50,
                    Description = "Nice long-hand T-Shirt and vintage Tie",
                    ImgUrl = "prod7"
                   },
                 new Products()
                   {
                    ProductId = 26,
                    CatId = 2,
                    ProductName = "Diamond stone gold necklace",
                    Price = 350,
                    Description = "light weight diamond stone gold necklace for women ",
                    ImgUrl = "gold9"
                   },
                 new Products()
                   {
                    ProductId = 27,
                    CatId = 5,
                    ProductName = "Apple IOS 14",
                    Price = 1700,
                    Description = "Very fast Apple OS with 6GB RAM",
                    ImgUrl = "Apple_ios14"
                   },
                 new Products()
                   {
                    ProductId = 28,
                    CatId = 5,
                    ProductName = "Camon 15",
                    Price = 250,
                    Description = "Enjoy a very clear camera experience on Camon. Tecno has released this product to get you covered",
                    ImgUrl = "camon15"
                   },
                 new Products()
                   {
                    ProductId = 29,
                    CatId = 5,
                    ProductName = "Infinix Zero 8",
                    Price = 300,
                    Description = "Ultra camera now at the peak with Infinix Zero 8 features. The product Comes with 16Mp Rear camera and 5000MAh Battery",
                    ImgUrl = "infinixZero8"
                   },
                 










                 new Products()
                   {
                    ProductId = 32,
                    CatId = 5,
                    ProductName = "Samsung Galaxy 5G",
                    Price = 2350,
                    Description = "The world of Artificial intelligence is here with Samsung Galaxy 5G. This device perfect a very fast internet service with 5000MAh and 64MP Rear camera",
                    ImgUrl = "SamsungGalaxy5G"
                   },

                 new Products()
                   {
                    ProductId = 33,
                    CatId = 5,
                    ProductName = "Tecno Ice",
                    Price = 115,
                    Description = "A light weight device with 3GB RAM, 8MP ",
                    ImgUrl = "TecnoIce"
                   },

                 new Products()
                   {
                    ProductId = 34,
                    CatId = 5,
                    ProductName = "Tecno Pova",
                    Price = 205,
                    Description = "This device comes with 5500MAh, 2GB RAM and 8MP Rear camera",
                    ImgUrl = "TecnoPova"
                   },
            };
        }

        public async Task GetAllProductAsync()
        {
            try
            {
                foreach (var good in ProductsItems)
                {
                    await client.Child("ProductsItem").PostAsync(new Products()
                    {
                        ProductId = good.ProductId,
                        ProductName = good.ProductName,
                        CatId = good.CatId,
                        Price = good.Price,
                        ImgUrl = good.ImgUrl,
                        Description = good.Description
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

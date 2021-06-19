using Microsoft.AspNetCore.Identity;
using SwiftTraders.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraders.Infrastructure.DBContext
{
    public static class SeedData
    {
        public async static Task AddUsers(UserManager<Users> userManager, RoleManager<IdentityRole> roleManager)
        {
            if(await userManager.FindByEmailAsync("Juwonolowu52@gmail.com") == null)
            {
                var appUser = new Users
                {
                    Fullname = "Olowu Juwon",
                    Email = "Juwonolowu52@gmail.com",
                    UserName = "Juwonolowu52@gmail.com",
                    Telephone = "08140241451",
                    WalletBalance = 10000
                };

                var result = await userManager.CreateAsync(appUser, "Juwwy22@");

                if(result.Succeeded)
                {
                    await CreateRole(roleManager);
                    await userManager.AddToRoleAsync(appUser, "Admin");
                }
            }
        }

        private async static Task CreateRole(RoleManager<IdentityRole> roleManager)
        {
            if(!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }
        }

        public async static Task AddCategories(SwiftTraderDbContext dbContext)
        {
            if(!dbContext.Categories.Any())
            {
                var Categories = new List<Category>()
                {
                    new Category()
                {
                    CategoryName = "Clothes",
                    ImgUrl = "prod1.jpg",
                    Description = "Men and Women fashion wear of variety of designs"
                },
                new Category()
                {
                    CategoryName = "Jewelry",
                    ImgUrl = "gold9.jpg",
                    Description = "Beautifying valuable Jewelry at very affordable rate  "
                },
                new Category()
                {
                    CategoryName = "Wrist watch",
                    ImgUrl = "watch2.jpg",
                    Description = "Quality men and women style wrist watch at a friendly order rate"
                },
                new Category()
                {
                    CategoryName = "Shoes",
                    ImgUrl = "shoe1.jpg",
                    Description = "Designers foot wears of any type available"
                },
                new Category()
                {
                    CategoryName = "Phones",
                    ImgUrl = "TecnoPova.jpg",
                    Description = "Mobile phone available at cheap rate"
                },
                };

                await dbContext.AddRangeAsync(Categories);
                await dbContext.SaveChangesAsync();
            }
            //cloth - "df32f910-2a91-4314-a2a2-c68d2766d0f7"
            //Wristwatch -  "f162453d-ee39-48d3-b461-28cdd72a6bfb"
            //Jewelry -   "105ff24a-a952-4a18-8a06-dad8b97ecb31"
            //Phone -  "5d459a7a-af39-48c2-b4a5-3b481915a141"
            //shoe - "207a60f8-c2b4-4396-9006-313c261d067f"
        }

        public async static Task AddProducts(SwiftTraderDbContext dbContext)
        {
            if (!dbContext.Product.Any())
            {
                var prod = new List<Products>()
            {
                new Products()
                {

                    CategoryId =  "df32f910-2a91-4314-a2a2-c68d2766d0f7",
                    ProductName = "Red Gown",
                    Price = 56,
                    Description = "Red female gown with beautiful layers",
                    ImgUrl = "prod1"
                },
                 new Products()
                {
                    CategoryId =  "df32f910-2a91-4314-a2a2-c68d2766d0f7",
                    ProductName = "French Gown",
                    Price = 80,
                    Description = "Butter color female gown with beautiful layers. Ancient french fashion style ",
                    ImgUrl = "prod2"
                },


                  new Products()
                {
                CategoryId = "105ff24a-a952-4a18-8a06-dad8b97ecb31",
                ProductName = "Bead necklace",
                Price = 75,
                Description = "Beautiful bead stones necklace for women",
                ImgUrl = "gold2"
                },
                 new Products()
                   {
                    CategoryId = "105ff24a-a952-4a18-8a06-dad8b97ecb31",
                    ProductName = "Tiny gold blade ",
                    Price = 135,
                    Description = "Very tiny Gold blade necklace with avery beautiful design",
                    ImgUrl = "gold3"
                   },

                 new Products()
                   {
                    CategoryId = "105ff24a-a952-4a18-8a06-dad8b97ecb31",
                    ProductName = "Gold ear rings",
                    Price = 40,
                    Description = "Ear fitting pieces of gold earring for women",
                    ImgUrl = "gold4"
                   },

                new Products()
                {
                CategoryId =  "df32f910-2a91-4314-a2a2-c68d2766d0f7",
                ProductName = "Round neck shirt",
                Price = 35,
                Description = "Unisex round neck short-hand shirt with very soft fabrics",
                ImgUrl = "prod3"
                },

                new Products()
                   {
                    CategoryId = "105ff24a-a952-4a18-8a06-dad8b97ecb31",
                    ProductName = "Slim Gold necklace ",
                    Price = 120,
                    Description = "Soft touch neck chain for women",
                    ImgUrl = "gold1"
                   },


                 new Products()
                   {
                    CategoryId = "207a60f8-c2b4-4396-9006-313c261d067f",
                    ProductName = "Nike Sneakers",
                    Price = 30,
                    Description = "Smart jogging and outfitting footwear for men",
                    ImgUrl = "shoe1"
                   },


                 new Products()
                   {
                    CategoryId = "f162453d-ee39-48d3-b461-28cdd72a6bfb",
                    ProductName = "Silver Rollace",
                    Price = 80,
                    Description = "Steel fashioned wristwatch for men",
                    ImgUrl = "watch2"
                   },

                 new Products()
                   {
                    CategoryId ="f162453d-ee39-48d3-b461-28cdd72a6bfb",
                    ProductName = "Leather band Wristwatch",
                    Price = 46,
                    Description = "Water resistance wristwatch with very good leather handle",
                    ImgUrl = "watch3"
                   },
                 new Products()
                   {
                    CategoryId = "207a60f8-c2b4-4396-9006-313c261d067f",
                    ProductName = "Addidas shoes",
                    Price = 42,
                    Description = "Black Smart jogging and outfitting footwear for men",
                    ImgUrl = "shoe2"
                   },
                 new Products()
                   {
                    CategoryId = "207a60f8-c2b4-4396-9006-313c261d067f",
                    ProductName = "Jordan hillboot",
                    Price = 70,
                    Description = "Men white jordan hill top shoe. Very well fit in for party",
                    ImgUrl = "shoe3"
                   },

                 new Products()
                   {
                    CategoryId = "207a60f8-c2b4-4396-9006-313c261d067f",
                    ProductName = "Nike Sneakers",
                    Price = 30,
                    Description = "Smart jogging and outfitting footwear for men",
                    ImgUrl = "shoe2"
                   },

                 new Products()
                   {
                    CategoryId = "f162453d-ee39-48d3-b461-28cdd72a6bfb",
                    ProductName = "Apple iWatch",
                    Price = 300,
                    Description = "Unisex smart wrist watch",
                    ImgUrl = "watch1"
                   },


                 new Products()
                   {
                    CategoryId = "f162453d-ee39-48d3-b461-28cdd72a6bfb",
                    ProductName = "Women Wristwatch",
                    Price = 15,
                    Description = "Multi-color ladies wrist watch with very soft paint texture",
                    ImgUrl = "watch4"
                   },

                 new Products()
                   {
                    CategoryId =  "df32f910-2a91-4314-a2a2-c68d2766d0f7",
                    ProductName = "Men T-Shirt",
                    Price = 36,
                    Description = "Office made smart long-hand T-Shirt for Men",
                    ImgUrl = "prod4"
                   },


                 new Products()
                   {
                    CategoryId = "5d459a7a-af39-48c2-b4a5-3b481915a141",
                    ProductName = "Tecno Spark 4",
                    Price = 120,
                    Description = "Very strong Battery life device with 3GB RAM with 13MP Rear camera",
                    ImgUrl = "phone1"
                   },

                 new Products()
                   {
                    CategoryId = "5d459a7a-af39-48c2-b4a5-3b481915a141",
                    ProductName = "Samsung 10",
                    Price = 1650,
                    Description = "Samsung marvelous latest product with very friendly user experience. 32MP Rear camera with 8GB RAM with 3200MAh Battery life",
                    ImgUrl = "samsung10"
                   },

                 new Products()
                   {
                    CategoryId =  "df32f910-2a91-4314-a2a2-c68d2766d0f7",
                    ProductName = "Female elastic gown dress",
                    Price = 145,
                    Description = "Red soft elastic fabric gown for women ",
                    ImgUrl = "prod8"
                   },

                 new Products()
                   {
                    CategoryId =  "df32f910-2a91-4314-a2a2-c68d2766d0f7",
                    ProductName = "Home net gown",
                    Price = 36,
                    Description = "Simple home and outdoor gown for ladies",
                    ImgUrl = "prod9"
                   },
                 new Products()
                   {
                    CategoryId = "105ff24a-a952-4a18-8a06-dad8b97ecb31",
                    ProductName = "Diamond stone Ring",
                    Price = 320,
                    Description = "Beautify stone ring",
                    ImgUrl = "gold5"
                   },
                 new Products()
                   {
                    CategoryId = "105ff24a-a952-4a18-8a06-dad8b97ecb31",
                    ProductName = "India Gold chain with stone",
                    Price = 168,
                    Description = "Neck fitting beutiful jewelry",
                    ImgUrl = "gold6"
                   },
                 new Products()
                   {
                    CategoryId = "105ff24a-a952-4a18-8a06-dad8b97ecb31",
                    ProductName = "Tiny blade gold chain",
                    Price = 50,
                    Description = "Gold made shinning necklace",
                    ImgUrl = "gold7"
                   },
                 new Products()
                   {
                    CategoryId = "105ff24a-a952-4a18-8a06-dad8b97ecb31",
                    ProductName = "Gold wrist bangles",
                    Price = 40,
                    Description = "Gold ring bangles for ladies",
                    ImgUrl = "gold8"
                   },

                 new Products()
                   {
                    CategoryId =  "df32f910-2a91-4314-a2a2-c68d2766d0f7",
                    ProductName = "Italian Round-neck shirt",
                    Price = 50,
                    Description = "Unisex flexible round neck",
                    ImgUrl = "prod5"
                   },


                 new Products()
                   {
                    CategoryId =  "df32f910-2a91-4314-a2a2-c68d2766d0f7",
                    ProductName = "Complete wears combo",
                    Price = 250,
                    Description = "Complete Outfit pack available for pre-oder",
                    ImgUrl = "prod6"
                   },

                 new Products()
                   {
                    CategoryId =  "df32f910-2a91-4314-a2a2-c68d2766d0f7",
                    ProductName = "Office suite wears",
                    Price = 50,
                    Description = "Nice long-hand T-Shirt and vintage Tie",
                    ImgUrl = "prod7"
                   },
                 new Products()
                   {
                    CategoryId = "105ff24a-a952-4a18-8a06-dad8b97ecb31",
                    ProductName = "Diamond stone gold necklace",
                    Price = 350,
                    Description = "light weight diamond stone gold necklace for women ",
                    ImgUrl = "gold9"
                   },
                 new Products()
                   {
                    CategoryId = "5d459a7a-af39-48c2-b4a5-3b481915a141",
                    ProductName = "Apple IOS 14",
                    Price = 1700,
                    Description = "Very fast Apple OS with 6GB RAM",
                    ImgUrl = "Apple_ios14"
                   },
                 new Products()
                   {
                    CategoryId = "5d459a7a-af39-48c2-b4a5-3b481915a141",
                    ProductName = "Camon 15",
                    Price = 250,
                    Description = "Enjoy a very clear camera experience on Camon. Tecno has released this product to get you covered",
                    ImgUrl = "camon15"
                   },
                 new Products()
                   {
                    CategoryId = "5d459a7a-af39-48c2-b4a5-3b481915a141",
                    ProductName = "Infinix Zero 8",
                    Price = 300,
                    Description = "Ultra camera now at the peak with Infinix Zero 8 features. The product Comes with 16Mp Rear camera and 5000MAh Battery",
                    ImgUrl = "infinixZero8"
                   },


                 new Products()
                   {
                    CategoryId = "5d459a7a-af39-48c2-b4a5-3b481915a141",
                    ProductName = "Samsung Galaxy 5G",
                    Price = 2350,
                    Description = "The world of Artificial intelligence is here with Samsung Galaxy 5G. This device perfect a very fast internet service with 5000MAh and 64MP Rear camera",
                    ImgUrl = "SamsungGalaxy5G"
                   },

                 new Products()
                   {
                    CategoryId = "5d459a7a-af39-48c2-b4a5-3b481915a141",
                    ProductName = "Tecno Ice",
                    Price = 115,
                    Description = "A light weight device with 3GB RAM, 8MP ",
                    ImgUrl = "TecnoIce"
                   },

                 new Products()
                   {
                    CategoryId = "5d459a7a-af39-48c2-b4a5-3b481915a141",
                    ProductName = "Tecno Pova",
                    Price = 205,
                    Description = "This device comes with 5500MAh, 2GB RAM and 8MP Rear camera",
                    ImgUrl = "TecnoPova"
                   },
            };

                await dbContext.AddRangeAsync(prod);
                await dbContext.SaveChangesAsync();
            }
        }

        public async static Task AddAdvertPosts(SwiftTraderDbContext dbContext)
        {
            if(!dbContext.AdvertModels.Any())
            {
                var ads = new List<AdvertModel>()
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

                await dbContext.AddRangeAsync(ads);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SwiftTraderPRoject.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public int CatId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
    }
}

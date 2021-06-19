using System;
using System.Collections.Generic;
using System.Text;

namespace SwiftTraders.ApplicationCore.Entities
{
    public class Products : AuditableEntity
    {
        public Category Category { get; set; }
        public string CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
    }
}

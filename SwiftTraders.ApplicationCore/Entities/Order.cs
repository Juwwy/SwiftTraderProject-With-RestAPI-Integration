using System;
using System.Collections.Generic;
using System.Text;

namespace SwiftTraders.ApplicationCore.Entities
{
    public class Order : AuditableEntity
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public decimal TotalCost { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SwiftTraders.ApplicationCore.DTOs
{
    public class OrderDTO
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Username { get; set; }
        public decimal TotalCost { get; set; }
    }
}

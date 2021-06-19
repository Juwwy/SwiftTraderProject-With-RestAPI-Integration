using System;
using System.Collections.Generic;
using System.Text;

namespace SwiftTraderPRoject.Models
{
    public class OrderDetails
    {
        public string OrderDetailId { get; set; }
        public string OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

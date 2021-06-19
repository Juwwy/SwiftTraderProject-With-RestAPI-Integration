using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwiftTraderPRoject.Models
{
    [Table("CartItem")]
    public class CartItem
    {
        [AutoIncrement, PrimaryKey]
        public int CartItemId { get; set; }
        public string ProductId { get; set; } //[int ProductId] ===> firebase
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // second project
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SwiftTraderPRoject.Models
{
    public class Cart
    {
        public string Username { get; set; }
        public int CartId { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}

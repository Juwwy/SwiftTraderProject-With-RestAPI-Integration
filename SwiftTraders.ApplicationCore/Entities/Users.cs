using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwiftTraders.ApplicationCore.Entities
{
    public class Users : IdentityUser
    {
        public string Fullname { get; set; }
        public string Telephone { get; set; }
        public decimal WalletBalance { get; set; }
        public string UserRole { get; set; }
    }
}
